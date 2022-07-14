using KinoIS.Domain.Models;
using KinoIS.Domain.Relations;
using KinoIS.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace KinoIS.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderService orderService;
        private readonly TicketService ticketService;
        private readonly TicketInOrderService ticketInOrderService;
        private readonly KinoUserService kinoUserService;
        public OrdersController(OrderService orderService, TicketService ticketService, 
            TicketInOrderService ticketInOrderService, KinoUserService kinoUserService)
        {
            this.orderService = orderService;
            this.ticketService = ticketService;
            this.ticketInOrderService = ticketInOrderService;
            this.kinoUserService = kinoUserService;
        }
        public IActionResult AllOrders(string email)
        {
            KinoUser user = this.kinoUserService.findByEmail(email);
            List<Order> orders = this.orderService.getAllOrdersByUserId(user.Id);
            return View(orders);
        }
        public IActionResult OrderDetails(Guid orderId)
        {
            List<Ticket> ticketInOrder = this.ticketInOrderService.ticketsInOrder(orderId);
            ViewBag.orderId = orderId;
            return View(ticketInOrder);
        }
        public IActionResult DeleteOrder(Guid orderId)
        {
            this.orderService.deleteOrder(orderId);
            return RedirectToAction("AllOrders", "Orders", new {email = User.Identity.Name});
        }
    }
}
