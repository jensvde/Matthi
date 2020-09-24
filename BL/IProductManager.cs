using System.Collections.Generic;
using Domain;

namespace BL
{
    public interface IProductManager
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Allergie> GetAllergies();
        IEnumerable<OpeningsUur> GetOpeningstijden();
        IEnumerable<Vakantie> GetVakanties();
        Product AddProduct(Product product);
        Allergie AddAllergie(Allergie allergie);
        Product GetProduct(int productId);
        Allergie GetAllergie(int allergieId);
        void ChangeProduct(Product product);
        void ChangeAllergie(Allergie allergie);
        void DeleteProduct(Product product);
        void DeleteAllergie(Allergie allergie);
    }
}