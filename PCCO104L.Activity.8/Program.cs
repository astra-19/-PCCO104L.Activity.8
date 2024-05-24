using System;

      MakeupProduct lipstick = new LipProduct("Glossy Lipstick", 799m, "Rom&nd", true, 50, "Glossy");
      MakeupProduct foundation = new LiquidFoundation("Liquid Foundation", 2500m, "Chanel", true, "Full Coverage");
      MakeupProduct eyeshadow = new Eyeshadow("Eyeshadow Palette", 3000m, "James Charles", true, 20, "Rainbow");
      LipProduct redLipstick = new LipProduct("Red Lipstick", 799m, "Rom&nd", true, 50, "Midnight");
      Eyeshadow blueEyeshadow = new Eyeshadow("Blue Eyeshadow", 3000m, "ColourPop", true, 30, "Blue");
      MatteFoundation matteFoundation = new MatteFoundation("Matte Foundation", 450m, "Maybelline", true, "Tan", 30);
      LuxuryLipProduct luxuryLipstick = new LuxuryLipProduct("Luxury Lipstick", 2035m, "Charlotte Tilbury", true, true, "Cinematic Red");
      LuxuryDrugstoreLipProduct luxuryDrugstoreLipstick = new LuxuryDrugstoreLipProduct("Luxury Drugstore Lipstick", 2435m, "Yves Saint Laurent", true, true, true, "101 - Rouge Muse");

      Console.WriteLine("Lipstick Information: ");
      lipstick.DisplayProductInformation();

      Console.WriteLine("\nFoundation Information: ");
      foundation.DisplayProductInformation();

      Console.WriteLine("\nEyeshadow Information: ");
      eyeshadow.DisplayProductInformation();

      Console.WriteLine("\nRed Lipstick Information: ");
      redLipstick.DisplayProductInformation();

      Console.WriteLine("\nBlue Eyeshadow Information: ");
      blueEyeshadow.DisplayProductInformation();

      Console.WriteLine("\nMatte Foundation Information: ");
      matteFoundation.DisplayProductInformation();

      Console.WriteLine("\nLuxury Lipstick Information: ");
      luxuryLipstick.DisplayProductInformation();

      Console.WriteLine("\nLuxury Drugstore Lipstick Information: ");
      luxuryDrugstoreLipstick.DisplayProductInformation();

      lipstick.UpdateStockQuantity(19);
      foundation.UpdateStockQuantity(22);

      Console.WriteLine($"\nCan I afford to buy the lipstick? {(lipstick.IsAffordable() ? "Yes" : "No")}");
      Console.WriteLine($"\nCan I afford to buy the eyeshadow? {(eyeshadow.IsAffordable() ? "Yes" : "No")}");
  public abstract class MakeupProduct
  {
        public string ProductName { get; protected set; }
        public string ProductType { get; protected set; }
        public decimal ProductPrice { get; protected set; }

        protected string Brand { get; set; }
        protected bool IsInStock { get; set; }
        protected int StockQuantity { get; set; }

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

        public virtual void DisplayProductInformation()
        {
            Console.WriteLine($"Product Name: {ProductName}");
            Console.WriteLine($"Type: {ProductType}");
            Console.WriteLine($"Price: {ProductPrice}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"In stock: {(IsInStock ? "Yes" : "No")}");
            Console.WriteLine($"Stock Quantity: {StockQuantity}");
        }

        public void UpdateStockQuantity(int newQuantity)
        {
            StockQuantity = newQuantity;
            Console.WriteLine($"Stock quantity of {ProductName} updated to {StockQuantity}.");
        }

        public bool IsAffordable()
        {
            if (!IsInStock)
            {
                Console.WriteLine($"Sorry, {ProductName} is out of stock.");
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

 
    public class LipProduct : MakeupProduct
    {
        public string Shade { get; private set; }

        public LipProduct(string name, decimal price, string brand, bool inStock, int stockQuantity, string shade)
            : base(name, "Lip Product", price, brand, inStock, stockQuantity)
        {
            Shade = shade;
        }

        public new void DisplayProductInformation()
        {
            base.DisplayProductInformation();
            Console.WriteLine($"Shade: {Shade}");
        }
    }

    public class Eyeshadow : MakeupProduct
    {
        public string Color { get; private set; }

        public Eyeshadow(string name, decimal price, string brand, bool inStock, int stockQuantity, string color)
            : base(name, "Eyeshadow", price, brand, inStock, stockQuantity)
        {
            Color = color;
        }

        public new void DisplayProductInformation()
        {
            base.DisplayProductInformation();
            Console.WriteLine($"Color: {Color}");
        }
    }

    public class LiquidFoundation : MakeupProduct
    {
        public string Coverage { get; private set; }

        public LiquidFoundation(string name, decimal price, string brand, bool inStock, string coverage)
            : base(name, "Foundation", price, brand, inStock)
        {
            Coverage = coverage;
        }

        public new void DisplayProductInformation()
        {
            base.DisplayProductInformation();
            Console.WriteLine($"Coverage: {Coverage}");
        }
    }

    public class MatteFoundation : LiquidFoundation
    {
        public int matte { get; private set; }

        public MatteFoundation(string name, decimal price, string brand, bool inStock, string coverage, int matte)
            : base(name, price, brand, inStock, coverage)
        {
            matte = matte;
        }

        public new void DisplayProductInformation()
        {
            base.DisplayProductInformation();
            Console.WriteLine($"Matte: {matte}");
        }
    }

    // Interface for multilevel inheritance via interface
    public interface CheapProduct
    {
        bool IsLuxury { get; set; }
        void DisplayLuxuryStatus();
    }

    public class LuxuryMakeupProduct : MakeupProduct, CheapProduct
    {
        public bool IsLuxury { get; set; }

        public LuxuryMakeupProduct(string name, string type, decimal price, string brand, bool inStock, bool isLuxury)
            : base(name, type, price, brand, inStock)
        {
            IsLuxury = isLuxury;
        }

        public void DisplayLuxuryStatus()
        {
            Console.WriteLine($"Is Luxury: {IsLuxury}");
        }

        public new void DisplayProductInformation()
        {
            base.DisplayProductInformation();
            DisplayLuxuryStatus();
        }
    }

    public class LuxuryLipProduct : LuxuryMakeupProduct
    {
        public string Shade { get; private set; }

        public LuxuryLipProduct(string name, decimal price, string brand, bool inStock, bool isLuxury, string shade)
            : base(name, "Lip Product", price, brand, inStock, isLuxury)
        {
            Shade = shade;
        }

        public new void DisplayProductInformation()
        {
            base.DisplayProductInformation();
            Console.WriteLine($"Shade: {Shade}");
        }
    }

    public class DrugstoreMakeupProduct : MakeupProduct
    {
        public bool IsDrugstore { get; set; }

        public DrugstoreMakeupProduct(string name, string type, decimal price, string brand, bool inStock, bool isDrugstore)
            : base(name, type, price, brand, inStock)
        {
            IsDrugstore = isDrugstore;
        }

        public void DisplayDrugstoreStatus()
        {
            Console.WriteLine($"Is Drugstore: {IsDrugstore}");
        }

        public new void DisplayProductInformation()
        {
            base.DisplayProductInformation();
            DisplayDrugstoreStatus();
        }
    }

    public class LuxuryDrugstoreLipProduct : DrugstoreMakeupProduct, CheapProduct
    {
        public bool IsLuxury { get; set; }
        public string Shade { get; private set; }

        public LuxuryDrugstoreLipProduct(string name, decimal price, string brand, bool inStock, bool isDrugstore, bool isLuxury, string shade)
            : base(name, "Lip Product", price, brand, inStock, isDrugstore)
        {
            IsLuxury = isLuxury;
            Shade = shade;
        }

        public void DisplayLuxuryStatus()
        {
            Console.WriteLine($"Is Luxury: {IsLuxury}");
        }

        public new void DisplayProductInformation()
        {
            base.DisplayProductInformation();
            DisplayLuxuryStatus();
            Console.WriteLine($"Shade: {Shade}");
        }
    }

 
        
