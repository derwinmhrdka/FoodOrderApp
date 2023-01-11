using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var orders = await _context.Orders.Include(sh => sh.Menus).ToListAsync();
            return Ok(orders);
        }

        [HttpGet("menu")]
        public async Task<ActionResult<List<Menus>>> GetMenu()
        {
            var menu = await _context.Menu.ToListAsync();
            return Ok(menu);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetSingleOrder(int id)
        {
            var ord = await _context.Orders
                .Include(h => h.Menus)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (ord == null)
            {
                return NotFound("Menu tidak tersedia. :/");
            }
            return Ok(ord);
        }
     

        [HttpPost]
        public async Task<ActionResult<List<Order>>> CreateOrder(Order ord)
        {
            ord.Menus = null;
            _context.Orders.Add(ord);
            await _context.SaveChangesAsync();
            return Ok(await GetDbOrders());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Order>>> UpdateOrder(Order ord, int id)
        {
            var dbOrd = await _context.Orders
                .Include(sh => sh.Menus)
                .FirstOrDefaultAsync(sh => sh.Id == id);

            if (dbOrd == null)
                return NotFound("Sorry, order invalid. :/");

            dbOrd.NoOrder = ord.NoOrder;
            dbOrd.NomorMeja = ord.NomorMeja;
            dbOrd.MenusId = ord.MenusId;

            await _context.SaveChangesAsync();
            return Ok(await GetDbOrders());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Order>>> DeleteOrder(int id)
        {
            var dbOrd = await _context.Orders
                .Include(sh => sh.Menus)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbOrd == null)
                return NotFound("Sorry, order invalid. :/");

            _context.Orders.Remove(dbOrd);
            await _context.SaveChangesAsync();
            return Ok(await GetDbOrders());
        }

        private async Task<List<Order>> GetDbOrders()
        {
            return await _context.Orders.Include(sh => sh.Menus).ToListAsync();
        }
    }
}
