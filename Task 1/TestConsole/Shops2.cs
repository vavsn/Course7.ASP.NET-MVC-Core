using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole;

public class Shops2
{
    public string Product_Name { get; set; }
    public double Price { get; set; }
    public int Kolich { get; set; }

    public Shops2(Shops shop)
    {
        this.Product_Name = shop.Name;
        this.Price = shop.Price;
        this.Kolich = shop.Count;
    }


}