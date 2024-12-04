using Dapper;
using DapperTestProject.Models;
using DapperTestProject.Interfaces;
using Npgsql;
using System.Data;

namespace DapperTestProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        string _connectionString;
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void CreateProduct(Product product)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Products (id, name, description, stockquantity, price) VALUES(@Id, @Name, @Description, @Stockquantity, @Price)";
                db.Execute(sqlQuery, product);
            }
        }

        public void DeleteProduct(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Products WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Product GetProduct(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string sqlQuery = "SELECT * FROM Products WHERE id = @id";
                Product? query = db.Query<Product>(sqlQuery, new { id }).FirstOrDefault();
                if (query != null) return query;
                else throw new Exception($"Product with id = {id} does not exist!");
            }
        }

        public List<Product> GetProducts()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                return db.Query<Product>("SELECT * FROM Products").ToList();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Products SET Name = @Name, description = @Description, stockquantity = @Stockquantity, price = @Price WHERE Id = @Id";
                db.Execute(sqlQuery, product);
            }
        }
    }
}
