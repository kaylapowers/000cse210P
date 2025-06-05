using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class Product
{

	private static int _productID; // unique product ID for each product
	private static string _productName = "";
	private static int _productQuantity = 0;
	private static decimal _productPrice = 0.0M; // price for one item

	private static int _nextProductID = 1000; // static counter for unique IDs
	
	public Product(string productName, decimal productPrice, int productQuantity)
	{
		_productName = productName;
		_productPrice = productPrice;
		_productQuantity = productQuantity;
		_productID = GetNextProductID();
		
	}

	public int ProductID
	{
		get { return ++_productID; }
	}

	private static int GetNextProductID()
	{
		return ++_nextProductID;
	} //returns unique product ID
	
} 	
