
using System.Buffers;
using System.Reflection.Metadata.Ecma335;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

public class Word
{
	//class variables
	//	private static List<Word> _scriptureWordsList;
	//	private static List<Word> _oldScriptureWordsList;
	//	protected List<int> _hiddenWordNumList = new List<int>();
	//	private static List<string> _oldScriptureTextList = new List<string>();
	//	private static List<string> _staticScriptureTextList = new List<string>();
	//private static List<string> _newScriptureTextList = new List<string>();
	private static string[] _staticScriptureTextArray;
	private static string[] _newScriptureTextArray;
	private static string[] _oldScriptureTextArray;
	private static string _newScriptureTextString;
	private static string _oldScriptureTextString;
	private static char[] _newScriptureCharArray;
	private static char[] _oldScriptureCharArray;
	//private static char[] _oldWordToChar;
	private static string _oldToggledWordString;
	private static string _newToggledWordString;
	private static string _hideChar = "_";
	private static char hideChar = _hideChar[0];
	private static int[] _trackHiddenWordIntArray;
	private static int[] _currHiddenWordIntArray;
	private static bool _areAllWordsHidden = false;  //all words in textstring are hidden


	public Word(string[] scriptureTextArray, int[] trackHiddenWordIntArray, int[] currHiddenWordIntArray)  // if toggle is true change word from hidden with hidechar to regular text
	{

		_staticScriptureTextArray = scriptureTextArray;
		_currHiddenWordIntArray = currHiddenWordIntArray; //copy of he passed hidden word code copied to old array. Old will hold, new will update,
		_trackHiddenWordIntArray = trackHiddenWordIntArray; //copy of he passed hidden word code copied to old array. Old will hold, new will update,

		_newScriptureTextArray = HideWords(trackHiddenWordIntArray, currHiddenWordIntArray, scriptureTextArray); //sends thhe code to flip and changes the text array to hold hidden 
																												 //	}

	}
	//class methods
	public static void SetHideChar(string hideChar)
	{
		_hideChar = hideChar;
	}

	private static string[] HideWords(int[] trackHiddenWordIntArray, int[] currHiddenWordIntArray, string[] oldScriptureTextArray) //changes the word in the text array 
	{
		_trackHiddenWordIntArray = trackHiddenWordIntArray;
		_currHiddenWordIntArray = currHiddenWordIntArray;
		int arrayIndex;
		int hWALength = currHiddenWordIntArray.Length;
		//_oldScriptureTextArray = oldScriptureTextArray;
		_newScriptureTextArray = new string[hWALength];

		for (arrayIndex = 0; arrayIndex < hWALength; arrayIndex++)
		{

			if (currHiddenWordIntArray[arrayIndex] == 1)  //toggle the word[arrayIndex]
			{
				//_trackHiddenWordIntArray[arrayIndex] = 1;
				int charCount = _staticScriptureTextArray[arrayIndex].Length;
				_newScriptureTextString = oldScriptureTextArray[arrayIndex];  //gets the single word to flip
				_oldScriptureCharArray = _newScriptureTextString.ToCharArray(); //puts word to toggle into char array so we can change 
				_newScriptureCharArray = (char[])_oldScriptureCharArray.Clone(); //make a copy for the changed version with hide char in.

				for (int j = 0; j < charCount; j++)
				{
					_newScriptureCharArray[j] = hideChar;
					//Console.WriteLine($"WD Repl let: {_oldScriptureCharArray[j]} -> {_newScriptureCharArray[j]}");
				}

				_newToggledWordString = new string(_newScriptureCharArray);
				_newScriptureTextArray[arrayIndex] = _newToggledWordString;
				//	Console.WriteLine($"HIDden: {_staticScriptureTextArray[arrayIndex]} with {_newScriptureTextArray[arrayIndex]}");
			}
			else //zero val keeps seen
			{
				_newScriptureTextArray[arrayIndex] = _staticScriptureTextArray[arrayIndex];
				//Console.WriteLine($"no toggle- {_oldToggledWordString} : {_oldScriptureTextArray[arrayIndex]}");
			}

		}
		//	_oldScriptureTextArray = _newScriptureTextArray;
		return _newScriptureTextArray;
	}


	private static void displayString(string[] stringArray)
	{
		foreach (var value in stringArray)
			Console.WriteLine($"SC _newScripture: {value}");
	}
	private void displayIntArray(int[] stringArray)
	{
		foreach (var value in stringArray)
			Console.WriteLine($"Integer Array Contents: {value}");
	}
	public static bool AreAllWordsHidden(int[] trackHiddenWordIntArray) //checks if word is hidden or shown   //*****required
	{
		bool _areAllWordsHidden = true;
		foreach (var val in trackHiddenWordIntArray)
		{
			if (val == 0)
			{
				_areAllWordsHidden = false;
				break;
			}

		}
		if (_areAllWordsHidden)

		{
			HideWords(_trackHiddenWordIntArray, _trackHiddenWordIntArray, _newScriptureTextArray);
			//string lastDisplay = GetNewDisplayText();
			//Console.WriteLine($"{lastDisplay}");

			//Console.WriteLine($"All Words are now hidden!!");
		}
		return _areAllWordsHidden;
	}


	public static string GetNewDisplayText()  //returns catonated string of updated text array  ////*****required
	{
		_newScriptureTextString = string.Join(" ", _newScriptureTextArray);
		//_newScriptureTextString = "Just something to pass along;";
		//Console.Write($"WD Here is your clue: \n{_newScriptureTextString} ");

		return _newScriptureTextString;
	}


	private static string waitForRet()
	{
		Console.WriteLine("Waiting... press return key when ready.");
		string ans = Console.ReadLine();
		return "";
	}
}
