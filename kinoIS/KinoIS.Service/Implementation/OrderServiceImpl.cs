using KinoIs.Repository.Interface;
using KinoIS.Domain.Models;
using KinoIS.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace KinoIS.Service.Implementation
{
    public class OrderServiceImpl : OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderServiceImpl(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> getAllOrders()
        {
            return this._orderRepository.getAllOrders();
        }

        public Order getOrderDetails(Guid id)
        {
            return this._orderRepository.getOrderDetails(id);
        }
    }
}
