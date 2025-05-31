using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class Product
{

	private readonly int _productId;
	private static int _productIdStart = 9876;
	//private static List<Product> productList;

	private static string _productName;
	private static double _productPrice = 0.0;
	private static int _productQuantity = 0;
	//private static double _totalCostProduct = 0.0;
	//	private static double _orderCost = 0.0;
	//private static int _custId;

	//class constructors


	public Product(string productName, double productPrice, int productQuantity)
	{

		_productName = productName;
		_productPrice = productPrice;
		_productQuantity = productQuantity;
		_productId = MakeProductID();
		double totalCostThisProduct = CostOfThisProduct(_productPrice, _productQuantity);
		//	DisplayProduct();
	}


	//member methods
	public static int MakeProductID()
	{
		return _productIdStart++;
	}

	public double CostOfThisProduct(double productPrice, int productQuantity)
	{

		double costOfThisProd = productPrice * productQuantity;
		return costOfThisProd;

	}
	private static void waitABit()
	{
		Console.WriteLine($"waiting A bit for return key");

	}
}

