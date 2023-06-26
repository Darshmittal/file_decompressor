using System;
using System.Collections.Generic;

// BusinessType class
class BusinessType
{
    public int TypeId { get; set; }
    public string TypeName { get; set; }
}

// Discount class
class Discount
{
    public int DiscountId { get; set; }
    public string DiscountName { get; set; }
    public decimal Percentage { get; set; }
}

// Pricing class
class Pricing
{
    public int PriceId { get; set; }
    public decimal BasePrice { get; set; }
    public List<Discount> Discounts { get; set; }

    public Pricing()
    {
        Discounts = new List<Discount>();
    }
}

// Plan class
class Plan
{
    public int PlanId { get; set; }
    public string PlanName { get; set; }
    public Pricing Pricing { get; set; }
}

// Product class
class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}

// Client class
class Client
{
    public int ClientId { get; set; }
    public string ClientName { get; set; }
    public string ContactInfo { get; set; }
    public string Address { get; set; }
    public BusinessType BusinessType { get; set; }
    public Plan Plan { get; set; }
    public List<Product> Products { get; set; }

    public Client()
    {
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        var existingProduct = Products.Find(p => p.ProductId == product.ProductId);
        if (existingProduct != null)
        {
            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
}

// ReportGenerator class
class ReportGenerator
{
    public int ReportId { get; set; }

    public void GenerateClientReport(Client client)
    {
        Console.WriteLine("Generating client report...");
        // Logic to generate client report
    }

    public void GenerateProductReport(Product product)
    {
        Console.WriteLine("Generating product report...");
        // Logic to generate product report
    }

    public void GeneratePlanReport(Plan plan)
    {
        Console.WriteLine("Generating plan report...");
        // Logic to generate plan report
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create business types
        var businessType1 = new BusinessType { TypeId = 1, TypeName = "Type 1" };
        var businessType2 = new BusinessType { TypeId = 2, TypeName = "Type 2" };

        // Create discounts
        var discount1 = new Discount { DiscountId = 1, DiscountName = "Discount 1", Percentage = 10 };
        var discount2 = new Discount { DiscountId = 2, DiscountName = "Discount 2", Percentage = 15 };

        // Create pricing
        var pricing = new Pricing { PriceId = 1, BasePrice = 100 };
        pricing.Discounts.Add(discount1);
        pricing.Discounts.Add(discount2);

        // Create plan
        var plan = new Plan { PlanId = 1, PlanName = "Plan 1", Pricing = pricing };

    }
}
