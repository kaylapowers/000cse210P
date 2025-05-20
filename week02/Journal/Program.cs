using System;


class Program
{
	/*
			void GetUserName()
			{
				Console.WriteLine("Enter your Name: ");
				string name = ConsoleReadLine();
				//error check input
			} */
	static void Main(string[] args)
	{
		/*
		List<string> menuItems = new List<string> { "Load Journal", "Display Journal", "Save Journal", "Add Journal Entry", "Exit" }; //keep exit last on the list


		bool exitProg = false;
		Console.WriteLine("Hello World! This is the Journal Project. Please pick menu item. ");

		//Journal userJournal = new Journal();

		//	userJournal.AddEntry("anEntry");

		while (!exitProg)
		{
			Console.WriteLine("");
			int exitNum = menuItems.Count; //Exit will be at end of list
										//writes the menu to the screen
			for (int i = 0; i < exitNum; i++)
			{
				int countNumber = i + 1;
				Console.WriteLine($"{countNumber}: {menuItems[i]}");
			}
			Console.Write(">> ");
			string userAnswer = Console.ReadLine();
			if (int.TryParse(userAnswer, out int choiceNumber))    //turn user input string  integer 
			{
				int menuNum = choiceNumber - 1;
				//	Journal journal = new Journal();
				if (menuNum == exitNum - 1) //EXIT
				{
					Console.WriteLine($"You chose {choiceNumber}: Exit. Press any key to ntinue");
					string dud = Console.ReadLine();
					exitProg = true;
					break;
				}
				else if   //Load Journal
					(menuNum == 0)
				{
					Console.WriteLine($"# {choiceNumber} Load Journal ");
				}
				else if   //Display journal
				(menuNum == 1)
				{
					Console.WriteLine($"# {choiceNumber} Display Journal ");
					//		journal.DisplayAll();
				}
				else if //Save Journal
				(menuNum == 2)
				{
					Console.WriteLine($"# {choiceNumber} Save Journal ");
					//		journal.SaveToFile();
				}
				else if // Add Entry to Journal
				(menuNum == 3)
				{
					Console.WriteLine($"# {choiceNumber} Add Entry: ");
				}
			}
			else
			{
				Console.WriteLine("Operation failed.");
			}
		}
	}*/
	}
}