using DapperTestProject.Models;
using DapperTestProject.Repositories;

namespace DapperTestProject
{
    public class Requests
    {
        string _connectionString;
        public Requests(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AllQueries()
        {
            var customerRep = new CustomerRepository(_connectionString);
            var orderRep = new OrderRepository(_connectionString);
            var productRep = new ProductRepository(_connectionString);

            Console.WriteLine("--- Select customer by id ---");
            int result = GetInputId();
            var customerById = customerRep.GetCustomer(result);
            Console.WriteLine($"{customerById.lastname} {customerById.firstname}");

            Console.WriteLine("--- Create new customer ---");
            int nextId = customerRep.GetCustomers().Count() + 1;
            var newCustomer = new Customer()
            {
                id = nextId,
                lastname = $"Dalas{nextId}",
                firstname = "Lilu",
                age = 25
            };
            customerRep.CreateCustomer(newCustomer);
            Console.WriteLine($"User: {newCustomer.lastname} {newCustomer.firstname} with id: {newCustomer.id} - successfully added!");

            Console.WriteLine("--- Select order by id ---");
            int resultInt = GetInputId();
            var orderById = orderRep.GetOrder(resultInt);
            Console.WriteLine($"CustomerId - {orderById.customerid}, ProductId - {orderById.productid}");

            Console.WriteLine("--- Update order by id ---");
            int orderResult = GetInputId();
            var getorder = orderRep.GetOrder(orderResult);
            getorder.quantity = 333;
            orderRep.UpdateOrder(getorder);
            Console.WriteLine($"Order with id={getorder.id} - successfully updated!");

            Console.WriteLine("--- Delete product by id ---");
            int productId = GetInputId();
            productRep.DeleteProduct(productId);
            Console.WriteLine($"Product with id={productId} - successfully deleted!");

            Console.WriteLine("--- Update product by id ---");
            int product = GetInputId();
            var getproduct = productRep.GetProduct(product);
            getproduct.stockquantity = 333;
            productRep.UpdateProduct(getproduct);
            Console.WriteLine($"Product with id={getproduct.id} - successfully updated!");

            Console.WriteLine("--- Select all customers over 30 years of age who have a product with id=1 ---");
            List<Customer> allCustomer = customerRep.GetCustomerOver30WithProductId1();
            foreach (Customer customer in allCustomer) 
            {
                Console.WriteLine($"{customer.id} - {customer.lastname} {customer.firstname}");
            }
        }

        public int GetInputId()
        {
            bool input;
            int result = 0;
            do
            {
                Console.WriteLine("Input id:");
                input = int.TryParse(Console.ReadLine(), out result);
                if (!input) Console.WriteLine("Wrong input format. It must be integer!");
            } while (!input);

            return result;
        }
    }
}
