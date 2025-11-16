namespace RoundTheCodeDotNet9.LinqMethods
{
    public record Product(string Name);

    public class LinqIndex
    {
        List<Product> products =
        [
            new("Watch"),
            new("Ring"),
            new("Necklace"),
        ];

        public Dictionary<string, int> GetIndexForEachProduct()
        {
            var productIndex = new Dictionary<string, int>();

            foreach (var (index, product) in products.Index())
            {
                productIndex.Add(product.Name, index);
            }

            return productIndex;
        }
    }
}