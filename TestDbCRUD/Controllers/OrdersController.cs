using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDbCRUD.Data;
using TestDbCRUD.Models;
using TestDbCRUD.Models.Domain;

namespace TestDbCRUD.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MoveItDbContext moveItDbContext;

        public OrdersController(MoveItDbContext moveItDbContext)
        {
            this.moveItDbContext = moveItDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await moveItDbContext.Orders.ToListAsync()
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddOrderViewModel addOrderRequest)
        {
            var order = new Orders()
            {
                Id = Guid.NewGuid(),
                Contents = addOrderRequest.Contents,
                OrderDate = addOrderRequest.OrderDate,
                Weight = addOrderRequest.Weight,
                Dimentions = addOrderRequest.Dimentions,
                Location = addOrderRequest.Location,
            };

            await moveItDbContext.Orders.AddAsync(order);
            await moveItDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }

    }
}
