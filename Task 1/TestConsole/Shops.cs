using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole;

public enum ShopsTypes
{
    Shop1,
    Shop2,
    Shop3,
}
public class Shops
{
    public int ID { get; set; }
    public ShopsTypes Type { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Count { get; set; }

    //public Shops(int ID, ShopsTypes Type, string Name, double Price, int Count)
    //{
    //    this.ID = ID;
    //    this.Name = Name;
    //    this.Price = Price;
    //    this.Count = Count;
    //    this.Type = Type;
    //}

    public Shops(Shops1 shop1)
    {
        this.ID = shop1.ID;
        this.Name = shop1.Name_Product;
        this.Price = shop1.Price;
        this.Count = shop1.Count_On_Storage;
        this.Type = ShopsTypes.Shop1;
    }

    public Shops(Shops2 shop2)
    {
        this.ID = ID++;
        this.Name = shop2.Product_Name;
        this.Price = shop2.Price;
        this.Count = shop2.Kolich;
        this.Type = ShopsTypes.Shop2;
    }

    public Shops(Shops3 shop3)
    {
        this.ID = shop3.ID;
        this.Name = shop3.Product;
        this.Price = shop3.Cena;
        this.Count = shop3.Count_On_Storage;
        this.Type = ShopsTypes.Shop3;
    }

}
