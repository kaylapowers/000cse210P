using System.Runtime.CompilerServices;

public class Order
{
	private static string _customerName;
	//customer 

	private static double usShipCost = 5.00;
	private static double nonUSShipCost = 35.00;
	private static double _finalShipCost;
	//private static Address _address;
	private static int _orderIdStart = 9876;
	private static int _orderId;
	private static int _prodID;
	private static int _customerId;
	private static double _orderCostTotal = 0.0;

	private static List<String> _receiptList = new List<String>();
	private static List<String> _prodIDOrdList = new List<String>();
	//	private static Customer customer;
	private static List<Product> _productsList = new List<Product>();
	private static double _productTotal = 0.0;


	private static int _countryCode;

	//constructors

	public Order(string customerName, int custID, int countryCode)
	{

		_customerName = customerName;
		_countryCode = countryCode;
		_customerId = custID;
		_orderId = MakeOrderID();
		MakeAnOrder();
		_finalShipCost = CalculateShippingCost(_countryCode);

		MakePackingList();
		PrintReceipt();
	}


	public static void MakeAnOrder()
	{

	}
	public static void MakePackingList()
	{
		Console.WriteLine($"Product Packing List");

		foreach (var product in _productsList)
		{
			Console.WriteLine($"{product}");
		}
	}

	public static string MakeShippingLabel(string _customerName, string _customerAddress, string _city, string _state, string _country)
	{

		Console.WriteLine($"Customer Name: {_customerName}");
		Console.WriteLine($"Address: {_customerAddress}");
		Console.WriteLine($"City: {_city}");
		Console.WriteLine($"State/Province: {_state}");
		Console.WriteLine($"Country: {_country}");
		string shippingLabel = ($"Customer name: {_customerName} \n Address: {_customerAddress} \n City: {_city} State/Provice: {_state} /n Country: {_country}");

		return shippingLabel;
	}

	public static double CalculateShippingCost(int _countryCode)
	{
		double shipping;

		if (_countryCode == 1) //us
		{
			shipping = usShipCost;
			Console.WriteLine($"You Live in US Shipping: ${shipping}");
		}
		else
		{
			shipping = nonUSShipCost;
			Console.WriteLine($"Sorry too far ship: ${shipping}");
		}

		return shipping;
	}

	public static int MakeOrderID()
	{
		int newID = _orderIdStart++;
		return newID;
	}


	public static void OrderProduct(string productName, double productPrice, int productQuantity)
	{


		Console.WriteLine($"From order - Order Product: {productName} {productPrice} {productQuantity}");

		Product product = new Product(productName, productPrice, productQuantity);

		_prodID = Product.MakeProductID();
		string prodidstring = ($"Product: {productName} Produdt ID: {_prodID} Qnt: {productQuantity}");
		Console.WriteLine($"{prodidstring}");

		_prodIDOrdList.Add(prodidstring);
		_productsList.Add(product);                 //adds ordered product to productsList of Order
		_productTotal = product.CostOfThisProduct(productPrice, productQuantity); //uses product.s calculate order cost 
		_orderCostTotal += _productTotal;  // adds each products cost to the total order cost

		string receiptLine = ($"Product: {productName} Price: {productPrice} Quantity: {productQuantity} Sub: {_productTotal}");
		_receiptList.Add(receiptLine); //adds line to the Receipt 
	}

	public static double CalculateFinalCost()
	{

		double finalCostofOrder = _orderCostTotal + _finalShipCost;
		return finalCostofOrder;
	}

	public static void PrintReceipt()
	{
		Console.WriteLine($"Print Reciept:");

		foreach (var line in _receiptList)
		{
			Console.WriteLine($"Print {line}");
			Console.WriteLine();
		}

		Console.WriteLine($"Total Order: ${_orderCostTotal}");
		Console.WriteLine($"Shipping: ${_finalShipCost}");
		double final = CalculateFinalCost();
		Console.WriteLine($"Total: ${final}");

	}

	private static void waitABit()
	{
		Console.WriteLine($"waiting A bit for return key");

	}
}