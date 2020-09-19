using System.Collections.Generic;
using DAL;
using DAL.EF;
using Domain;

namespace BL
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository repo;

        public ProductManager()
        {
            repo = new ProductRepository();
        }
        public IEnumerable<Product> GetProducts()
        {
            return repo.ReadProducts();
        }

        public IEnumerable<Allergie> GetAllergies()
        {
            return repo.ReadAllergies();
        }

        public Product AddProduct(Product product)
        {
            return repo.CreateProduct(product);
        }

        public Allergie AddAllergie(Allergie allergie)
        {
            return repo.CreateAllergie(allergie);
        }

        public Product GetProduct(int productId)
        {
            return repo.ReadProduct(productId);
        }

        public Allergie GetAllergie(int allergieId)
        {
            return repo.ReadAllergie(allergieId);
        }

        public void ChangeProduct(Product product)
        {
            repo.UpdateProduct(product);
        }

        public void ChangeAllergie(Allergie allergie)
        {
            repo.UpdateAllergie(allergie);
        }

        public void DeleteProduct(Product product)
        {
            repo.DeleteProduct(product);
        }

        public void DeleteAllergie(Allergie allergie)
        {
            repo.DeleteAllergie(allergie);
        }
    }
}