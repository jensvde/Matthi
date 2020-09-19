using System.Collections;
using System.Collections.Generic;
using Domain;

namespace DAL
{
    public interface IProductRepository
    {
        Product CreateProduct(Product product);
        Product ReadProduct(int productId);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        IEnumerable<Product> ReadProducts();
        
        Allergie CreateAllergie(Allergie allergie);
        Allergie ReadAllergie(int allergieId);
        void DeleteAllergie(Allergie allergie);
        void UpdateAllergie(Allergie allergie);
        IEnumerable<Allergie> ReadAllergies();
    }
}