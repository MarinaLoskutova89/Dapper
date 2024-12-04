using Dapper;
using DapperTestProject.Models;
using DapperTestProject.Interfaces;
using Npgsql;
using System.Data;

namespace DapperTestProject.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        string _connectionString;
        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateOrder(Order order)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Orders (id, customerid, productid, quantity) VALUES(@Id, @Customerid, @Productid, @Quantity)";
                db.Execute(sqlQuery, order);
            }
        }

        public void DeleteOrder(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Orders WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Order GetOrder(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM Orders WHERE id = @id";
                Order? query = db.Query<Order>(sqlQuery, new { id }).FirstOrDefault();
                if (query != null) return query;
                else throw new Exception($"Order with id = {id} does not exist!");
            }
        }

        public List<Order> GetOrders()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                return db.Query<Order>("SELECT * FROM Orders").ToList();
            }
        }

        public void UpdateOrder(Order order)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Orders SET customerid = @Customerid, productid = @Productid, quantity = @Quantity WHERE Id = @Id";
                db.Execute(sqlQuery, order);
            }
        }
    }
}
