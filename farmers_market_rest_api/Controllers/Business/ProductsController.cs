using farmers_market_rest_api.Domain.Models.Business;
using farmers_market_rest_api.Persistence.Context;
using farmers_market_rest_api.Service.Resources.Business;
using farmers_market_rest_api.Service.Resources.User;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Controllers.Business
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IHostingEnvironment _env;
        private AppDbContext _context;

        public ProductsController(AppDbContext context, IHostingEnvironment env)
        {
            _env = env;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Products.Include(_ => _.Category).ToListAsync();

            return Ok(products);
        }

        [HttpGet("{cid}")]
        public async Task<IActionResult> MyProductGallery(string cid)
        {
            var products = await _context.Products.Where(_ => _.Farmer.Id == cid).Include(_ => _.Category).ToListAsync();

            return Ok(products);
        }

        [HttpGet("{mcode}")]
        public async Task<IActionResult> FindProductByMarket(string mcode)
        {
            var products = await _context.Products.Where(_ => _.MarketCode == mcode).Include(_ => _.Category).Include(_ => _.Farmer).ToListAsync();

            return Ok(products);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var product = await _context.Products.Where(_ => _.Id == id).Include(_ => _.Category).Include(_ => _.Farmer).FirstOrDefaultAsync(_ => _.Id == id);
            return Ok(product);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByMarket(int id)
        {
            var product = await _context.Products.Where(_ => _.MarketId == id).ToListAsync();
            return Ok(product);
        }

        [HttpGet("{districtId}/{upozilaId}/{unionId}/{marketId}")]
        public async Task<IActionResult> GetProductByArea([FromRoute] int districtId, [FromRoute]int upozilaId, [FromRoute]int unionId, [FromRoute]int marketId)
        {
            var products = await _context.Products
                                .Where(_ => _.DistrictId == districtId)
                                .Where(_ => _.UpozilaId == upozilaId)
                                .Where(_ => _.UnionOrWardId == unionId)
                                .Where(_ => _.MarketId == marketId)
                                .ToListAsync();
            return Ok(products);
        }



        [HttpPost, DisableRequestSizeLimit]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> SavePhoto()
        {
            var files = Request.Form.Files as List<IFormFile>;
            string imageUrl = ImageUrl(files[0]);
            return Ok(await Task.FromResult(imageUrl));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(ProductResource product)
        {
            var cuserId = product.currentuser;

            var cuser = _context.ApplicationUsers.Where(_ => _.Id == cuserId).FirstOrDefault();

            var cat = _context.Categories.Where(_ => _.Id == product.CategoryId).FirstOrDefault();
            var dis = _context.Districts.Where(_ => _.Id == cuser.DistrictId).FirstOrDefault();
            var upo = _context.Upozillas.Where(_ => _.Id == cuser.UpozilaId).FirstOrDefault();
            var uni = _context.UnionOrWards.Where(_ => _.Id == cuser.UnionOrWardId).FirstOrDefault();
            var mar = _context.Markets.Where(_ => _.Id == cuser.MarketId).FirstOrDefault();

            var webRoot = _env.WebRootPath;
            var PathWithFolderName = Path.Combine(webRoot, "Image");

            var productt = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ImageUrl1 = product.ImageUrl1,
                ImageUrl2 = product.ImageUrl2,
                Description = product.Description,
                Category = cat,
                District = dis,
                Upozilla = upo,
                UnionOrWard = uni,
                Market = mar,
                Farmer = cuser,
                MarketCode = mar.MarketCode

            };
            await _context.Products.AddAsync(productt);
            await _context.SaveChangesAsync();


            return Ok(productt);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, ProductResource productResource)
        {

            var product = _context.Products.Where(_ => _.Id == id).FirstOrDefault();
            var cat = _context.Categories.Where(_ => _.Id == product.CategoryId).FirstOrDefault();
            var dis = _context.Districts.Where(_ => _.Id == product.DistrictId).FirstOrDefault();
            var upo = _context.Upozillas.Where(_ => _.Id == product.UpozilaId).FirstOrDefault();
            var uni = _context.UnionOrWards.Where(_ => _.Id == product.UnionOrWardId).FirstOrDefault();
            var mar = _context.Markets.Where(_ => _.Id == product.MarketId).FirstOrDefault();


            var webRoot = _env.WebRootPath;
            var PathWithFolderName = Path.Combine(webRoot, "Image");


            product.Name = product.Name;
            product.Price = product.Price;
            product.Quantity = product.Quantity;
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;
            product.ImageUrl1 = product.ImageUrl1;
            product.ImageUrl2 = product.ImageUrl2;
            product.Description = product.Description;
            product.Category = cat;
            product.Category = cat;
            product.District = dis;
            product.Upozilla = upo;
            product.UnionOrWard = uni;
            product.Market = mar;

            _context.Update(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsycn(int id)
        {

            var subCat = _context.Categories.Where(_ => _.Id == id).FirstOrDefault();

            _context.Remove(subCat);
            await _context.SaveChangesAsync();

            return Ok(subCat);
        }
        public string ImageUrl(IFormFile file)
        {


            if (file == null || file.Length == 0) return null;
            string extension = Path.GetExtension(file.FileName);

            string path_Root = _env.WebRootPath;

            string path_to_Images = path_Root + "\\Image\\" + file.FileName;

            using (var stream = new FileStream(path_to_Images, FileMode.Create))
            {

                file.CopyTo(stream);
                string revUrl = Reverse.reverse(path_to_Images);
                int count = 0;
                int flag = 0;

                for (int i = 0; i < revUrl.Length; i++)
                {
                    if (revUrl[i] == '\\')
                    {
                        count++;

                    }
                    if (count == 2)
                    {
                        flag = i;
                        break;
                    }
                }

                string sub = revUrl.Substring(0, flag + 1);
                string finalString = Reverse.reverse(sub);

                string f = finalString.Replace("\\", "/");
                return f;

            }


        }
    }

    public static class Reverse
    {
        public static string reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
