using System;

      MakeupProduct lipstick = new MakeupProduct("Glossy Lipstick", "Lipstick", 799m, "Rom&nd", true, 50);
      MakeupProduct foundation = new MakeupProduct("Liquid Foundation", "Foundation", 2500m, "Chanel", true);
      MakeupProduct eyeshadow = new MakeupProduct("Eyeshadow Palette", "Eyeshadow", 3000m, "James Charles");

      Console.WriteLine("Lipstick Information: ");
      lipstick.DisplayProductInformation();
      Console.WriteLine("\nFoundation Information: ");
      foundation.DisplayProductInformation();
      Console.WriteLine("\nEyeshadow Information: ");
      eyeshadow.DisplayProductInformation();

      lipstick.UpdateStockQuantity(19);
      foundation.UpdateStockQuantity(22);

      Console.WriteLine($"\n Can I afford to buy the lipstick {(lipstick.IsAffordable() ? "Yes" : "No")}");
      Console.WriteLine($"\n Can I afford to buy the lipstick {(eyeshadow.IsAffordable() ? "Yes" : "No")}");
  
  public class MakeupProduct
  {
    public string ProductName {get; set; }
    public string ProductType {get; set; }
    public decimal ProductPrice {get; set; }

    private string Brand {get; set; }
    private bool IsInStock {get; set; }
    private int StockQuantity {get; set; }

    public MakeupProduct(string name, string type, decimal price, string brand, bool inStock, int stockQuantity)
    {
      ProductName = name;
      ProductType = type;
      ProductPrice = price;
      Brand = brand;
      IsInStock = inStock;
      StockQuantity = stockQuantity;
    }

    public MakeupProduct(string name, string type, decimal price, string brand, bool inStock)
    {
      ProductName = name;
      ProductType = type;
      ProductPrice = price;
      Brand = brand;
      IsInStock = inStock;
      StockQuantity = 0;
    }

    public MakeupProduct(string name, string type, decimal price, string brand)
    {
      ProductName = name;
      ProductType = type;
      ProductPrice = price;
      Brand = brand;
      IsInStock = true;
      StockQuantity = 0;
    }

    public void DisplayProductInformation()
    {
      Console.WriteLine($"Product Name: {ProductName}");
      Console.WriteLine($"Type: {ProductType}");
      Console.WriteLine($"Price: {ProductPrice}");
      Console.WriteLine($"Brand: {Brand}");
      Console.WriteLine($"In stock: {(IsInStock ? "Yes" : "No" )}");
      Console.WriteLine($"Stock Quantity: {StockQuantity}");
    }

    public void UpdateStockQuantity (int newQuantity)
    {
      StockQuantity = newQuantity;
      Console.WriteLine($"Stock quantity of {ProductName} update to {StockQuantity}.");

    }

    public bool IsAffordable()
    {
      if (!IsInStock)
      {
          Console.WriteLine("$Sorry, {ProductName} is out of stock. ");
          return false;
      }

      decimal userBudget = GetUserBudget();
      return ProductPrice <= userBudget;
    }

    private decimal GetUserBudget()
    {
      return 70.00m;
  
    }
    }
