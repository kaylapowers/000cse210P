using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{


	static void Main(string[] args)
	{
		//	Console.Clear();
		Console.WriteLine("Hello CSE210! This is the Online-Ordering Project.");
		Console.WriteLine();
		Console.WriteLine(" *************CUSTOMER 1 ORDER *************");
		Console.WriteLine("");
		//Product product1 = new Product("Rib Eye Steak with Bone", (decimal)15.92, 4);
		//Product product3 = new Product("Jo Ride Candy Bar", (decimal)1.34, 5);
		//	Product product4 = new Product("TaterLand Toy", (decimal)22.12, 1);
		//
		//		Product product5 = new Product("Pet Jacket ", (decimal)18.12, 1);
		//		Product product7 = new Product("New Zumba", (decimal)24.56, 3);
		//		Product product9 = new Product("Bohemian everjo", (decimal)4.42, 10);
		//		Product product11 = new Product("BarnFlyer", (decimal)98.99, 1);
		//Product product5 = new Product("Pet Jacket ", (decimal)18.12, 1);
		//Product product7 = new Product("New Zumba", (decimal)24.56, 3);

		Customer customer1 = new Customer("K Power", "10601 N ShowHorse Ln", "Boise", "ID 84762", "USA");
	
		Order order1 = new Order(customer1); //create a new order for customer1
		order1.OrderProduct("Pet Jacket ", (decimal)18.12, 1);
		order1.OrderProduct("Jo Ride Candy Bar", (decimal)1.34, 5);

		order1.DisplayPackingList(); //display packing list
		DisplayOrderDetails(order1); //display order details for customer1
		Console.WriteLine("");
		Console.WriteLine("*************CUSTOMER 2 ORDER*************");
		Console.WriteLine("");

		Customer customer2 = new Customer("J Peddem", "10601 N Shownownn", "greatplace", "margin 938222", "Nigeria");
		Order order2 = new Order(customer2); //create a new order for customer2
		order2.OrderProduct("Rib Eye Steak with Bone", (decimal)15.92, 4);
		order2.OrderProduct("TaterLand Toy", (decimal)22.12, 1);
		order2.OrderProduct("BarnFlyer", (decimal)98.99, 1);
		Console.WriteLine("");

		order2.DisplayPackingList(); //display packing list
		DisplayOrderDetails(order2); //display order details for customer2
	}
	private static void DisplayOrderDetails(Order Order)
	{
		Console.WriteLine($"Total for All Products: ${Order.OrderTotal}"); //display total cost of order
		Console.WriteLine($"Add Shipping Cost for {Order.Customer.Country}: ${Order.CalculateShippingCost()}"); //display shipping cost

		Console.WriteLine($"Total Paid for Order: ${Order.FinalCostOfOrder}"); //display final cost of order

		Console.WriteLine("");
		Console.WriteLine("");


		Console.WriteLine($"Thank you for your order, {Order.Customer.CustomerName}!");
		Console.WriteLine($"Your order will be shipped to: {Order.Customer.CustomerAddress.GetCountry()}");
	}
}
