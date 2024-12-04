using DapperTestProject.Models;

namespace DapperTestProject.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        void DeleteOrder(int id);
        Order GetOrder(int id);
        List<Order> GetOrders();
        void UpdateOrder(Order order);
    }
}
