using KinoIS.Domain.Models;
using KinoIS.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace KinoIS.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly OrderService _orderService;
        private readonly UserManager<KinoUser> _userManager;

        public AdminController(OrderService orderService, UserManager<KinoUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetOrders()
        {
            var result = this._orderService.getAllOrders();
            return result;
        }

        [HttpPost("[action]")]
        public Order GetDetailsForOrder(Guid id)
        {
            var result = this._orderService.getOrderDetails(id);
            return result;
        }



        [HttpPost("[action]")]
        public bool ImportAllUsers(List<KinoUser> model)
        {
            bool status = true;
            foreach (var item in model)
            {
                var userCheck = _userManager.FindByEmailAsync(item.Email).Result;
                if (userCheck == null)
                {
                    var user = new KinoUser
                    {
                        Name = item.Name,
                        Surname = item.Surname,
                        UserName = item.Email,
                        NormalizedUserName = item.Email,
                        Email = item.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        PhoneNumber = item.PhoneNumber,
                        UserCart = new ShoppingCart()
                    };
                    var result = _userManager.CreateAsync(user, item.Password).Result;

                    status = status & result.Succeeded;
                }
                else
                {
                    continue;
                }
            }

            return status;
        }
    }
}
