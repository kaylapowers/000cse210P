using System;
using System.Collections.Generic;


public class Journal
{
	//DateTime theCurrentTime = DateTime.Now;
	//string dateText = theCurrentTime.ToShortDateString();

	// This class represents a journal class object
	//Journal purpose is to Display all, add to list, write journal to file, load journal from file
	//public Journal()
	//{

	// class member variables
	//public string _name; //******stretch
	//public string _filename = "journal.txt"; //*****stretch
	public List<Entry> _entries;
	//public List<Entry> _entries = new List<Entry>();

	/*
			// Console.WriteLine("Journal");
			// Console.WriteLine($"Display Journal of {_name}");

			//for each item in entry list- Display(Entry)
		}

		*/
	//Class Methods

	public void DisplayAll()
	{
		//for every entry in list of entries
		//Display Entry	
		Console.WriteLine("Displaying All Journal Items");


	}

	public void AddEntry(Entry newEntry)
	{
		Console.WriteLine("So happy you are writing in your journal"); //	Stretch

	}

	public void SaveToFile(string fileName)
	{
		Console.WriteLine($"Saving To File"); //****Stretch
	}


	public void LoadFromFile(string fileName)
	{
		Console.WriteLine($"Loading from file"); //****Stretch
	}

	//}
}



