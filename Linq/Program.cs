namespace Linq;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Sales { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public decimal Total { get; set; }
}


internal class Program
{
    static void Main(string[] args)
    {
        JoinsUsingQuery();
    }

    static void PracticeIntegers() { 
        var ints = new int[] {

            69, 46, 68, 65, 18, 50, 35, 97, 77, 38,

            50, 12, 76, 46, 80, 20, 60, 79, 29, 53,

            85, 57, 70, 99, 85, 50, 98, 55, 69, 57,

            21, 57, 55, 86,  2, 35, 47, 79, 94, 11,

            53, 72, 95, 81, 68, 14, 12, 10, 41, 51,

            68, 98, 87, 39, 16, 3,  64, 56, 11, 39,

            84, 35, 32, 77, 50, 71, 96, 37, 37, 70,

            59, 31, 88, 96, 83, 25, 22, 74, 58, 88,

            6,  69,  5, 87, 61, 74, 17, 45, 8,  75,

            40, 49, 95, 67, 96, 60, 82, 56, 21, 84

        };

        //QUERY SYNTAX

        //var integers = from i in ints //this DOES NOT execute it
        //               select i;
        //var integers = from i in ints
        //               where i > 50 && i < 75 && i % 2==0
        //               orderby i descending
        //               select i;

        //var integers = from i in ints
        //               where i > 50 && i < 75 && i % 2==0
        //               orderby i descending
        //               select i).Sum(); //this is how you do Sum in Query Syntax

        //METHOD SYNTAX
        var integers = ints.Where(i => i > 50 && i < 75 && i % 2 == 0)
                           .OrderByDescending(i => i)
                           .Sum(i => i);
        Console.WriteLine($"Sum is {integers}");

        //foreach (var j in integers) //this EXECUTES integers
        //{
        //    Console.Write($" {j} ");
        //}
    }

    static void JoinsUsingQuery()
    {
        var customers = new List<Customer> {
            new Customer { Id = 1, Name = "TQL", Sales = 1000 },
            new Customer { Id = 2, Name = "Microsoft", Sales = 10000 },
            new Customer { Id = 3, Name = "Apple", Sales = 20000 },
        };
        var orders = new List<Order> {
            new Order { Id = 1, CustomerId = 2, Total = 200 },
            new Order { Id = 2, CustomerId = 1, Total = 500 },
            new Order { Id = 3, CustomerId = 3, Total = 1000 }
        };

        var CustomersOrders = from c in customers
                              join o in orders
                              on c.Id equals o.CustomerId
                              orderby o.Total descending
                              select new { 
                                  Customer = c.Name, c.Sales, o.Total //Customer is an alias
                              };
        foreach(var custord in CustomersOrders)
        {
            Console.WriteLine($"{custord.Customer} | {custord.Sales} | {custord.Total:C}");
        }
}
}
    