namespace RoundTheCodeDotNet9.LinqMethods
{
    public record Customer(string Forename, string Surname);
    public class LinqCountBy
    {
        List<Customer> customers = [
            new("Ahmed", "Dalwan"),
            new("Mhmd", "Omar"),
            new("Majed", "Dalwan")
        ];

        public Dictionary<string, int> GetCountForEachSurname()
        {
            var surnameCount = new Dictionary<string, int>();

            foreach (var customer in customers.CountBy(s => s.Surname))
            {
                surnameCount.Add(customer.Key, customer.Value);
            }

            return surnameCount;
        }
    }
}