using System;

//namespace JournalSpace;
// This class represents an entry to list 
public class Entry
{
	public string _date;//stretch
	public string _promptText; //propmt given to ask question
	public string _entryText;
	public string _lineEntry;
	//private string lineEntry;
	//user submission to journal

	public Entry()
	{

		_date = getTheEntryDate(); //gets todays date- STRETCH
		PromptGenerator entryPrompt = new PromptGenerator();
		//gets a new Prompt for writing

		_promptText = entryPrompt._prompt;

		//Console.WriteLine($"lineEntry is : {_lineEntry}");


	}

	public string getTheEntryDate()
	{
		string today = DateTime.Today.ToShortDateString();
		//Console.WriteLine($"StDate: {today}");
		return today;

	}

	public void Display(string date = "defdt", string prompt = "defPmt", string userentry = "defent")
	{   //displays en entry

		Console.WriteLine($"Display Entry is --> {date}- {prompt}: {userentry}");
		//_lineEntry = _date + " " + _promptText + " " + _entryText;
		//Console.WriteLine($"Conc: {_lineEntry}");
		//display 
	}

}