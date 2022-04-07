using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole;

public class Shops1
{
    public int ID { get; set; }
    public string Name_Product { get; set; }
    public double Price { get; set; }
    public int Count_On_Storage { get; set; }

    public Shops1(string Name_Product, double Price, int Count_On_Storage)
    {
        this.ID = ID++;
        this.Name_Product = Name_Product;
        this.Price = Price;
        this.Count_On_Storage = Count_On_Storage;
    }

    public Shops1(Shops shop)
    {
        this.ID = shop.ID;
        this.Name_Product = shop.Name;
        this.Price = shop.Price;
        this.Count_On_Storage = shop.Count;
    }

}