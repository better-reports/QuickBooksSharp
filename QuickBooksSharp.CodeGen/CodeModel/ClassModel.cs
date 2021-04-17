using System.Collections.Generic;

namespace QuickBooksSharp.CodeGen
{
    public class ClassModel
    {
        public string Name { get; set; }

        public string BaseName { get; set; }

        public bool IsAbstract { get; set; }

        public PropertyModel[] Properties { get; set; }
    }
}
