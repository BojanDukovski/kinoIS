using ClosedXML.Excel;
using KinoIs.Repository.Interface;
using KinoIS.Domain.Models;
using KinoIS.Domain.Relations;
using KinoIS.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace KinoIS.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly KinoUserService userService;
        private readonly TicketService ticketService;
        private readonly OrderService orderService;
        private readonly TicketInOrderService ticketInOrderService;
        public AdminController(KinoUserService userService, TicketService ticketService, OrderService orderService,
            TicketInOrderService ticketInOrderService)
        {
            this.userService = userService; 
            this.ticketService = ticketService;
            this.orderService = orderService;
            this.ticketInOrderService = ticketInOrderService;
        }
        public IActionResult ExportAllOrders(string genre)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = userService.findById(userId);
            if (user.Role == "Admin")
            {
                string fileName = "Orders.xlsx";
                string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                List<Order> result = new List<Order>();

                if (genre != null)
                {
                    foreach(TicketInOrder tio in this.ticketInOrderService.findAll())
                    {
                        Ticket ticket = this.ticketService.findById(tio.ProductId);
                        if (ticket.Genre == genre)
                        {
                            result.Add(this.orderService.findById(tio.OrderId));
                        }
                    }
                } 
                else
                {
                    foreach (TicketInOrder tio in this.ticketInOrderService.findAll())
                    {
                        result.Add(this.orderService.findById(tio.OrderId));
                    }
                }

                using (var workBook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workBook.Worksheets.Add("All Orders");

                    worksheet.Cell(1, 1).Value = "Order Id";
                    worksheet.Cell(1, 2).Value = "Costumer Name";
                    worksheet.Cell(1, 3).Value = "Costumer Last Name";
                    worksheet.Cell(1, 4).Value = "Costumer Email";

                    for (int i = 1; i <= result.Count(); i++)
                    {
                        var item = result[i - 1];

                        worksheet.Cell(i + 1, 1).Value = item.Id.ToString();
                        worksheet.Cell(i + 1, 2).Value = item.User.Name;
                        worksheet.Cell(i + 1, 3).Value = item.User.Surname;
                        worksheet.Cell(i + 1, 4).Value = item.User.Email;

                        for (int p = 1; p <= item.TicketInOrders.Count(); p++)
                        {
                            worksheet.Cell(1, p + 4).Value = "Product-" + (p + 1);
                            worksheet.Cell(i + 1, p + 4).Value = item.TicketInOrders.ElementAt(p - 1).Ticket.Movie;
                        }

                    }

                    using (var stream = new MemoryStream())
                    {
                        workBook.SaveAs(stream);

                        var content = stream.ToArray();

                        return File(content, contentType, fileName);
                    }
                }
            }
            return RedirectToAction("Error", "Admin");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
