using System;
using System.Runtime.CompilerServices;
using System.IO;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using static System.Console;
//Kayla Powers
//STRETCH: User Name to provide more intimate reactivity to the program.
// This is a simple console application that allows users to enter scripture references and text, 
//Allows to change the hide character, set default scripture. Counts and displays the tries to get to the hidden string.
class Program
{
	private static bool _quitProgram = false;
	private static bool _areAllWordsHidden = false;
	private static int _maxWordsToToggle = 3;
	private static string _hideChar = "X";
	private static string _userName = "New User";
	private static string _fullScriptureText = "Hel. 14:12-13 And also that ye might know ";

	//private static string _fullScriptureText = "Hel. 14:12-13 And also that ye might know of the coming of Jesus Christ,the Son of God";
	//, the Father of heaven and of earth, the Creator of all things from the beginning; and that ye might know of the signs of his coming, to the intent that ye might believe on his name. And if ye believe on his name ye will repent of all your sins, that thereby ye may have a remission of them through his merits.
	private static string _oldScriptureText;    //with toggled current scripture
	private static string[] _mainMenuItems = { "-- Enter a new Scripture to study", "-- Set Preferences (test)", "-- Quit Program" };
	private static Reference _referenceText;
	private static string _referenceTextString;
	private static Scripture _scriptureText;
	private static string _scriptureTextString;

	//private static string _chapterText = "";
	private static string _book;


	static void Main(string[] args)
	{
	//Console.Clear();
		GetUserName();
		while (!_areAllWordsHidden && !_quitProgram) //run prog allwods false  if some words not hidden or if quit isnt selected
		{
			DisplayMenuItems();
			Console.WriteLine($"");

			//split into reference (Book, Chapter, startVerse, endVerse=0) and versetext
			string[] parts = Program.SplitReferenceAndScriptureText(_fullScriptureText);
			_book = parts[0];
			string chapterVerses = parts[1];
			Reference _referenceText = new Reference(_book + " " + chapterVerses);
			_oldScriptureText = parts[2];
			Scripture _scriptureText = new Scripture(_referenceText, _oldScriptureText);
			Scripture.SetMaxWordsToToggle(_maxWordsToToggle);
			Scripture.SetHideChar(_hideChar);
			AreAllWordsHidden();
		}
	}
	static void DisplayMenuItems()
	{
		//Console.Clear();
		Console.WriteLine($"******** {_userName}, Welcome  to the Scripture Memorizer Menu  ****");
		Console.WriteLine($"Select a menu item to Enter Scriptures, set preferences, or Quit to exit.");

		int lengthMenu = _mainMenuItems.Length;
		int j = 1;
		foreach (var item in _mainMenuItems)
		{
			Console.WriteLine($"{j++} {item}");
		}
		Console.WriteLine($"");
		Console.Write($">> ");

		string answer = Console.ReadLine();
		int selectNum = int.Parse(answer);
		if (selectNum == lengthMenu) //quit last item in menu
		{
			_quitProgram = true;
			Environment.Exit(0);
		}
		else if (selectNum == 1)
		{
			//string fullScriptureText = "";
			GetRefAndScripture();
		}
		else
		{
			Console.WriteLine($"Will be adding this functionality soon.");
			Scripture.WaitABit(3);
			DisplayMenuItems();
		}
	}


	public static bool AreAllWordsHidden()
	{//dafualt not all words and characters changed to _hideChar
		_areAllWordsHidden = Scripture.AreAllWordsHidden();
		if (_areAllWordsHidden)
		{
			//_areAllWordsHidden = true;
			Console.WriteLine($"All words are now Hidden- Try the scripture from memory!! ");
			Environment.Exit(0);
		}
		return _areAllWordsHidden;
	}
	private static void SetHideChar(string _hideChar)
	{
		Scripture.SetHideChar(_hideChar);
	}
	private static void GetUserName()
	{

		Console.WriteLine("Enter your NAME: ");

		string userName = Console.ReadLine();
		if (userName != "")
		{
			_userName = userName;
		}

		//return _userName;
	}



	static string GetRefAndScripture()
	{
		//_fullScriptureText = "Hel. 14:12 And also that ye might know of the coming of Jesus Christ, the Son of God, the Father of heaven and of earth, the Creator of all things from the beginning; and that ye might know of the signs of his coming, to the intent that ye might believe on his name.";

		Console.WriteLine($"");
		Console.WriteLine($"{_userName}- Welcome to the Scripture Memorizer Project.");
		Console.WriteLine($"");
		Console.WriteLine($"Here's a Scripture to memorize- hit return to keep,  or any other key to enter new Scripture Text:");
		Console.WriteLine($"{_fullScriptureText}");
		string response = Console.ReadLine();
		if (response != "")
		{
			Console.WriteLine($"Enter your Scripture reference and Scripture text: ");
			Console.WriteLine($"");

			Console.WriteLine("Formated as 'Book Chapter:VerseStart-VerseEnd  Text of the scripture");
			Console.WriteLine("[Example] John 3:16-17 For God so loved the world ...");
			Console.WriteLine("You can skip the end Verse and hyphen if you use a single verse.");
			//WaitABit(4000);
			Console.WriteLine($"");

			Console.WriteLine($"This will help you memorize scripture by");
			Console.WriteLine($"showing the full scripture and reference to memorize, ");
			Console.WriteLine($"then hiding {_maxWordsToToggle} random words each iteration until all words are hidden.");
			Console.WriteLine($"");
			Console.Write($"====>  ");

			_fullScriptureText = Console.ReadLine();
		}
		return _fullScriptureText;
	}


