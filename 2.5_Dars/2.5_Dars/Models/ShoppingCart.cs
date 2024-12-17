using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Dars.Models;

public class ShoppingCart
{

    private  List<Product> products;

    public ShoppingCart()
    {
        products = new List<Product>();
    }

    public void AddToCart(Product product)
    {
        products.Add(product);
        var num = 0;
    }

    public double CommonPrice()
    {
        double commonPrice = 0;

        foreach(var product in products)
        {
            commonPrice += product.Price;
        }
        return commonPrice;
    }
}
