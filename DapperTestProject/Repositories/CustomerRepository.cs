using Dapper;
using DapperTestProject.Models;
using DapperTestProject.Interfaces;
using Npgsql;
using System.Data;

namespace DapperTestProject.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        string _connectionString;
        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void CreateCustomer(Customer customer)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Customers (id, age, firstname, lastname) VALUES(@Id, @Age, @Firstname, @Lastname)";
                db.Execute(sqlQuery, customer);
            }
        }

        public void DeleteCustomer(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Customers WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Customer GetCustomer(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM Customers WHERE id = @id";
                Customer? query = db.Query<Customer>(sqlQuery, new { id }).FirstOrDefault();
                if (query != null) return query;
                else throw new Exception($"Customer with id = {id} does not exist!");
            }
        }

        public List<Customer> GetCustomers()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                return db.Query<Customer>("SELECT * FROM Customers").ToList();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Customers SET age = @Age, firstname = @Firstname, lastname = @Lastname WHERE Id = @Id";
                db.Execute(sqlQuery, customer);
            }
        }

        public List<Customer> GetCustomerOver30WithProductId1()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM Customers c JOIN Orders o on c.id = o.customerid JOIN Products p on o.productId = p.id WHERE c.age > 30 and p.id = 1";
                List<Customer> query = db.Query<Customer>(sqlQuery).ToList();
                if (query != null) return query;
                else throw new Exception($"There are no records in the table that match the conditions!");
            }
        }
    }
}
