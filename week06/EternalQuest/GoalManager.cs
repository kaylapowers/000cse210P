using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
public class GoalManager
{
	protected static List<string> _EmojiRewardList = new List<string> { "➕", "🐈", "❤️", "🎉", "🤜", "🤛" };
	private static List<string> _attaBoyGirlMessageList = new List<string> { "Keep it up!", "Great Work.", "One More Time!", "Smile, its contagious", "RA RA ZIP BOOM BA", "WHA HOOZE", "You're Doing Awesome Things!!!" };


	private static List<string> _goalTypeList = new List<string> { "SimpleGoal", "ChecklistGoal", "EternalGoal" };
	private static List<string> _mainMenuList = new List<string> { "Dispay Player Info", "Create a Goal", "Record an Event", "List Goal Names", "List Goal Details", "Load Goals", "Save Goals", "Quit" };
	//private static List<Goal>;
	private static List<Goal> _listOfGoals = new List<Goal>();
	protected static string _detailsString; //string from fileio
	protected static string[] _detailsStringArray; //string from fileio

	//private static List<string> _stringRepresentationList = new List<string>();
	private static List<string> _stringRepresentationList = new List<string> {{"1, one, desciption a, 10, 0, [], 0, 1, 0/0, , "},
																			{"2, two, desciption vee, 20, 5, [], 2, 4, 2/4,5,0"},
																			{"3, three  me, another, 5,5, [],3, 4, 3/4, 5, 100"}};
 //{_refNum}, {_name}, {_description}, {_points}, {_totalAccumulatedPoints}, {_checkBoxVal}, {_numTimesRecorded}, {_numTimesNeeded}, {_status} , {_bonusAtLevel}, {_bonusPoints}
protected static List<string> _smartGoalsQuestList = new List<string> { "Specific- How Many/Much", "Measurable- How will i say task is completed", "Achievable- take small steps", "Relevant- Priority for you", "Time-Bound-> When will I be done?" };
	//private static Goal _myGoal = new Goal;
	private static bool _keepAdding = true;

	private static string _userName;
	private static string _welcomeMessage = "  Welcome to the Eternal Quest Goal Manager Program  ";

	private static string _sepStr = ","; //Field Separator
	private static int _goalType = -1; //
	private static int _refNum = 0; //


	private static string _name; //**of goal
	private static string _description;   //**
	private static int _points = 0;  //**
	private static int _totalAccumulatedPoints = 0; // *//'104' 

	private static int _numTimesNeeded = 0; //*//increment with recordevent
	private static int _numTimesRecorded = 0; //*//increment with recordevent
	private static int _bonusAtLevel = 5; // '3'*// 
	private static int _bonusPoints = 50; // *//'104' 

	private static string _checkBoxVal = "[ ]"; //*//" x complete of y- faults not completed
	private static string _status = "0/0"; //*//" x complete of y- faults not completed

	private static string _defaultFilePath = "goals.txt";

	public GoalManager()
	{


	}
	private static int CheckBonus()
	{
		Console.WriteLine("Checking for bonus level ");

		if (_bonusAtLevel != 0)
		{


			if (_bonusAtLevel - _numTimesRecorded + 1 == 0) //earned a bonus

			{
				//add 1 because this entry will make it plus one
				_bonusAtLevel = _bonusAtLevel * 2; // set a new bonus level automatically
				if (_bonusAtLevel > _numTimesNeeded)
				{ _bonusAtLevel = _numTimesNeeded; }
			}
			return _bonusPoints;

		}
		else
		{
			return 0;
		}


	}

	private static void GetUserName()
	{
		Console.WriteLine("Enter your NAME: ");
		string userName = Console.ReadLine();
		if (userName != "")
		{
			_userName = userName;
		}
		else _userName = "NewBie";
	}
	public static void WaitABit(int duration = 2000)
	{
		Thread.Sleep(duration);

	}
	public static void Start()
	{
		Console.WriteLine($"{_welcomeMessage}");
		Console.WriteLine($"");
		//GetUserName();
		_userName = "NEw Start";
		DisplayMainMenu();      //starts from here
		Console.WriteLine($"");

	}

