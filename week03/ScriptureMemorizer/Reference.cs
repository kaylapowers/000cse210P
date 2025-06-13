using System;
using System.Linq;

class Reference
{
	//	private static string _bookChpVerseString;
	private static int _chapter = 1;
	private static int _verseStart = 1;

	private static int _verseEnd;
	private static string verseEnd = "";
	private static string _book;
	private static string _delimitVerses = " ";
	private static string _bookChpVerseRefString;

	//default constuctor 

	public Reference()
	{

	}
	public Reference(string bookChpVerseRefString)
	{
		_bookChpVerseRefString = bookChpVerseRefString;
		//Console.WriteLine($"BookChpVerses: {bookChpVerseString}");
		//split into Joh 3:12-14 reference (Book, Chapter, startVerse, endVerse=0)
		string[] delimiters = [" ", ":", "-"];
		string[] parts = bookChpVerseRefString.Split(delimiters, 4, StringSplitOptions.TrimEntries);
		_book = parts[0];
		string chapter = parts[1];
		_chapter = int.Parse(chapter);
		string verseStart = parts[2];
		_verseStart = int.Parse(verseStart);
		int length = parts.Length;

		if (parts.Length > 3)
		{
			verseEnd = parts[3];
			_verseEnd = int.Parse(verseEnd);
			_delimitVerses = "-";
		}
		//Console.WriteLine($"Reference: {_book} {_chapter}:{_verseStart}{_delimitVerses}{_verseEnd}");


	}

	public string GetReferenceString()
	{
		//ing referenceString = new Reference();
		return _bookChpVerseRefString;
	}
	//class methods
	public string GetDisplayText()  //*required from program //could check format??
	{
		Console.WriteLine($" Ref GetDisplayText {_bookChpVerseRefString}");

		return _bookChpVerseRefString;
	}



	private static string waitABit()
	{
		Console.WriteLine("Waiting... press return key when ready.");
		Console.ReadLine();
		return "";


	}
}