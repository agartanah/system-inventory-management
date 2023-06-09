using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace system_inventory_management {
  public class Stock {
    public List<Product> Products { get; set; } = new List<Product>();

    public Stock() {
      string ProductsFileContent = File.ReadAllText(@"C:\Users\vyati\source\repos\system-inventory-management\products.txt");

      string[] ProductsArray = ProductsFileContent.Split('\n');

      for (int ProductIndex = 0; ProductIndex < ProductsArray.Length; ++ProductIndex) {
        string[] ProductInfo = ProductsArray[ProductIndex].Split('~');
        
        if (ProductInfo.Length < 5) {
          continue;
        }

        string ProductName = ProductInfo[0], Manufacturer = ProductInfo[1];
        double Price = double.Parse(ProductInfo[2]);
        int Count = int.Parse(ProductInfo[3]), StockingThreshold = int.Parse(ProductInfo[4]);

        Product ProductObj = new Product {
          Name = ProductName,
          Manufacturer = Manufacturer,
          Price = Price,
          Count = Count,
          StockingThreshold = StockingThreshold
        };

        Products.Add(ProductObj);
      }
    }

    public Product FindProduct(string ProductName) {
      foreach (Product Product in Products) {
        if (Product.Name == ProductName) {
          return Product;
        }
      }
      return null;
    }

    public bool SyncProducts() {
      File.WriteAllText(@"C:\Users\vyati\source\repos\system-inventory-management\products.txt", Parse());

      return true;
    }

    public string Parse() {
      string ParseProducts = string.Empty;

      foreach (var Product in Products) { 
        ParseProducts += Product.Name + "~" + Product.Manufacturer + "~" +
          Product.Price + "~" + Product.Count + "~" + Product.StockingThreshold + "\n";
      }

      return ParseProducts;
    }

    public override string ToString() {
      string StockString = string.Empty;

      foreach (var Product in Products) {
        StockString += Product.ToString() + "\n\n";
      }

      return StockString;
    }
  }
}