	public static void DisplayMainMenu()
	{

		//Console.WriteLine($"******** {_userName}, Welcome  to Menu for the GoaLSetting Pony 🐎 ********");
		Console.WriteLine($"Please select your request. ");

		int lengthMenu = _mainMenuList.Count;

		for (int j = 0; j < lengthMenu; j++)
		{
			Console.WriteLine($"{j + 1} {_mainMenuList[j]}");

		}
		//Console.WriteLine($"{lengthMenu + 1} Quit");
		Console.Write($">> ");

		string answer = Console.ReadLine();
		int selectNum = int.Parse(answer);
		//int selectNum = 2;

		switch (selectNum)
		{
			case 1:
				Console.WriteLine("Dispaying Player Info");
				DisplayPlayerInfo();
				break;
			case 2:
				Console.WriteLine("Creating a Goal");
				CreateGoal();
				break;
			case 3:
				Console.WriteLine("Recording an Event");
				RecordEvent();
				break;
			case 4:
				Console.WriteLine("Listing Goal Names");
				ListGoalNames();
				break;
			case 5:
				Console.WriteLine("Listing Goal Details");
				ListGoalDetails();
				break;
			case 6:
				Console.WriteLine("Loading Goals");
				LoadGoals();
				break;
			case 7:
				Console.WriteLine("Saving Goals");
				SaveGoals();
				break;
			case 8:
				Console.WriteLine("Quit");
				ExitProgram();
				break;
			default:
				Console.WriteLine("Quitting Program");
				SaveGoals();

				break;
		}
		DisplayMainMenu();

	}
	public static int GetGoalType(string detailsString)
	{

		Console.WriteLine($"GetGoalType");

		if (_numTimesNeeded == 1) { _goalType = 1; }
		else if ((_numTimesNeeded == 0) || (_numTimesNeeded == -1))
		{ _goalType = 3; }  //eternal goal
		else { _goalType = 2; } //checklist goal
		Console.WriteLine($"");
		return _goalType;
	}
	public static void ExitProgram()
	{
		SaveGoals();

		Console.WriteLine($"");
		Console.WriteLine($"Exit Prg");
		//starts from here

	}
	public static void DisplayPlayerInfo()   //current score- points
	{
		int linePoints = 0;
		Console.WriteLine($"");
		Console.WriteLine($"Display player Total Score:");
		if (_stringRepresentationList == null)
		{

			Console.WriteLine($"You have no goals to Display- Please enter some. ");
			DisplayMainMenu();
		}
		else
		{
			foreach (var line in _stringRepresentationList)
			{
				string[] temp = SplitLineToArray(line);
				int points = 0;
				int.TryParse(temp[10], out points);
				linePoints += points;
			}
			Console.WriteLine($" Your Total Points: {linePoints};");

		}
	}

	public static void ListGoalDetails()
	{
		if (_stringRepresentationList == null)
		{

			Console.WriteLine($"You have no goals to Display- Please enter some. ");
			DisplayMainMenu();
		}
		else
		{
			Console.WriteLine($"");
			//writes list og goals             //name of goal save with create goal
			Console.WriteLine($"List Goal Details");
			Console.WriteLine($"");
			foreach (var line in _stringRepresentationList)
			{
				Console.WriteLine($"{line} ");

			}
			Console.WriteLine($"");
			Console.WriteLine($"");

		}

	}
	public static void ListGoalNames()
	{
		if (_stringRepresentationList == null)
		{
			Console.WriteLine($"You have no goals to Display- Please enter some. ");
			DisplayMainMenu();
		}
		else
		{
			Console.WriteLine($"List Goal NAmes");

			Console.WriteLine($"");
			foreach (var line in _stringRepresentationList)
			{
				string[] temp = SplitLineToArray(line);
				Console.WriteLine($"{temp[0]}: {temp[1]} ");

			}
		}
	}

