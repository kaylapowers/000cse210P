using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;


//namespace JournalSpace
//{
public class Journal
{
	public Entry newEntry = new Entry();
	public string _name; //******stretch
	public string _fileName; //*****stretch
							 //public List<Entry> _entries;
	public string todaysDate;

	public List<string> journalItems = new List<string>(); //dateString fieldSeparate promptString fieldSeparate entrtyString
	public List<Entry> _entries = new List<Entry>();
	public string fieldSeparate = "|"; //separate fields in file 

	// This class represents a journal class object
	//Journal purpose is to Display all, add to list, write journal to file, load journal from file
	public Journal()
	{

		//Class Methods
	}
	public void DisplayAll()
	{

		if (journalItems.Count == 0)
		{
			// n journal items loaded to display
			LoadFromFile();
		}
		int numJournalItems = journalItems.Count;
		if (numJournalItems > 0)
		{

			foreach (string item in journalItems)
			{
				//for (int i = 0; i < numJournalItems; i++)

				string[] parts = item.Split(fieldSeparate);
				string date = parts[0];
				newEntry._date = parts[0];

				string prompt = parts[1];
				newEntry._promptText = parts[1];
				string entrytext = parts[2];
				newEntry._entryText = parts[2];
				string stringLine = date + "- " + prompt + ": " + entrytext;
				//	Console.WriteLine(stringLine);
				//	string noSub = item.Replace(fieldSeparate, " "); //strips field separator
				//Console.WriteLine($"NoSub {noSub}");
				newEntry.Display(date, prompt, entrytext);
				//wait();

			}
		}
		else
		{
			Console.WriteLine($"{_name} There are no Items to Display yet- Please add a journal Entry! ");
			ExitProgram();
		}

	} //end display all

	public void AddEntry()
	{
		//if (journalItems.Count == 0)
		//{
		// no journal items loaded to display
		//	LoadFromFile(1);
		//}

		//elsef
		//{
		todaysDate = newEntry._date;
		Console.WriteLine($"So happy you are writing in your journal today {todaysDate} {_name}. "); //	Stretch 
																									 //newEntry._promptText = promptWrite;
		Console.WriteLine($"{newEntry._promptText} ");
		Console.WriteLine("Answer prompt or add your own topic. ");
		newEntry._entryText = Console.ReadLine();

		string lineCat = newEntry._date + fieldSeparate + newEntry._promptText + fieldSeparate + newEntry._entryText;

		journalItems.Add(lineCat);
		_entries.Add(newEntry);

		SaveToFile();
		//open _fileName for writing
		//wait();
		//}
	}

	public void SaveToFile()
	{
		Console.WriteLine($"Saving To FileName: {_fileName}"); //****Stretch
		try
		{
			//	string filetemp = _fileName + "T";

			//Pass the file path and file name to the StreamReader constructor
			StreamWriter sw = new StreamWriter(_fileName);

			//Continue to read until you reach end of file
			foreach (string item in journalItems)
			{
				//write the line to console window
				//	Console.WriteLine($"Writing: {item}"); ///***remove
				sw.WriteLine(item);
			}

			//foreach (Entry item in _entries)
			//	{
			//		Console.WriteLine($"_entries {item}"); ///***remove
			//		wait();
			//	}

			//close the file
			sw.Close();

		}
		catch (Exception e)
		{
			Console.WriteLine("Exception: " + e.Message);
		}
		finally
		{
			//Console.WriteLine("Executing Journal finally block.");
		}
		//	wait();
	} //save to file


	public void LoadFromFile(int num = 0)
	{
		//loads an array, and a list of entries from the file
		bool fileexists = File.Exists(_fileName);
		if (fileexists)
		{

			Console.WriteLine($"Loading from user file: {_fileName}"); //****Stretch

			try
			{
				//Pass the file path and file name to the StreamReader constructor
				StreamReader sr = new StreamReader(_fileName);
				//Read the first line of text

				string line = sr.ReadLine();
				//Continue to read until you reach end of file

				while (line != null)
				{
					//write the line to console window
					Console.WriteLine($"line {line}");

					//	string newline = line.Replace(fieldSeparate, "");
					journalItems.Add(line);


					//write to the List Entry File
					//_entries.Add(line);
					//Read the next line
					line = sr.ReadLine(); //readnext line
				}
				//close the file
				sr.Close();

			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.Message);
				//wait();
				//return;
			}

			finally
			{
				//	Console.WriteLine($"File {_fileName} is loaded.");
				//	wait();
			}
		}
		else
		{
			if (num == 0)
			{
				Console.WriteLine("File Doesn't Exist - Please Enter Journal Entries first. ");
				ExitProgram();
			}

		}

	} //load from file

	static void wait()
	{
		Console.WriteLine("Press ENTER key to continue:  ");
		Console.WriteLine("Waiting!");
		Console.ReadLine();

	} //end wait

	public void ExitProgram()
	{
		Environment.Exit(0);
	}

}
//}



