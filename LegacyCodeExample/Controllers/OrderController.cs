using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LegacyCodeExample.Core;

namespace LegacyCodeExample.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService orderService;

        public OrderController()
        {
            orderService = new OrderService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult SendOrderConfirmation(int orderId)
        {
            orderService.SendOrderConfirmationToCustomer(orderId);

            return View("ConfimationSent");
        }

        public ViewResult SaveOrder()
        {
            orderService.SaveOrder(new Order{ Id = 99, CustomerEmailAddress = "daniel.lee@activesolution.se"});

            return View("Index");
        }

    }
}
