using System.Configuration.Assemblies;
using System.Dynamic;
using System.Net.Sockets;

public class Customer
{
	public static bool _USReside; //if customer lives in US
	private static Address _customerAddress;
	
	private string _customerName;
	private static int _customerID = 435;
	private string _streetAddress;
	private string _city;
	private string _state;
	private string _country;

	public string CustomerName { get { return _customerName; } }
	public int CustomerID { get { return _customerID; } }

	public string Country { get { return _country; } }
	public Address CustomerAddress { get { return _customerAddress; } }


	// Constructor
	public Customer(string customerName, string streetAddress, string city, string state, string country)
	{

		_customerName = customerName.ToUpper();
		_streetAddress = streetAddress.ToUpper();
		_city = city.ToUpper();
		_state = state.ToUpper();
		_country = country.ToUpper();
		_customerID = MakeCustomerID(); //get customer ID
		_customerAddress = new Address(_customerName, _streetAddress, _city, _state, _country);
		_USReside = _customerAddress.LivesInUS();
		//_productsList = new List<Product>();

	}
	private static int MakeCustomerID()
	{
		return ++_customerID; //increment customer ID
	}
	
}