	public static string ConvertIntToString(int intToString)
	{
		return intToString.ToString();


	}
	public static void CreateGoal()              //
	{ 
		//Console.WriteLine($"A SIMPLE goal would be a one time event. A Checklist Goal would have steps to get there, and Eternal Goal would be something you continually do towards long, long or eternal goals. ");
		///String Representation- refNum(int), name(of goal str), description(str), points(int), totalAccumulatedPoints (int),_numTimesNeeded(int), NumTimesRecorded(int), bonusAtLevel(int), bonus points(int), checkboxValue (string [] or [✔️] ), status (x of y| numTimesNeeded/numTimesRecorded) 
		/// 
		/// _detailsString addded to _goalsfileList list
		Console.WriteLine($"For this you need to have a goal Name, Description, and pointValue. ");

		while (_keepAdding)
		{
			_refNum++;


			Console.WriteLine($"Enter the Goal Name:");
			_name = Console.ReadLine();
			Console.WriteLine($"Enter the Goal Description:");
			_description = Console.ReadLine();
			Console.WriteLine($"Enter the Point Value:");
			_points = int.Parse(Console.ReadLine()); //each time
													 //	Console.WriteLine($"Enter the Total Accumulated Points:");
													 //	_totalAccumulatedPoints = int.Parse(Console.ReadLine()); // '104' 
			_totalAccumulatedPoints = 0; // '104' 
			Console.WriteLine($"Enter the Number of Times Needed to complete the goal- Enter -1 for an eternal goal:");

			_numTimesNeeded = int.Parse(Console.ReadLine()); // '3' 

			if (_numTimesNeeded > 1)
			{
				Console.WriteLine($"Enter an integer for every x times to receive bonus:");
				_bonusAtLevel = int.Parse(Console.ReadLine()); // '104' 

				Console.WriteLine($"Enter the Bonus Points to award");
				_bonusPoints = int.Parse(Console.ReadLine()); // '3' 


			}
			else
			{
				_bonusAtLevel = 0;
				_bonusPoints = 0;
			}
			_numTimesRecorded = 0; //increment with recordevent
			_status = _numTimesRecorded.ToString() + "/" + _numTimesNeeded.ToString(); //"0/0"// '2/5' 
			_checkBoxVal = "[ ]"; //defaults when making goal

			_detailsString = _refNum.ToString() + _sepStr + _name + _sepStr + _description + _sepStr + _points.ToString() + _sepStr + _totalAccumulatedPoints.ToString() + _sepStr + _checkBoxVal + _sepStr + _numTimesRecorded.ToString() + _sepStr + _numTimesNeeded.ToString() + _sepStr + _status + _sepStr + _bonusAtLevel.ToString() + _sepStr  + _bonusPoints.ToString();
			if (_stringRepresentationList == null)
			{
				_stringRepresentationList = new List<string>();
			}
			_stringRepresentationList.Add(_detailsString);
			Console.WriteLine($"{_detailsString}");
			Console.WriteLine($"");

			Continue();
			//enter goal name, details (checkbox, iscomplete, to string list add to list)
		}
	}

	public static bool Continue()
	{
		string answer;
		Console.WriteLine($"Do you want to add more goals? yes or no");
		answer = Console.ReadLine();
		if ((answer.ToLower() == "yes")  || (answer.ToLower() == "y")) //default errors to stop entering
		{
			_keepAdding = true;
		}
		else
		{ _keepAdding = false; }

		return _keepAdding;
	}
	public static int GetUserInputInt()
	{
		Console.WriteLine($"Please enter a integer selection:");
		string answer = Console.ReadLine();
		int result;
		if (int.TryParse(answer, out result))
		{
			return result;
		}
		else
		{
			Console.WriteLine("Invalid input. Please enter a valid integer.");
			return GetUserInputInt();
		}
	}


		public static string[] GetDetailsStringArray(int index)
	{
		string lineString = _stringRepresentationList[index];
		string[] detailsStringArray = SplitLineToArray(lineString);
		return detailsStringArray;
	}
	

	public static void RecordEvent()   //ask user which goal (menu) they did then call recordevent for that goal
	{
		//LoadGoals(); //loads the array
		ListGoalNames();
		//ASK user which goal (list via menu) to update
		Console.WriteLine($"");
		//get that value from input list
		Console.WriteLine($"Enter the Goal # that you wish to update: ");
		int index = GetUserInputInt();
		if (index < 0 || index > _stringRepresentationList.Count)
		{ RecordEvent(); }
		else
		{
			Console.WriteLine($"Recording a completion of a goal event for {_stringRepresentationList[index]}");
			//_detailsString = ;
			//SpitLineToArray(_stringRepresentationList[index]);
			_points += CheckBonus();
			int goalType = GetGoalType(_detailsString);

			switch (goalType)
				{
					case (1):
						SimpleGoal _goal1 = new SimpleGoal(_name, _description, _points.ToString());
						break;
					case (2):
						ChecklistGoal _goal2 = new ChecklistGoal(_name, _description, _points.ToString(), _bonusAtLevel, _bonusPoints);

						break;

					case (3):
						EternalGoal _goal3 = new EternalGoal(_name, _description, _points.ToString());

						break;
				}
		}

	}

