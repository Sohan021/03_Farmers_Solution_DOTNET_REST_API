using farmers_market_rest_api.Domain.Models.Business;
using farmers_market_rest_api.Domain.Models.User;
using farmers_market_rest_api.Persistence.Context;
using farmers_market_rest_api.Service.Resources.Shop;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Controllers.Business
{
    [Route("api/[controller]/[action]")]
    public class OrdersController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        private readonly AppDbContext _context;

        public OrdersController(SignInManager<ApplicationUser> signInManager,
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
        public async Task<object> Checkout([FromBody]BusinessCheckOutResource checkOut)
        {
            var CurrentUserId = checkOut.CurrentUserId;

            var currentUserDetails = _userManager.Users.Where(_ => _.Id == CurrentUserId).FirstOrDefault();

            List<Product> products = checkOut.Products;

            Order order = new Order();

            order.HoleSellerId = CurrentUserId;
            order.HoleSellerName = currentUserDetails.FirstName;
            order.HoleSellerPhoneNo = currentUserDetails.UserName;
            order.TotalAmount = checkOut.Amount;

            _context.Add(order);

            _context.SaveChanges();


            var horder = _context.Orders.Where(_ => _.Id == order.Id).FirstOrDefault();


            if (products != null)
            {
                foreach (var product in products)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.OrderId = order.Id;
                    orderDetails.ProductId = product.Id;

                    _context.Add(orderDetails);
                    await _context.SaveChangesAsync();

                }

            }

            var rowCount = _context.Orders.Count() + 1;

            order.OrderNo = rowCount;

            //order.UserName = currentUserDetails.FirstName;

            //order.PhoneNo = currentUserDetails.PhoneNumber;


            var address = await _context.Markets
                          .Where(_ => _.Id == currentUserDetails.MarketId)
                          .Include(_ => _.UnionOrWard)
                          .ThenInclude(_ => _.Upozila)
                          .ThenInclude(_ => _.District)
                          .ThenInclude(_ => _.Division)
                          .FirstOrDefaultAsync();






            _context.Update(order);
            await _context.SaveChangesAsync();



            return (order);
        }


        [HttpGet]
        public async Task<object> OrderList()
        {
            var ordrLst = await _context.Orders
                                .Include(_ => _.Holeseller).ToListAsync();

            return ordrLst;
        }


        [HttpGet("{id}")]
        public async Task<object> OrderListWholeSeller([FromRoute] string id)
        {
            var ordrLst = await _context.Orders
                                .Where(_ => _.Holeseller.Id == id)
                                .Include(_ => _.Holeseller)
                                .ToListAsync();

            return ordrLst;
        }


        [HttpGet("{id}")]
        public async Task<object> OrderListFarmer([FromRoute] string id)
        {
            var ordrLst = await _context
                                .OrderDetails
                                .Where(_ => _.Product.Farmer.Id == id)
                                .Select(p => p.Product)
                                .Include(_ => _.Category)
                                .Include(_ => _.Farmer)
                                .ToListAsync();

            return ordrLst;
        }




        [HttpGet("{id}")]
        public async Task<object> OrderDetails([FromRoute] int id)
        {

            var products = await _context
                            .OrderDetails
                            .Where(_ => _.OrderId == id)
                            .Select(p => p.Product)
                            .Include(_ => _.Category)
                            .Include(_ => _.Farmer)
                            .ToListAsync();

            return products;
        }

    }
}
