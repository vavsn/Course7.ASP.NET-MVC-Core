using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole;

public class Shops3
{
    public int ID { get; set; }
    public string Product { get; set; }
    public int Count_On_Storage { get; set; }
    public double Cena { get; set; }

    public Shops3(Shops shop)
    {
        this.ID = shop.ID;
        this.Product = shop.Name;
        this.Cena = shop.Price;
        this.Count_On_Storage = shop.Count;
    }
}