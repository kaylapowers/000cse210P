using System.Collections.Generic;

public class Customer
{
	private string _customerName;
	private int _customerID;
	private string _streetAddress;
	private string _city;
	private string _state;

	private string _country;
	private static int _nextID = 100001;
	private int _countryCode = 0;
	private Address _customerAddress;
	private Product _productOrder;
	private Order _order;

	//constructors

	public Customer(string customerName, string streetAddress, string city, string state, string country)
	{


		_customerName = customerName;
		_streetAddress = streetAddress;
		_city = city;
		_state = state;
		_country = country.ToUpper();
		_customerID = MakeCustomerId();

		_customerAddress = new Address(_customerName, _streetAddress, _city, _state, _country);
		_countryCode = LivesInUS();
	}


	//member methods

	private void MakeAnOrder()
	{
		_order = new Order(_customerName, _customerID, _countryCode);
	}

	private int LivesInUS()
	{
		if (_customerAddress.LivesInUS(_country))
		{ _countryCode = 1; }
		else
		{ _countryCode = 0; }

		//Console.WriteLine($"CustomerCL {_countryCode} LivesInUS");
		return _countryCode;
	}

	public static int MakeCustomerId()
	{
		int n = _nextID++;
		Console.WriteLine($"Customer ID {n}");

		return n;
	}

	public void OrderAProduct(string productName, double productPrice, int productQuantity)
	{
		//	Console.WriteLine($"Ordering Product-Customer {productName} {productPrice} {productQuantity}");
		Order.OrderProduct(productName, productPrice, productQuantity);

	}

	private void waitABit()
	{
		Console.WriteLine($"waiting A bit for return key");

	}

}

