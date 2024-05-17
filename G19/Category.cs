namespace G19_ProductImport
{
    public class Category
    {
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; } = new List<Product>();

        public static Category GetCategory(string[] parts)
        {
            return new Category()
            {
                Name = parts[0],
                IsActive = parts[1] == "1"
            };
        }

        public override string ToString() => $"Name: {Name}, IsActive {IsActive}";
    }
}