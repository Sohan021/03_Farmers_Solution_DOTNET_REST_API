using farmers_market_rest_api.Domain.IRepository.Shop;
using farmers_market_rest_api.Domain.IService.Shop;
using farmers_market_rest_api.Domain.Models.Shop;
using farmers_market_rest_api.Domain.Services.Communication;
using farmers_market_rest_api.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmers_market_rest_api.Service.Shop
{
    public class InstrumentService : IInstrumentService
    {
        private readonly IInstrumentRepository _productRepository;
        private readonly AppDbContext _context;


        public InstrumentService(IInstrumentRepository productRepository, AppDbContext context)
        {
            _productRepository = productRepository;
            _context = context;

        }

        public async Task<IEnumerable<Instrument>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }


        public async Task<SaveInstrumentResponse> SaveAsync(Instrument product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _context.SaveChangesAsync();

                return new SaveInstrumentResponse(product);
            }
            catch (Exception ex)
            {
                return new SaveInstrumentResponse($"An error occurred when saving the Product: {ex.Message}");
            }
        }

        public async Task<SaveInstrumentResponse> UpdateAsync(int id, Instrument product)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);

            if (existingProduct == null)
                return new SaveInstrumentResponse("Product not found.");
            var cat = _context.InstrumentCategories.Where(_ => _.Id == product.InstrumentCategoryId).FirstOrDefault();



            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.ImageUrl1 = product.ImageUrl1;
            existingProduct.ImageUrl2 = product.ImageUrl2;
            existingProduct.InstrumentCategory = cat;

            try
            {
                _productRepository.Update(existingProduct);
                await _context.SaveChangesAsync();


                return new SaveInstrumentResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new SaveInstrumentResponse($"An error occurred when updating the Product: {ex.Message}");
            }
        }

        public async Task<SaveInstrumentResponse> DeleteAsync(int id)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);


            if (existingProduct == null)
                return new SaveInstrumentResponse("Product not found.");


            try
            {
                _productRepository.Remove(existingProduct);
                await _context.SaveChangesAsync();



                return new SaveInstrumentResponse(existingProduct);
            }
            catch (Exception ex)
            {

                return new SaveInstrumentResponse($"An error occurred when deleting the Product: {ex.Message}");
            }
        }

        public async Task<Instrument> FindByIdAsync(int id)
        {
            return await _productRepository.FindByIdAsync(id);
        }
    }
}
