using System.Net.Sockets;

public class Customer
{

	private static string _customerFirstName;
	private static string _customerLastName;

	private static string _customerId;
	private static int nextId = 100001;
	private static Address _customerAddress;

	//constructors

	Customer()
	{


	}

	//member methods
	bool LivesInUS()
	{
		bool answer = true;
		//bool answer AddressObj.LivesInUs();
		return answer;
	}

	private void DisplayCustomerInfo()
	{
		Console.WriteLine();

		Console.WriteLine($"From Customer Class Display");
		Console.WriteLine($" Name: {_customerFirstName}  {_customerLastName} ID: {_customerId}");
		Console.WriteLine($"Address {_customerAddress}");
	}

	public static string MakeCustomer()
	{

		return "";
	}

	public static int MakeCustomerId(int nextId)

	{
		return nextId + 1;
	}
}