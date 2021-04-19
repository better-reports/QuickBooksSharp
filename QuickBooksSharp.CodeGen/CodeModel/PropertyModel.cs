namespace QuickBooksSharp.CodeGen
{
    public class PropertyModel
    {
        public string Name { get; set; }

        public string TypeName { get; set; }

        public bool IsNullable { get; set; }

        public bool IsArray { get; set; }

        public string Code { get; set; }
    }
}
