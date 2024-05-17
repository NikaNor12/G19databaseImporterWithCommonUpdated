namespace G19_ProductImport
{
    public static class FileManager
    {
        public static IEnumerable<Category> ReadData(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath)) throw new FileNotFoundException("File not found.", filePath);

            var categories = new Dictionary<string, Category>();
            // var categories2 = new Dictionary<string, Category>();
            using var reader = new StreamReader(filePath);
            while (!reader.EndOfStream)
            {
                string[] parts = reader.ReadLine()!.Split('\t');
                Category category = GetCategoryFromDictionary(Category.GetCategory(parts), categories);
                Product product = Product.GetProduct(parts);
                category.Products.Add(product);
            }

            return categories.Values;
        }

        //TODO: vifiqrot siswrafis optimizaciaze. ecadet gadaaketot logika dictionary-ze
        private static Category GetCategoryFromDictionary(Category category, Dictionary<string,Category> categories)
        {
            if (categories.ContainsKey(category.Name))
            {
                return categories[category.Name];
            }
            else
            {
                categories.Add(category.Name, category);
                return categories[category.Name];
            }
            //if (categories.TryGetValue(category.Name, out Category? value))
            //{
            //    return value;
            //}
            //else
            //{
            //    categories.Add(category.Name, category);
            //    return categories[category.Name];
            //}
          
        }
    }
}