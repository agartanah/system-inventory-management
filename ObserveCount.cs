using System;

namespace system_inventory_management {
  public class ObserveCount : IObserver {
    public void Update(string ProductName) {
      Console.WriteLine($"На складе количество товара {ProductName} меньше порога!!!");
    }
  }

  public interface IObserver {
    void Update(string ProductName);
  }
}