	public static void SaveGoals()          //to file
	{// int#, name, description, # times Needed, PointValue each,  # times completed, Total points,  IsCompleted checkbox, BonusLevel1, BonusVal1, status value x of y completed/

		Console.WriteLine($"Saving Goals");
		using (StreamWriter outputFile = new StreamWriter(_defaultFilePath))
			//list the list by line of the list file 
			foreach (var line in _stringRepresentationList)
			{
				Console.WriteLine($"{line}");
				outputFile.WriteLine($"{line}");
			}

	}
	public static string[] SplitLineToArray(string stringLine)           //fromFile
	{
		///String Representation- refNum(int), name(of goal str), description(str), points(int), totalAccumulatedPoints (int),_numTimesNeeded(int), NumTimesRecorded(int), bonusAtLevel(int), bonus points(int), checkboxValue (string [] or [✔️] ), status (x of y| numTimesNeeded/numTimesRecorded) 
		//remove completed goals- why simple goal doesnt use iscomplete
		//_stringRepresentation = System.IO.File.ReadAllLines(_defaultFilePath); //stringarray of lines
		//string _stringLine = _stringRepresentationList[index];
		
		//	Console.WriteLine($"Parsing {stringLine}");
			_detailsStringArray = stringLine.Split(",");

			int.TryParse(_detailsStringArray[0], out _refNum);
			_name = _detailsStringArray[1];
			_description = _detailsStringArray[2];
			//		int.TryParse(_detailsStringArray[3], out _points);
			int.TryParse(_detailsStringArray[4], out _totalAccumulatedPoints);
			int.TryParse(_detailsStringArray[5], out _numTimesNeeded);
			int.TryParse(_detailsStringArray[6], out _numTimesRecorded);
			int.TryParse(_detailsStringArray[7], out _bonusAtLevel);
			int.TryParse(_detailsStringArray[8], out _bonusPoints);
			_checkBoxVal = _detailsStringArray[9];
			_status = _detailsStringArray[10];
		return _detailsStringArray;
	}
	public static void LoadGoals()           //fromFile
	{
		///String Representation- refNum(int), name(of goal str), description(str), points(int), totalAccumulatedPoints (int),_numTimesNeeded(int), NumTimesRecorded(int), bonusAtLevel(int), bonus points(int), checkboxValue (string [] or [✔️] ), status (x of y| numTimesNeeded/numTimesRecorded) 
		_detailsStringArray = System.IO.File.ReadAllLines(_defaultFilePath); //stringarray of lines
		foreach (string _stringLine in _detailsStringArray)
		{
			Console.WriteLine($"{_stringLine}");
			_detailsStringArray = _stringLine.Split(",");

			int.TryParse(_detailsStringArray[0], out _refNum);
			_name = _detailsStringArray[1];
			_description = _detailsStringArray[2];
			int.TryParse(_detailsStringArray[3], out _points);
			int.TryParse(_detailsStringArray[4], out _totalAccumulatedPoints);
			int.TryParse(_detailsStringArray[5], out _numTimesNeeded);
			int.TryParse(_detailsStringArray[6], out _numTimesRecorded);
			int.TryParse(_detailsStringArray[7], out _bonusAtLevel);
			int.TryParse(_detailsStringArray[8], out _bonusPoints);
			_checkBoxVal = _detailsStringArray[9];
			_status = _detailsStringArray[10];
			//remove completed goals- why simple goal doesnt use iscomplete
			_detailsString = _detailsString = _refNum.ToString() + _sepStr + _name + _sepStr + _description + _sepStr + _points.ToString() + _sepStr + _totalAccumulatedPoints.ToString() + _sepStr + _checkBoxVal + _sepStr + _numTimesRecorded.ToString() + _sepStr + _numTimesNeeded.ToString() + _sepStr + _status + _sepStr + _bonusAtLevel.ToString() + _sepStr + _bonusPoints.ToString();
			_stringRepresentationList.Add(_detailsString);
		}

		Console.WriteLine($"");
	}
	string GetUserInput()
	{
		Console.Write($">> ");
		return Console.ReadLine();
	}

	public static void StandardCloseMessage()
	{

		Console.WriteLine($"AweSome, {_userName}, Today you did this... ");
		GetAnAttaBoyGirl();
		Console.WriteLine($"");

	}
	public static void GetAnAttaBoyGirl()
	{
		//Console.OutputEncoding = Encoding.UTF8;
		int listLength = _attaBoyGirlMessageList.Count();
		int selection = GetRandomInteger(listLength, 0);
		string message = _attaBoyGirlMessageList[selection];
		int listLengthEmojis = _EmojiRewardList.Count();
		int selectionE = GetRandomInteger(listLength, 0);

		Console.WriteLine($"*****************  HEY YOU -- {message}  {selectionE} !!! ******************");
		//return message;
	}
	public static string WaitForReturnKey()
	{
		Console.WriteLine("Waiting... press return key when ready.");
		Console.ReadLine();
		return "";
	}
	public static int GetRandomInteger(int upper, int lower = 0)
	{
		// This method is used to generate a random number between lower and upper bounds
		Random random = new Random();
		int randomNumber = random.Next(lower, upper);
		//Console.WriteLine($"Random number generated: {randomNumber}");
		return randomNumber;

	}

	public static int CalculateTime(DateTime startTime, DateTime endTime)
	{
		TimeSpan elapsedTime = endTime - startTime;
		int roundedSeconds = (int)Math.Round(elapsedTime.TotalSeconds);
		return roundedSeconds;
		//duration of activity
	}
	public static string EndTime()
	{
		DateTime endTime = DateTime.Now;
		string endTimeStamp = "";
		return endTimeStamp;

	}
	public static DateTime StartTime()
	{
		DateTime startTime = DateTime.Now;
		return startTime;
	}


}