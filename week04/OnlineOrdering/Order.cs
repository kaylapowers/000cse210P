using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Net.Http.Headers;

public class Order
{
	private Customer _customer;
	private static Address _address;
	private static Product _product;
	private static bool _usReside; //if customer lives in US

	//private static List<string> _productsListStr; //string for recipt- product name, ID, quantity subtotal 
	private static List<string> _packingList; //string for recipt- product name, ID, quantity subtotal 
	private static decimal _USShipCost = 5.00M; //shipping cost for US customers
	private static decimal _nonUSShipCost = 35.00M;
	private static decimal _finalShipCost = 0.0M;
	private static decimal _finalCostOfOrder = 0.0M; //final cost of order including shipping

	private static decimal _itemSubTotal = 0.0M; //initialize product total
	private static decimal _orderTotal = 0.0M; //initialize product total
	private static int _orderID = 945;
	private static int _productID;
	private static int _customerID;
	private static string _productName = ""; //product name
	private static decimal _productPrice = 0.0M; // price for one item
	private static int _productQuantity = 0;
	private static int _totalQuantity = 0; //initialize total quantity
	public Customer Customer { get { return _customer; } } //get customer address object

	public static decimal OrderTotal { get { return _orderTotal; } } //get order total
	public static decimal FinalCostOfOrder { get { return _finalCostOfOrder; } } //get final cost of order including shipping
																				 //constructors

	public Order(Customer customer)  //Customer Name, Address)
	{
		_customer = customer; // assign the customer parameter to the field
		_customerID = customer.CustomerID; //get customer ID
		_address = customer.CustomerAddress; //get customer address object	
		_usReside = _address.LivesInUS(); //check if customer lives in US
		_orderID = Order.GetOrderID();
		_packingList = new List<string>(); //initialize packing list
		_finalCostOfOrder = 0.0M; //reset final cost of order
		_orderTotal = 0.0M; //reset order total	
		_itemSubTotal = 0.0M; //reset item subtotal
		_totalQuantity = 0; //reset total quantity

	}
	public void OrderProduct(string productName, decimal productCost, int productQuantity)
	{
		_product = new Product(productName, productCost, productQuantity); //create a new 

		_productID = _product.ProductID; //get product ID
		_productQuantity = productQuantity; //get product quantity
		_totalQuantity += _productQuantity; //add product quantity to total quantity
		_productPrice = productCost; //get product price
		_productName = productName; //get product name

		_itemSubTotal = _productQuantity * _productPrice; //calculates item subtotal

		_orderTotal += _itemSubTotal; //adds item subtotal to order 
		_finalCostOfOrder = CalculateFinalCost(); //calculate final cost of order including shipping
		string _packingString = ($"Product: {_productName} ID: {_productID} Quantity: {_productQuantity}"); //Makes string for Procuct ID name qty PACKING  list
		Console.WriteLine("");
		Console.WriteLine($"Ordered Product: {_productName} ID: {_productID} Quantity: {_productQuantity} Price: ${_productPrice} SubTotal: ${_itemSubTotal} for Customer: {_customer.CustomerName}"); //display product info with subtotal
		_packingList.Add(_packingString); //add product to packing list
	}

	public void DisplayPackingList()
	{

		if (_packingList == null || _packingList.Count == 0)
		{
			Console.WriteLine("Packing list is empty.");
			return;
		}
		Console.WriteLine("");
		Console.WriteLine("Packing List:");
		foreach (var item in _packingList)
		{
			Console.WriteLine(item);
		}
		Console.WriteLine($"Total Packing List Items: {_totalQuantity}");
		Console.WriteLine();

	}
	
	private static int GetOrderID()
	{
		return ++_orderID; //increment product ID
	} //get product ID

	
	public static decimal CalculateShippingCost()
	{
		if (_usReside) //if customer lives in US
		{
			_finalShipCost = _USShipCost; //set shipping cost to US shipping cost
		}
		else //if customer does not live in US
		{
			_finalShipCost = _nonUSShipCost; //set shipping cost to non-US shipping cost
		}
		return _finalShipCost;
	} //calculate shipping cost
	public static decimal CalculateFinalCost()
	{
		_finalShipCost = CalculateShippingCost(); //calculate shipping cost
	//	Console.WriteLine($"Final Cost of Order: ${_finalCostOfOrder}"); //Console.WriteLine($"Product: {_productName} ID: {_productID} Quantity: {_productQuantity} Price: ${_productPrice} SubTotal: ${_itemSubTotal} Running total: {_orderTotal}"); //display product info with subtotal

		return _finalCostOfOrder = _orderTotal + _finalShipCost; //get order total from products list

	}
}