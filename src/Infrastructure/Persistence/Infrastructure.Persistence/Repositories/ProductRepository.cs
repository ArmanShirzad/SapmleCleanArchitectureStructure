using Ardalis.Result;

using Core.Domain.Contracts.Repositories;
using Core.Domain.Entities;

using Infrastructure.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Net.Mime.MediaTypeNames;

namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product model)
        {
            await _context.Products.AddAsync(model);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product!= null)
            {
                 _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("couldnt find product to remove, sorry");
            }
        }
          

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            //eager loading, later we can load media and comments separtly and switch to lazy loading
            //var products = await _context.Products
            //   .Include(p => p.Images)
            //   .Include(p => p.Comments)
            //   .ToListAsync();
            var products = Enumerable.Empty<Product>();
            try
            {
                if (!await _context.Products.AsNoTracking().AnyAsync())
                    return Enumerable.Empty<Product>();
                products = await _context.Products
                    .Include(p => p.Images)
                    .Include(p => p.Comments)
                    .ToListAsync();
                return products;
            }
            catch (Exception)
            {
                return products;
                throw new Exception("an exception occured haha");
            }
            
    
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products
                .Include(p=> p.Images)
                .Include(p=> p.Comments).FirstOrDefaultAsync(p=> p.Id == id);
            return product != null ? product : throw new Exception($"Product with ID {id} not found.");

        }
        public async Task UpdateProduct(Product model)
        {

            _context.Products.Update(model);
            await _context.SaveChangesAsync();
            
        }
        #region Image Gallery
        public async Task AddProductImageAsync(ProductImage image)
        {
            _context.ProductImages.Add(image);
            await _context.SaveChangesAsync();
        }



        public async Task DeleteProductImageAsync(int productId, int imageId)
        {
            var image = await _context.ProductImages.FirstOrDefaultAsync(p => p.ProductId == productId && p.Id == imageId);
            if (image != null)
            {
                _context.ProductImages.Remove(image);
                await _context.SaveChangesAsync();

            }

        }
        #endregion

    }
}
