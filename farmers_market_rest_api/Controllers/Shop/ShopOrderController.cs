using farmers_market_rest_api.Domain.Models.Shop;
using farmers_market_rest_api.Domain.Models.User;
using farmers_market_rest_api.Persistence.Context;
using farmers_market_rest_api.Service.Resources.Shop;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Controllers.Shop
{
    [Route("api/[controller]/[action]")]
    public class ShopOrderController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        private readonly AppDbContext _context;

        public ShopOrderController(SignInManager<ApplicationUser> signInManager,
                               UserManager<ApplicationUser> userManager,
                               RoleManager<ApplicationRole> roleManager,
                               AppDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }


        [HttpPost]
        public async Task<object> Checkout([FromBody]CheckOutResource checkOut)
        {
            var CurrentUserId = checkOut.CurrentUserId;

            var currentUserDetails = _userManager.Users.Where(_ => _.Id == CurrentUserId).FirstOrDefault();

            List<Instrument> products = checkOut.Products;

            OrderShop corder = new OrderShop();

            corder.RoleId = currentUserDetails.ApplicationRoleId;

            corder.UserId = CurrentUserId;

            corder.TotalAmount = checkOut.Amount;

            _context.Add(corder);
            _context.SaveChanges();

            var order = _context.OrderShops.Where(_ => _.Id == corder.Id).FirstOrDefault();

            if (products != null)
            {

                foreach (var product in products)
                {
                    InstrumentOrderDetails orderDetails = new InstrumentOrderDetails();
                    orderDetails.OrderShopId = order.Id;

                    orderDetails.InstrumentId = product.Id;

                    _context.Add(orderDetails);
                    await _context.SaveChangesAsync();

                }

            }

            var rowCount = _context.OrderShops.Count() + 1;

            order.OrderNo = rowCount;

            order.UserName = currentUserDetails.FirstName;

            order.PhoneNo = currentUserDetails.PhoneNumber;

            _context.Update(order);
            await _context.SaveChangesAsync();

            return order;
        }


        [HttpGet]
        public async Task<object> OrderList()
        {
            var ordrLst = await _context.OrderShops.Include(_ => _.User).ToListAsync();
            return ordrLst;
        }


        [HttpGet("{id}")]
        public async Task<object> OrderListCustomer([FromRoute] string id)
        {
            var ordrLst = await _context.OrderShops
                                .Where(_ => _.User.Id == id)
                                .ToListAsync();

            return ordrLst;
        }


        [HttpGet("{id}")]
        public async Task<object> OrderDetails([FromRoute] int id)
        {

            var products = await _context
                            .InstrumentOrderDetails
                            .Where(_ => _.OrderShopId == id)
                            .Select(p => p.Instrument)
                            .Include(_ => _.InstrumentCategory)
                            .ToListAsync();

            return products;
        }
    }
}
