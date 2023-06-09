using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_inventory_management {
  public class Product {
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public double Price { get; set; }
    public int Count { get; set; }
    public int StockingThreshold { get; set; }
    public bool Сhanged = false;

    public Product() { }

    public override string ToString() {
      string ProductString;
      ProductString = $"Name: {Name}\nManufacturer: {Manufacturer}\nPrice: {Price}\nCount: {Count}\nStocking Threshold: {StockingThreshold}";
      
      return ProductString;
    }

  }
}
