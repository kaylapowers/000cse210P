using System;
using System.Collections.Generic;

class Program
{


	static void Main(string[] args)
	{

		Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

		Customer customer1 = new Customer("K Power", "10601 N ShowHorse Ln", "Boise", "ID 84762", "USA");

		customer1.OrderAProduct("orange", .98, 3);

		//	customer1.Order.MakePackingList();

	}

	//use customer OrderAProduct Method to add products.
	/*
			List<Product> productsList1 = new List<Product>
				{
					new Product("orange", .98, 3 ),
					new Product("milk", 5.98, 2 ),
					new Product("bread", 7.34, 1 ),
					new Product("Rib Eye Steak with Bone", 15.92, 4 ),
					new Product("12 pack JJ Water", 2.54, 3 ),
					new Product("Jo Ride Candy Bar", 1.34, 5 ),
				};

				*/
	/*
			Customer customer2 = new Customer("Jon DoItLittle", "10 Burton Road", "Anywhere But here", "NV 88888", "USA");

			List<Product> productsList2 = new List<Product>
				{
					new Product("orange", .98, 3 ),
					new Product("milk", 5.98, 2 ),
					new Product("bread", 7.34, 1 ),
					new Product("Rib Eye Steak with Bone", 15.92, 4 ),
					new Product("12 pack JJ Water", 2.54, 3 ),
					new Product("Jo Ride Candy Bar", 1.34, 5 ),
				};
			Customer customer3 = new Customer("Mother T", "1245 Crazy Place", "Everland", "Aquils 9f33 ", "notUs");

			List<Product> productsList3 = new List<Product>
				{
					new Product("orange", .98, 3 ),
					new Product("milk", 5.98, 2 ),
					new Product("bread", 7.34, 1 ),
					new Product("Rib Eye Steak with Bone", 15.92, 4 ),
					new Product("12 pack JJ Water", 2.54, 3 ),
					new Product("Jo Ride Candy Bar", 1.34, 5 ),
				};

	*/




	/*	List<Product> productsList = new List<Product>
		{
			new Product("orange", .98, 3 ),
			new Product("milk", 5.98, 2 ),
			new Product("bread", 7.34, 1 ),
			new Product("Rib Eye Steak with Bone", 15.92, 4 ),
			new Product("12 pack JJ Water", 2.54, 3 ),
			new Product("Jo Ride Candy Bar", 1.34, 5 ),
		};

		// If you want to add products to another list, declare it first
		List<Product> productsList1 = new List<Product>();
		foreach (var product in productsList)
		{
			productsList1.Add(product);
		}
	}
	*/

	private static void waitABit()
	{
		Console.WriteLine($"waiting A bit for return key");

	}
}