	public static string[] SplitReferenceAndScriptureText(string fullScriptureText)
	{

		string[] parts = fullScriptureText.Split(" ", 3, StringSplitOptions.TrimEntries);
		//	Console.WriteLine($"Book: {parts[0]} \n Chp:Verses {parts[2]} \n Script: {parts[3]} \n");

		return parts;
	}

	public static void DisplayScripturePrompt()
	{
		Scripture.GetScripturePrompt();
		//Console.WriteLine($"{ScripturePrompt}");

	}
	public static void DisplayToggledTextString()
	{

		//Console.WriteLine($"The scripture you are memorizing is: \n{_fullScriptureText}");
		Console.WriteLine($"");

		//_referenceTextString = _referenceText.GetDisplayText();
		if (_scriptureText != null)
		{
			_scriptureTextString = Scripture.GetDisplayText();
		}
		else
		{
			_scriptureTextString = "";
		}


		if (!string.IsNullOrEmpty(_scriptureTextString))
		{
			string displayNewString = ($"Here's Your Clue:\n{_referenceTextString}  {_scriptureTextString}");
			Console.WriteLine($"{displayNewString} ");
		}
	}
	public static void WaitABit(int duration = 2000)
	{
		Thread.Sleep(duration);

	}
}

/***************************ADD FEATURES^^^^^^^^^^^^^^^^^^^^^^^^^^^**********************/
/*static int RandomizeUpperBound(int upperBound, int scriptureWordCnt)
{
	Random random = new Random();
	int randomUpperBound = random.Next(1, upperBound + 1);
	Console.WriteLine($"Randomized upper bound is {randomUpperBound}");
	return randomUpperBound;
} // end RandomizeUpperBound	



/*
	if (File.Exists(defaultFileName))
	{

		Console.WriteLine($"Your Scripture File {defaultFileName} exists");
		Console.WriteLine("Press <enter> key to have me choose a random scripture from your file, or enter 'N(o)' to enter a new scripture: ");


		/*
						string userInput = Console.ReadLine();
						if (userInput.ToUpper() == "N" || userInput.ToUpper() == "NO")
						{
							//user chose to enter a new scripture

							//write the scripture to file
							Console.WriteLine($"Your scripture '{fullScriptureText}' has been saved to {defaultFileName}");
							return fullScriptureText;
						}
						else if (userInput == "")
						{
							Console.WriteLine("You chose to have me get a random scripture from your file {defaultFileName.");
							//getRandomScripture
							fullScriptureText = GetRandomScripture();
							if (fullScriptureText != null)
							{
								Console.WriteLine($"Random scripture selected: {fullScriptureText}");
								//break the scripture text into reference and text
								//	string brokenScripture = BreakScriptureText(fullScriptureText);
								//	if (brokenScripture != null)
								//	{
								//		Console.WriteLine($"Broken scripture: {brokenScripture}");
								// Here you can display the broken scripture or process it further
								//	}
								return fullScriptureText;
							}
							else
							{
								Console.WriteLine("No scriptures found in the file.");
								return "";
							}

						}
						else
						{
							Console.WriteLine("Sorry No file Exists. Please try again and enter a new scripture.");
							return "";

						}
						return "";

	else
		{ return "2"; }

	}*/
/*
static string setDefaultFileName(string defaultFileName)
{
	Console.WriteLine($"The default filename is {defaultFileName}");
	Console.WriteLine($"Press <enter> key to use this, or type a different 'filename.txt.'");

	string defname = Console.ReadLine();
	if (defname != "")
	{
		defaultFileName = defname;
	}
	Console.WriteLine($"The NEW filename is {defaultFileName}");

	return defaultFileName;

} //setdefault file name */
/*
	static void WriteScriptureToFile(string scriptureText)
	{
		try
		{
			using (StreamWriter writer = new StreamWriter(defaultFileName, true))
			{
				writer.WriteLine(scriptureText);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error writing to file: {ex.Message}");
		}
	} // end WriteScriptureToFile */
/*
	static void ReadScriptureFromFile()
	{
		try
		{
			if (File.Exists(defaultFileName))
			{
				using (StreamReader reader = new StreamReader(defaultFileName))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						Console.WriteLine(line);
					}
				}
			}
			else
			{
				Console.WriteLine($"File {defaultFileName} does not exist.");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error reading from file: {ex.Message}");
		}
	} // end ReadScriptureFromFile */



