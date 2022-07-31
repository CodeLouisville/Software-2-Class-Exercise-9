using PetStore.Logic;
using PetStore.Models;
using PetStore.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    internal class ProductLogic : IProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeash;
        private Dictionary<string, CatFood> _catFood;

        public ProductLogic()
        {
            _products = new List<Product>
            {
                new DogLeash
                {
                    Description = "A rope dog leash made from strong rope.",
                    LengthInches = 60,
                    Material = "Rope",
                    Name = "Rope Dog Leash",
                    Price = 21.00m,
                    Quantity = 0
                },
                new DryCatFood
                {
                    Quantity = 6,
                    Price = 25.59m,
                    Name = "Plain 'Ol Cat Food",
                    Description = "Nothing fancy to find here.  Just the basic stuff your cat needs to live a healthy life",
                    WeightPounds = 10,
                    KittenFood = false
                },
                new CatFood
                {
                    Quantity = 48,
                    Price = 12.99m,
                    Name = "Fancy Cat Food",
                    Description = "Food that isn't only delicious, but made from the finest of all cat food stuff",
                    KittenFood = false
                }
            };
            _dogLeash = new Dictionary<string, DogLeash>();
            _catFood = new Dictionary<string, CatFood>();
        }

        public void AddProduct(Product product)
        {
            if (product is DogLeash)
            {
                var validator = new DogLeashValidator();
                if (validator.Validate(product as DogLeash).IsValid)
                {
                    _dogLeash.Add(product.Name, product as DogLeash);
                }
                else
                {
                    throw new ValidationException("The dog leash product isn't valid");
                }
                
            }
            if (product is CatFood)
            {
                _catFood.Add(product.Name, product as CatFood);
            }
            _products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public T GetProductByName<T>(string name) where T : Product
        {
            try
            {
                if (typeof(T) == typeof(DogLeash))
                {
                    return _dogLeash[name] as T;
                }
                else if (typeof(T) == typeof(CatFood))
                {
                    return _catFood[name] as T;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetOnlyInStockProducts()
        {
            return _products.InStock().Select(x=>x.Name).ToList();
        }

        public decimal GetTotalPriceOfInventory()
        {
            return _products.InStock().Select(x => x.Price).Sum();
        }
    }
}
