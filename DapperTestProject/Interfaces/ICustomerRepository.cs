using DapperTestProject.Models;

namespace DapperTestProject.Interfaces
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        void DeleteCustomer(int id);
        Customer GetCustomer(int id);
        List<Customer> GetCustomers();
        void UpdateCustomer(Customer customer);
    }
}
