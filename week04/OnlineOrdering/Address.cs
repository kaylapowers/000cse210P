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
		_customerName = customerName;
		_streetAddress = streetAddress;
		_city = city;
		_state = state;
		_country = country;

		DisplayShippingLabel();
	}

	public string GetCountry()
	{
		return _country.ToUpper();
	}
	public bool LivesInUS()
	{
		if (_country.ToUpper() == "USA")
		{
			return true;
		}
		else  // country is not USA
		{
			return false;
		}
	}


	public static string MakeAddressString()
	{
		_addressString = $"Customer:  {_customerName}{Environment.NewLine}Address: {_streetAddress}{Environment.NewLine}City:  {_city}{Environment.NewLine}State/Province:  {_state}{Environment.NewLine}Country:  {_country} ";
		return _addressString;
	}

	public void DisplayShippingLabel()
	{
		Console.WriteLine("");
		Console.WriteLine($"Shipping Label:");

		_addressString = MakeAddressString();
		Console.WriteLine($"{_addressString}");
		Console.WriteLine("");
	}
}