using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace JournalSpace
{
	class Program
	{

		//Kayla Powers
		//Stretch item- get a user name to display in opening
		//Stretch- adds username to beginning of default file name whic is global for change so each user can have own file to log journal items to. 

		//Stretch: Adds todays date to prompt greeting. -journal
		static void Main(string[] args)
		{
			//list of menu items- add new choices before Exit
			List<string> menuItems = new List<string> { "Load Journal", "Display Journal", "Save Journal", "Add Journal Entry", "Exit" }; //keep exit last on the list
			Console.Clear();
			//Gets the user name stretch item 
			string userName = GetUserName();
			string defaultFileEnd = "s_Journal.txt";
			string defaultFileName = userName + defaultFileEnd;


			string fileName = GetFileName(defaultFileName);
			///*********Journal Entry ***********
			/// 
			Journal userJournal = new Journal();

			userJournal._name = userName;
			userJournal._fileName = fileName;

			Console.WriteLine($"Hello {userName}! This is the Journal Project. Please pick menu item. ");

			bool exitProg = false;
			while (!exitProg)
			{

				//displays menu on console
				Console.WriteLine("");
				int exitNum = menuItems.Count; //no-parsing yet -Exit will be at end of list

				for (int i = 0; i < exitNum; i++)
				{
					int countNumber = i + 1;
					Console.WriteLine($"{countNumber}: {menuItems[i]}");
				}
				Console.Write(">> ");
				//user selection
				string userAnswer = Console.ReadLine();
				if (int.TryParse(userAnswer, out int choiceNumber))    //turn user input string integer 
				{
					int menuNum = choiceNumber - 1;

					if (menuNum == exitNum - 1) //EXIT
					{
						Console.WriteLine($"You chose {choiceNumber}: Exit. Press Return key to QUIT");
						Console.ReadLine();
						Environment.Exit(0);
					}
					else if   //Load Journal
						(menuNum == 0)
					{
						Console.WriteLine($"# {choiceNumber} Load Journal ");


						userJournal.LoadFromFile();
					}
					else if   //Display journal
					(menuNum == 1)
					{
						Console.WriteLine($"# {choiceNumber} Display Journal ");
						userJournal.DisplayAll();
					}
					else if //Save Journal
					(menuNum == 2)
					{
						Console.WriteLine($"# {choiceNumber} Save Journal ");
						userJournal.SaveToFile();
					}
					else if // Add Entry to Journal
					(menuNum == 3)
					{
						Console.WriteLine($"# {choiceNumber} Add Entry: ");
						userJournal.AddEntry();

					}
				}
				else

				{
					Console.WriteLine("Operation failed.");
				}

				//exitProg = ContinueProg();

			}//end main menu while loop


		}//end main


		static bool ContinueProg()
		{
			Console.WriteLine("Do you want to do something else? (y(es) or n(o)");
			string yesNo = Console.ReadLine();
			string yesNoUpper = yesNo.ToUpper();
			if ((yesNoUpper == "NO") || (yesNoUpper == "N"))
			{
				return true;
			}
			else return false;
		} //end ContinueProg


		static string GetUserName()
		{

			Console.WriteLine("Enter your Name: ");
			Console.Write("-->>  ");
			string name = Console.ReadLine();
			//Console.WriteLine($"Good day {name}! ");
			Console.Clear();
			return name;
			//error check input
		}//end GetUserName

		static string GetFileName(string fileName)
		{
			Console.WriteLine($"Default Filename will be: {fileName}");
			Console.WriteLine($"Enter a file name to use, or press enter to use default filename. ");


			string userAnswer = Console.ReadLine();
			if (userAnswer != "")
			{
				fileName = userAnswer;
			}

			// Get the project directory (the location of the .csproj file)
			//string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

			// Construct the full path to the file within bin/Debug
			//	string filePath = Path.Combine(projectDirectory, fileName);

			// Check if the file exists
			if (File.Exists(fileName))
			{
				Console.WriteLine($"file {fileName} Exists");

				//wait();
				Console.Clear();
				return fileName;


			}
			else
			{
				Console.WriteLine("File not found: " + fileName);
				return fileName;
			}

		} //end getfilename

		static void wait()
		{
			Console.WriteLine("Press ENTER key to continue:  ");
			Console.WriteLine("Waiting!");
			Console.ReadLine();

		} //end wait


	} //end program


} //end JournaSpace
