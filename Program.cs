using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace system_inventory_management {
  class Program {
    static void Menu() {
      Stock StockObj = new Stock();
      ObserveCount ObserverCount = new ObserveCount();

      Console.WriteLine("\n" + StockObj.ToString() + "\n");

      Console.Write("Выберите один из пунктов: \n\t1. Добавить новый товар\n\t2. Работать с существующими" +
        "\nВведите желаемый пункт: ");
      int Choice = int.Parse(Console.ReadLine());

      if (Choice == 1) {
        Product NewProduct = new Product();

        Console.Write("Введите имя нового товара: ");
        string Name = Console.ReadLine();
        NewProduct.Name = Name;

        Console.Write("Введите производителя нового товара: ");
        string Manufacturer = Console.ReadLine();
        NewProduct.Manufacturer = Manufacturer;

        Console.Write("Введите цену нового товара: ");
        double Price = double.Parse(Console.ReadLine());
        NewProduct.Price = Price;

        Console.Write("Введите имя нового товара: ");
        int Count = int.Parse(Console.ReadLine());
        NewProduct.Count = Count;

        Console.Write("Введите имя нового товара: ");
        int StockingThreshold = int.Parse(Console.ReadLine());
        NewProduct.StockingThreshold = StockingThreshold;

        StockObj.Products.Add(NewProduct);

        StockObj.SyncProducts();

        Menu();
      }

      Console.Write("Введите имя товара: ");
      string ProductName = Console.ReadLine();

      Product UserProduct = StockObj.FindProduct(ProductName);

      if (UserProduct == null) {
        Console.WriteLine("Такой продукт не найден! Попробуйте ещё раз!");

        Menu();
      }

      UserProduct.Attach(ObserverCount);

      Console.Write("\nВыбирите один из пунктов: \n\t1. Добавить на склад\n\t2. Убрать со склада\n\t" +
        "3. Обновить информацию о складе\nВведите один из пунктов: ");
      int UserChoice = int.Parse(Console.ReadLine());

      switch (UserChoice) {
        case 1:
          Console.Write("Введите кол-во товара, которое хотите добавить: ");
          int CountAdd = int.Parse(Console.ReadLine());

          UserProduct.Count += CountAdd;
          UserProduct.Сhanged = true;

          StockObj.SyncProducts();

          Menu();
          break;
        case 2:
          Console.Write("Введите кол-во товара, которое хотите убавить: ");
          int Discount = int.Parse(Console.ReadLine());

          UserProduct.Count -= Discount;
          UserProduct.Сhanged = true;

          StockObj.SyncProducts();

          Menu();
          break;
        case 3:
          StockObj.SyncProducts();

          Console.WriteLine(StockObj.ToString());

          Menu();
          break;
        default:
          Console.WriteLine("Такого пункта не существует! Попробуйте заново!");

          Menu();
          break;
      }
    }
    
    static void Main(string[] args) {
      Menu();

      Console.ReadKey();
    }
  }
}
