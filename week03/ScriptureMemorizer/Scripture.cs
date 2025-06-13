using System.Linq.Expressions;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;

class Scripture
{
	private static string[] _newScriptureWordsArray;
	private static string[] _newScriptureTextArray;
	private static string[] _oldScriptureTextArray;
	private static string[] _staticScriptureTextArray;
	private static string _oldScriptureTextString;
	private static string _newScriptureTextString;
	private static Word _newScriptureWord;
	private static string _staticScriptureTextString;
	private static bool _areAllWordsHidden;
	private static Reference _bookChpVerseRef;
	private static string _bookChpVerseRefString;
	//static List<int> _toggleSelections; //initialize at all 1s for all viewable  1 , toggle to 0 for hidden. Continue the game until all are at 0.
	private static int _lengthOfScripture = 0;
	private static int _randomNum;
	private static int[] _trackToggleIndexArray;
	private static int[] _toggleIndexArray;
	private static int _maxWordsToToggle = 3;
	private static int _loops = 1;

	//default constructor

	public Scripture(Reference bookChpVerseRef, string scriptureText)
	{
		_bookChpVerseRef = bookChpVerseRef;
		_staticScriptureTextString = scriptureText; //static scripture text holds a base of the original scripture text.
		_oldScriptureTextString = scriptureText;
		_newScriptureTextArray = scriptureText.Split(" ", StringSplitOptions.TrimEntries); //split text to word strings
		_lengthOfScripture = _newScriptureTextArray.Length;
		_toggleIndexArray = new int[_lengthOfScripture];
		_trackToggleIndexArray = new int[_lengthOfScripture];
		Reference newbookChpVerseRef = new Reference(); //required
		_bookChpVerseRefString = bookChpVerseRef.GetReferenceString();
		_trackToggleIndexArray = (int[])_toggleIndexArray.Clone(); //starts 0000
		GetScripturePrompt();

		while (!_areAllWordsHidden)
		{
			HideRandomWords();
			_newScriptureWord = new Word(_newScriptureTextArray, _trackToggleIndexArray, _toggleIndexArray); //sends completed base array and the values to toggle to Word for processing
			GetDisplayText();
			_areAllWordsHidden = AreAllWordsHidden();
			if (_areAllWordsHidden == true)
			{ GetDisplayText(); }
		}

	}

	public static void SetHideChar(string hideChar)
	{
		Word.SetHideChar(hideChar);

	}
	//class methods
	public static void SetMaxWordsToToggle(int maxWordsToToggle)
	{
		_maxWordsToToggle = maxWordsToToggle;
	}
	private static int GetRandomNumber(int _lengthOfScripture) // simply generates the next random number to select which item of array is changed
	{
		Random random = new Random();
		int randomnum = random.Next(0, _lengthOfScripture);
		return randomnum;
	}
	private static void HideRandomWords()   // each iteration of Max#Toggled words- Gets ranom number, and toggles value from 1 to zero and sero to one
	{
		for (int j = 0; j < _maxWordsToToggle; j++) //gets random number for upper bound of words to toggle.
		{
			_randomNum = GetRandomNumber(_lengthOfScripture);
			if (_toggleIndexArray[_randomNum] == 0)
			{
				_toggleIndexArray[_randomNum] = 1;  //loads the array with 1 for each value. When all are 1- 
				_trackToggleIndexArray[_randomNum] = 1;
			}
			else if (_toggleIndexArray[_randomNum] == 1)
			{ _toggleIndexArray[_randomNum] = 0; }
		}
	}

	public static void GetScripturePrompt()
	{
		Console.WriteLine($"The Scripture you are memorizing is: \n----->  {_bookChpVerseRefString} {_staticScriptureTextString} <-----");
		//string promptString = "junkstring";
		//return promptString;
	}

	public static string GetDisplayText()    //**************required
	{
		string displayString = Word.GetNewDisplayText();
		Console.Write($"Here is your clue #{_loops}:\n{displayString}\n");
		waitForReturnKey();
		//WaitABit(1);
		//Console.WriteLine();
		_loops++;

		return displayString;

	}



	public static bool AreAllWordsHidden()
	{
		bool areAllWordsHidden = Word.AreAllWordsHidden(_trackToggleIndexArray);

		// use isall hidden in word
		return areAllWordsHidden;

	}

	public static void WaitABit(int seconds = 2)
	{
		int millisecs = seconds * 1000;
		Thread.Sleep(millisecs);

	}

	private static string waitForReturnKey()
	{
		Console.WriteLine("Waiting... press return key when ready.");
		string ans = Console.ReadLine();
		return "";
	}


}