public class Address
{


	private static string _streetAddress;
	private static string _city;
	private static string _state;
	private static string _country;
	private static string _customerName;
	private static string _addressString; //string concat address


	//constructor
	public Address(string customerName, string streetAddress, string city, string state, string country)
	{
		//	_custID = custID;
		_customerName = customerName;
		_streetAddress = streetAddress;
		_city = city;
		_state = state;
		_country = country;

		Console.WriteLine($"Address Constructor-");
		MakeAddressString();
		DisplayShippingLabel();
	}

	public bool LivesInUS(string country)
	{
		Console.WriteLine($"Lives in US? in Address");

		if (country.ToUpper() == "USA")
		{
			return true;
		}
		else  // country is not USA
		{
			return false;
		}
	}


	public string MakeAddressString()
	{
		_addressString = $"Address: {_streetAddress} \n City: {_city} \n State/Province: {_state} \n Country: {_country}";
		//string Address = Street + City + State + country
		Console.WriteLine("Make Address String");
		Console.WriteLine($"{_addressString}");

		return _addressString;

	}
	public void DisplayShippingLabel()
	{
		Console.WriteLine($" Display Shipping Label in Address");
		string addressString = MakeAddressString();
		Console.WriteLine($" Customer: {_customerName}");
		Console.WriteLine($" Address: {_addressString}");

	}
	private static void waitABit()
	{
		Console.WriteLine($"waiting A bit for return key");

	}
}