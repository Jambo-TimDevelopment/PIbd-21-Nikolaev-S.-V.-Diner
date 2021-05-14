using AbstractDinerBusinessLogic.BindingModels;
using AbstractDinerBusinessLogic.BusinessLogic;
using AbstractDinerBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AbstractDinerRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;
        private readonly SnackLogic _product;
        private readonly OrderLogic _main;
        public MainController(OrderLogic order, SnackLogic snack, OrderLogic main)
        {
            _order = order;
            _product = snack;
            _main = main;
        }
        [HttpGet]
        public List<SnackViewModel> GetSnackList() => _product.Read(null)?.ToList();

        [HttpGet]
        public SnackViewModel GetSnack(int snackId) => _product.Read(new SnackBindingModel
        { Id = snackId })?[0];
        
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel
        { ClientId = clientId });
       
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}
