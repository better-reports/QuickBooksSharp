using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace QuickBooksSharp.CodeGen
{
    class Program
    {
        /// <summary>
        /// -Download latest minor version XSD from https://developer.intuit.com/app/developer/qbo/docs/develop/explore-the-quickbooks-online-api/minor-versions
        /// -Unzip into the xsd/3.{MinorVersion} folder
        /// -Update version local below 
        /// -Update QuickBooksUrl.cs MinorVersion
        /// -Run program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string version = "3.65";
            string currentDir = Directory.GetCurrentDirectory();
            string solutionPath = currentDir.Substring(0, currentDir.IndexOf("QuickBooksSharp"));
            string xsdPath = Path.Combine(solutionPath, $"QuickBooksSharp/QuickBooksSharp.CodeGen/xsd/{version}");
            string outFilePath = Path.Combine(solutionPath, "QuickBooksSharp/QuickBooksSharp/Entities/Generated.cs");
            var schemas = Directory.GetFiles(xsdPath)
                                     .Select(filePath => XmlSchema.Read(new StringReader(File.ReadAllText(filePath)), null))
                                     .ToArray();
            var set = new XmlSchemaSet();
            foreach (var s in schemas)
                set.Add(s);
            set.Compile();

            var globalTypes = set.GlobalTypes.Values.Cast<XmlSchemaType>()
                                                    .ToArray();
            var elts = set.GlobalElements.Values.Cast<XmlSchemaElement>().ToArray();

            var eltNameToSubstitutedElements = elts.Where(e => !string.IsNullOrEmpty(e.SubstitutionGroup.Name))
                                                   .ToLookup(e => e.SubstitutionGroup.Name);
            var simpleTypes = globalTypes.OfType<XmlSchemaSimpleType>().ToArray();
            var complexTypes = globalTypes.OfType<XmlSchemaComplexType>().ToArray();

            var enums = GenerateEnums(simpleTypes);
            var classes = GenerateClasses(complexTypes, eltNameToSubstitutedElements);
            GenerateOutFile(outFilePath, enums, classes);
            FormatOutFile(outFilePath);
        }

        private static XmlSchemaComplexType GetParentComplexType(XmlSchemaObject o)
        {
            var p = o.Parent;
            while (p != null && p is not XmlSchemaComplexType)
                p = p.Parent;

            return p as XmlSchemaComplexType;
        }

        private static IEnumerable<XmlSchemaParticle> GetParticlesRec(XmlSchemaComplexType complexType, XmlSchemaSequence seq)
        {
            foreach (var item in seq.Items)
            {
                var parentComplexType = GetParentComplexType(item);
                if (parentComplexType != null && parentComplexType != complexType)
                    continue;
                switch (item)
                {
                    case XmlSchemaChoice choice:
                        yield return choice;
                        break;

                    case XmlSchemaElement elt:
                        yield return elt;
                        break;

                    case XmlSchemaSequence innerSeq:
                        foreach (var p in GetParticlesRec(complexType, innerSeq))
                            yield return p;
                        break;

                    case XmlSchemaAny _:
                        //IntuitAnyType => no pties
                        break;

                    default:
                        throw new Exception("Unexpected particle");
                }
            }
        }

        private static string GetTypeName(string typeName)
        {
            return typeName switch
            {
                "id" => "string",
                "anyURI" => "string",
                "positiveInteger" => "uint",
                "boolean" => "bool",
                "date" => "DateTime",
                "dateTime" => "DateTimeOffset",
                "anyType" => "object",
                _ => typeName
            };
        }

        private static PropertyModel GetPropertyFromElt(XmlSchemaElement elt, bool forceIsNullable, bool forceIsArray)
        {
            return new PropertyModel
            {
                Name = elt.QualifiedName.Name ?? throw new Exception(),
                TypeName = GetTypeName(elt.ElementSchemaType.QualifiedName.Name),
                IsNullable = elt.MinOccurs == 0 || forceIsNullable,
                IsArray = elt.MaxOccurs == decimal.MaxValue || forceIsArray
            };
        }

        private static PropertyModel GetPropertyFromAttribute(XmlSchemaAttribute attr)
        {
            return new PropertyModel
            {
                Name = attr.QualifiedName.Name ?? throw new Exception(),
                TypeName = GetTypeName(attr.AttributeSchemaType.QualifiedName.Name),
                IsNullable = attr.Use == XmlSchemaUse.Optional,
                IsArray = false,
            };
        }

        private static ClassModel[] GenerateClasses(XmlSchemaComplexType[] complexTypes, ILookup<string, XmlSchemaElement> eltNameToSubstitutedElements)
        {
            return complexTypes.Select(t =>
            {
                var pties = new List<PropertyModel>();

                foreach (var attr in t.Attributes.Cast<XmlSchemaAttribute>())
                    pties.Add(GetPropertyFromAttribute(attr));

                if (t.ContentTypeParticle.GetType().Name != "EmptyParticle")
                {
                    var particles = GetParticlesRec(t, (XmlSchemaSequence)t.ContentTypeParticle);
                    var elts = particles.SelectMany(p => p switch
                    {
                        XmlSchemaChoice choice => choice.Items.Cast<XmlSchemaObject>().SelectMany(o =>
                        {
                            if (o is XmlSchemaElement e)
                                return new[] { (Elt: e, IsChoiceChild: true) };
                            else if (o is XmlSchemaSequence s)
                                return GetParticlesRec(t, s).Cast<XmlSchemaElement>().Select(e => (Elt: e, IsChoiceChild: true));
                            else
                                throw new Exception();
                        }),
                        XmlSchemaElement elt => new[] { (Elt: elt, IsChoiceChild: false) },
                        _ => throw new Exception()
                    });
                    foreach (var i in elts)
                    {
                        if (eltNameToSubstitutedElements.Contains(i.Elt.QualifiedName.Name))
                        {
                            bool isArray = i.Elt.MaxOccurs == decimal.MaxValue;
                            bool isNullable = i.Elt.MinOccurs == 0;
                            var subsitutionsPties = new List<PropertyModel>();
                            foreach (var subElt in eltNameToSubstitutedElements[i.Elt.QualifiedName.Name]
                                                        .Where(i => i.QualifiedName.Name != t.Name))
                            {
                                var pty = GetPropertyFromElt(subElt, true, isArray);
                                pties.Add(pty);
                                subsitutionsPties.Add(pty);
                            }
                            bool isAnyNullabe = isNullable || i.IsChoiceChild;
                            pties.Add(new PropertyModel
                            {
                                Name = i.Elt.QualifiedName.Name + (isArray ? "s" : ""),
                                TypeName = i.Elt.ElementSchemaType.QualifiedName.Name,
                                IsArray = isArray,
                                IsNullable = isAnyNullabe,
                                Code = "{ get => " + string.Join(" ?? ", subsitutionsPties.Select((p, index) => (index == subsitutionsPties.Count - 1 ? $"({i.Elt.ElementSchemaType.QualifiedName.Name}{(isArray ? "[]" : "")}{(isAnyNullabe ? "?" : "")})" : "") + p.Name)) + (isAnyNullabe ? "" : "!") + "; }"
                            });
                        }
                        else
                        {
                            pties.Add(GetPropertyFromElt(i.Elt, i.IsChoiceChild, false));
                        }
                    }
                }
                else
                {
                    var contentModel = (XmlSchemaSimpleContent)t.ContentModel;
                    var extension = (XmlSchemaSimpleContentExtension)contentModel.Content;

                    pties.Add(new PropertyModel
                    {
                        Name = "value",
                        TypeName = t.BaseXmlSchemaType.QualifiedName.Name == "id" ? "string" : t.BaseXmlSchemaType.QualifiedName.Name,
                        IsArray = false,
                        IsNullable = false,
                    });
                    foreach (var attr in extension.Attributes.Cast<XmlSchemaAttribute>())
                        pties.Add(GetPropertyFromAttribute(attr));
                }

                bool isReferenceType = t.Name == "ReferenceType";
                bool isCustomFieldDefinitionType = t.Name == "CustomFieldDefinition";
                return new ClassModel
                {
                    Name = t.Name,
                    //todo create a custom converter that can deseriaize to the correct CustomFieldDefinition dervived type
                    //For now, we simply mark the base type as a concrete type, since none of the dervied properties are returned by the API anyway
                    IsAbstract = isCustomFieldDefinitionType ? false : t.IsAbstract,
                    BaseName = isReferenceType ? null : t.BaseXmlSchemaType?.Name,
                    Properties = pties.ToArray()

                };
            }).Where(c => c.Name != null)
              .ToArray();
        }

        private static EnumModel[] GenerateEnums(XmlSchemaSimpleType[] simpleTypes)
        {
            return simpleTypes.Select(t => new EnumModel
            {
                Name = t.Name,
                Fields = (t.Content as XmlSchemaSimpleTypeRestriction)
                                                    .Facets
                                                    .Cast<XmlSchemaFacet>()
                                                    .Select(f => f.Value)
                                                    .Distinct()
                                                    .ToArray()
            }).Where(e => e.Fields.Any())
              .ToArray();
        }

        private static void GenerateOutFile(string outFilePath, EnumModel[] enums, ClassModel[] classes)
        {
            using (var writer = new StreamWriter(outFilePath))
            {
                writer.WriteLine("using System;");
                writer.WriteLine("using System.Runtime.Serialization;");
                writer.WriteLine("using System.Text.Json.Serialization;");
                writer.WriteLine();
                writer.WriteLine("namespace QuickBooksSharp.Entities");
                writer.WriteLine("{");

                foreach (var e in enums)
                {
                    writer.WriteLine($"public enum {e.Name}");
                    writer.WriteLine("{");

                    writer.WriteLine($"Unspecified = 0,");
                    foreach (var name in e.Fields)
                    {
                        string safeName = GetSafePropertyName(name);
                        if (name != safeName)
                            writer.WriteLine($"[EnumMember(Value = \"{name}\")]");
                        writer.WriteLine($"{safeName},");
                    }

                    writer.WriteLine("}");
                }

                foreach (var c in classes)
                {
                    writer.Write($"public {(c.IsAbstract ? "abstract" : "")} class {GetSafeClassName(c.Name)}");
                    if (c.BaseName != null)
                        writer.Write($" : {c.BaseName}");
                    writer.WriteLine();
                    writer.WriteLine("{");

                    foreach (var pty in c.Properties)
                    {
                        string safeName = GetSafePropertyName(pty.Name);
                        if (pty.Name != safeName)
                            writer.WriteLine($"[JsonPropertyName(\"{pty.Name}\")]");
                        string ptyDecl = string.Empty;
                        if (c.Name == "BatchItemRequest")
                            ptyDecl += pty.Name == "IntuitObject" ? "[JsonIgnore]\r\n" : "[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]\r\n";
                        ptyDecl += $"public {GetSafeClassName(pty.TypeName)}";
                        if (pty.IsArray)
                            ptyDecl += "[]";
                        if (pty.IsNullable)
                            ptyDecl += "?";
                        ptyDecl += $" {safeName} ";
                        ptyDecl += pty.Code ?? "{ get; set; }";
                        if (!pty.IsNullable && pty.Code == null)
                            ptyDecl += " = default!; ";
                        writer.WriteLine(ptyDecl);
                    }

                    writer.WriteLine("}");
                }

                writer.WriteLine("}");
            }
        }

        private static void FormatOutFile(string outFilePath)
        {
            string rawText = File.ReadAllText(outFilePath);
            var ws = new AdhocWorkspace();
            var code = CSharpSyntaxTree.ParseText(rawText);
            string formattedText = Formatter.Format(code.GetRoot(), ws).ToFullString();
            File.WriteAllText(outFilePath, formattedText);
        }

        private static string GetSafeClassName(string name)
        {
            //Avoid name conflict with System.Threading.Tasks.Task
            return name == "Task" ? "QbTask" : name;
        }

        private static string GetSafePropertyName(string name)
        {
            //must escape property names that conflict with keywords
            if (new[] { "void" }.Contains(name))
                return $"@{name}";

            return Regex.Replace(name, "[-%)( ]", string.Empty);
        }
    }
}
