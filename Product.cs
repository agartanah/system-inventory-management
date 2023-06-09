using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_inventory_management {
  public interface IProduct {
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(string ProductName);
  }

  public class Product : IProduct {
    private List<IObserver> observers { get; set; } = new List<IObserver>();

    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public double Price { get; set; }
    private int count;
    public int Count {
      get {
        return count;
      }
      set {
        count = value;
        if (count <= StockingThreshold) {
          Notify(Name);
        }
      }
    }
    public int StockingThreshold { get; set; }
    public bool Сhanged = false;

    public Product() { }

    public override string ToString() {
      string ProductString;
      ProductString = $"Name: {Name}\nManufacturer: {Manufacturer}\nPrice: {Price}\nCount: {Count}\nStocking Threshold: {StockingThreshold}";
      
      return ProductString;
    }

    public void Attach(IObserver observer) {
      observers.Add(observer);
    }

    public void Detach(IObserver observer) {
      observers.Remove(observer);
    }

    public void Notify(string ProductName) {
      foreach (IObserver observer in observers) {
        observer.Update(ProductName);
      }
    }
  }
}
