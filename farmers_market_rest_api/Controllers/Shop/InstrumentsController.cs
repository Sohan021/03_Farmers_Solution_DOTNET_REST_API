using farmers_market_rest_api.Domain.IService.Shop;
using farmers_market_rest_api.Domain.Models.Shop;
using farmers_market_rest_api.Persistence.Context;
using farmers_market_rest_api.Service.Resources.Shop;
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

namespace farmers_market_rest_api.Controllers.Shop
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InstrumentsController : ControllerBase
    {
        private readonly IInstrumentService _productService;
        private IHostingEnvironment _env;
        private AppDbContext _context;

        public InstrumentsController(AppDbContext context,
                                  IInstrumentService productService,
                                  IHostingEnvironment env

                                  )
        {

            _productService = productService;
            _env = env;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Instrument>> GetAllAsync()
        {
            var products = await _productService.ListAsync();

            return products;
            //var products = await _context.Products

            //    .Include(_ => _.Category)
            //    .Include(_ => _.SubCategory)
            //    .ToListAsync();

            //return products;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(int id)
        {
            var product = await _productService.FindByIdAsync(id);
            return Ok(product);

        }



        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetInstrumentsByCategory([FromRoute]int categoryId)
        {
            var products = await _context.Instruments
                .Where(_ => _.InstrumentCategoryId == categoryId)
                .Include(_ => _.InstrumentCategory)
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
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync(InstrumentResource product)
        {
            var cat = _context.InstrumentCategories.Where(_ => _.Id == product.InstrumentCategoryId).FirstOrDefault(_ => _.Id == product.InstrumentCategoryId);

            var C = _context.InstrumentCategories.ToList();
            var webRoot = _env.WebRootPath;
            var PathWithFolderName = Path.Combine(webRoot, "Image");

            var productt = new Instrument
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ImageUrl1 = product.ImageUrl1,
                ImageUrl2 = product.ImageUrl2,
                Description = product.Description,
                InstrumentCategoryId = cat.Id,
                InstrumentCategory = cat,

            };
            //_context.Products.Add(productt);
            //_context.SaveChanges();
            var result = await _productService.SaveAsync(productt);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            return Ok(productt);




        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, InstrumentResource resource)
        {

            //var webRoot = _env.WebRootPath;
            //var PathWithFolderName = System.IO.Path.Combine(webRoot, "Image");
            //var item = resource.File;

            //var imageUrl = ImageUrl(item);

            var cat = _context.InstrumentCategories.Where(_ => _.Id == resource.InstrumentCategoryId).FirstOrDefault();

            var webRoot = _env.WebRootPath;
            var PathWithFolderName = Path.Combine(webRoot, "Image");

            var product = new Instrument
            {
                Name = resource.Name,
                Price = resource.Price,
                Quantity = resource.Quantity,
                UpdatedAt = DateTime.Now,
                ImageUrl1 = resource.ImageUrl1,
                ImageUrl2 = resource.ImageUrl2,
                Description = resource.Description,
                InstrumentCategoryId = resource.InstrumentCategoryId,


            };


            var result = await _productService.UpdateAsync(id, product);


            if (!result.Success)
                return BadRequest(result.Message);



            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
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
