using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Timers;


class Activity
{

	private static int loopCount = 0;
	//****Class Properties
	private static string[] _userFileData;
	private static string _filePath = _filePathUser + _fileType;
	private static string _filePathUser = _userName;
	private static string _fileType = ".txt";
	private static List<string> _attaBoyGirlMessageList = new List<string> { "Keep it up!", "Great Work.", "One More Time!", "Smile, its contagious", "RA RA ZIP BOOM BA", "WHA HOOZE", "You're Doing Awesome Things!!!" };

	protected static string _activityName = "";
	protected static int _activityCount = 0;
	protected static string _description = "";

	private static List<string> _activityNamesList = new List<string> { "Reflecting", "Breathing", "Listing", "Praying" };

	private static List<string> _timerTypesList = new List<string> { "CountDownTimer", "PlusMinusTimer", "SpinnerTimer", "AnimateStringTimer", "SleepTimer", "ShowDotsTimer" };
	//private static string _startingMessage = $"Starting the {_activityName} exercise in ";
	private static string _timerType;
	private static DateTime _timerEndTime;

	protected static int _timerDuration = 20; // in seconds //required
	private static int _timerDurationMillisecs = 2000;

	private static string _userName = "New User";
	private static DateTime _activityStartTime;
	private static DateTime _totalTimeInActivity;
	private static DateTime _activityEndTime;
	private static int _numberUseActivity = 0;
	protected static int _todaysTotalActivityDuration = 0; //time using all activities today
	protected static int _thisActivityDuration = 0; // in seconds //required
	protected static int _activityDuration = 0; // in seconds //required
	
	//****class Constructors
	public Activity()
	{
		//MainMenu();

	}
	public Activity(string activityName, string description, int activityDuration=30, int activityCount=0)
	{
		_activityName = activityName;
		_description = description;
		_activityDuration = activityDuration;
		_timerDuration = 5;
		_activityCount = activityCount;
		//MainMenu(_activityName, _description);

	}
	public Activity(string activityName, string activityDescription)
	{
		//MainMenu(_activityName, _description);

	}

	public static void MainMenu()
	{
		if (_userName == "New User" || _userName == null)
		{
			GetUserName();
			//_userName = "Newbie";
		}
		StandardGreeting();
		SelectMenuFromList(_activityNamesList);
		//PreRunCountdown();
		//runs the activity

		StandardCloseMessage();
		RunRandomTimerFromList();
		//_filePath = SetFileName();
		//string outPutText = 
		//	SaveUserActivityData(_filePath, outPutText);
		//SelectMenuFromList(_activityNamesList);

	}

	public static void DisplayDescription()
	{
		Console.WriteLine($"You have done the {_activityName} Activity, {_description}");
	}
	private static void SelectMenuFromList(List<string> menuList)
	{
		// Declare a variable to hold the selected activity (if needed for further use)
		object activity = null;
		//4
		// _activityDuration = GetActivityDurationInput();

		Console.WriteLine($"Select a menu item to begin a Activity or Quit to exit.");

		int lengthMenu = menuList.Count;

		for (int j = 0; j < lengthMenu; j++)
		{
			Console.WriteLine($"{j + 1} {menuList[j]}");

		}
		Console.WriteLine($"{lengthMenu + 1} Quit");

		Console.Write($">> ");

		string answer = Console.ReadLine();
		int selectNum = int.Parse(answer);
		//int selectNum = 2;

		switch (selectNum)
		{
			case 1:
				activity = new ReflectingActivity();
				DisplayDescription();

				break;
			case 2:
				activity = new BreathingActivity();
				DisplayDescription();

				break;
			case 3:
				activity = new ListingActivity();
				DisplayDescription();

				break;
			case 4:
				activity = new PrayingActivity();
				DisplayDescription();
				break;
			case 5: //Quit
					//_quitProgram = true;
				Environment.Exit(0);
				break;
			default:
				Console.WriteLine("Unknown activity.");
				break;
		}
		//	_activityDuration = GetActivityDurationInput();
		Console.WriteLine();
		return;
		//return selectNum;
	}
	public static void StandardGreeting()
	{

		Console.WriteLine($"******** {_userName}, Welcome  to the Mindefullness Activity Menu  ****");
		Console.WriteLine($"Mindfullness has many different ways to bring our minds into the present, and learn to focus on things that bring JOY and Purpose into our lives. ");
		Console.WriteLine($"");
		Console.WriteLine($"******** {_userName}, You are about to begin your Journey -");
		ReadySetGoTimer(_timerDuration);
		Console.WriteLine($"");


	}


	public static void StandardCloseMessage(int activityCount = 0)
	{

		//Pick attaboy prompt
		Console.WriteLine($"AweSome, {_userName}, You completed Your goal in the {_activityName} Activity by  completing {_activityDuration} seconds. ");

		if (_activityCount != 0)
			Console.WriteLine($"You Also completed {_activityCount} items.");
		Console.WriteLine($"");

		GetAnAttaBoyGirl();
		//WaitABit(4000); ;
		//	Console.WriteLine($"");
		Console.WriteLine($"");

	}


	public static void SetActivityDescription(string description)
	{
		Activity._description = description;
	}
	public static void SetActivityDuration(int duration)
	{
		Activity._activityDuration = duration;
	}
	public static string getUserName()
	{
		return _userName;
	}
	public static void SetActivityName(string activityName)
	{

		Activity._activityName = activityName;
	}
	public static string GetActivityName()
	{

		return _activityName;
	}

	public static string WaitForReturnKey()
	{
		Console.WriteLine("Waiting... press return key when ready.");
		Console.ReadLine();
		return "";
	}
	public static void GetAnAttaBoyGirl()
	{
		Console.OutputEncoding = Encoding.UTF8;
		int listLength = _attaBoyGirlMessageList.Count();
		int selection = GetRandomInteger(listLength, 0);
		string message = _attaBoyGirlMessageList[selection];
		Console.WriteLine($"*****************  HEY YOU -- {message}  😎 !!! ******************");
		//return message;
	}
	public static void GetActivityDurationInput()
	{
		Console.Write($"Enter how long you want to do the activity in seconds: ==> ");
		string answer = Console.ReadLine();
		int selectNum = int.Parse(answer);
		_activityDuration = selectNum;
		_timerDuration = _activityDuration;

		//return _activityDuration;

	}
	public static int GetRandomInteger(int upper, int lower = 0)
	{
		// This method is used to generate a random number between lower and upper bounds
		Random random = new Random();
		int randomNumber = random.Next(lower, upper);
		//Console.WriteLine($"Random number generated: {randomNumber}");
		return randomNumber;

	}


	public static DateTime StartTime()
	{
		DateTime startTime = DateTime.Now;
		return startTime;
	}
	public static DateTime EndTime()
	{
		DateTime endTime = DateTime.Now;
		return endTime;
		//duration of activity

	}
	public static int CalculateTime(DateTime startTime, DateTime endTime)
	{
		TimeSpan elapsedTime = endTime - startTime;
		int roundedSeconds = (int)Math.Round(elapsedTime.TotalSeconds);
		return roundedSeconds;
		//duration of activity

	}
	private static void GetUserName()
	{
		Console.WriteLine("Enter your NAME: ");
		string userName = Console.ReadLine();
		if (userName != "")
		{
			_userName = userName;
		}
	}
	public static void WaitABit(int duration = 2000)
	{
		Thread.Sleep(duration);

	}

	public static void RunRandomTimerFromList(int timerDuration = 3)
	{

		int maxVal = _timerTypesList.Count();
		int minVal = 0;

		int randomNum = GetRandomInteger(maxVal, minVal);
		string timerName = _timerTypesList[randomNum].ToLower();

		//Console.WriteLine($"A Timer will now run for {timerDuration} seconds To allow you to do your exercise. ");


		switch (timerName)
		{
			case "sleeptimer":
				SleepTimer(timerDuration);
				break;
			case "showdotstimer":
				ShowDotsTimer(timerDuration);
				break;
			case "animatestringtimer":
				AnimateStringTimer(timerDuration);
				break;
			case "spinnertimer":
				SpinnerTimer(timerDuration);
				break;
			case "plusminus":
				PlusMinusTimer(timerDuration);
				break;
			case "countdowntimer":
				CountDownTimer(timerDuration);
				break;
			default:
				//Console.WriteLine("Timer not available");
				CountDownTimer(timerDuration);
				break;
				//return;
		}

	}

	//****************Timers
	public static void SpinnerTimer(int time = 20)
	{
		int t = 0;

		List<string> _spinnerString = new List<string>();
		_spinnerString.Add("|");
		_spinnerString.Add("/");
		_spinnerString.Add("-");
		_spinnerString.Add("\\");
		_spinnerString.Add("|");
		_spinnerString.Add("/");
		_spinnerString.Add("-");
		_spinnerString.Add("\\");

		int lengthOfString = _spinnerString.Count;

		DateTime startTime = DateTime.Now;
		DateTime endTime = startTime.AddSeconds(time);

		while (DateTime.Now < endTime)
		{
			if (t >= lengthOfString)
			{ t = 0; }

			string s = _spinnerString[t++];

			Console.Write(s);
			Thread.Sleep((time * 1000) / 16);
			Console.Write($"\b \b");
			//Console.WriteLine();

		}

		//Console.WriteLine("Done");

	}
	public static void CountDownTimer(int numSeconds = 5)
	{

		//Console.WriteLine($"GO!!! in {numSeconds} seconds"); // Erase the last character		

		for (int i = numSeconds; i > 0; i--)
		{
		
			Console.Write(i); // Erase the last character
			Thread.Sleep(1000);

			Console.Write("\b \b"); // Erase the last character		
		}
		Console.WriteLine();

	}

	public static void ReadySetGoTimer(int numSeconds=5)
	{
		numSeconds = 5;
		int i, j;

		string[] readySetGo = { "Ready", "SET", "GGGGOOOO..." };

		for ( i = 0; i < numSeconds; i++)
		{
			if (i < readySetGo.Length)
			{
				j = i;
			}
			else
			{ j = 2; }
			Console.WriteLine(readySetGo[j]); // Erase the last character
			Thread.Sleep(1000);

		}
		Console.WriteLine();

	}


	public static void AnimateStringTimer(int time = 10)
	{
		for (int t = 1; t < time; t++)
		{
			Console.Write("+ +");
			Thread.Sleep(500);
			Console.Write("\b \b"); // Erase the last character		
			Console.Write("-");
			Thread.Sleep(500);
		}
	}

	public static void SleepTimer(int seconds = 5)
	{
		if (_timerDuration > 5)
		{ seconds = 5; }

		// This method is used to pause the execution for a specified number of seconds
			Console.WriteLine($"Sleeping for {seconds} seconds...");
		System.Threading.Thread.Sleep(seconds); // Sleep for specified seconds
		Console.WriteLine("Sleep finished.");
		Console.WriteLine();

	}

	public static void PlusMinusTimer(int time = 10)
	{
		for (int i = 0; i < time; i++)
		{
			Console.Write("-");

			Thread.Sleep(500);
			Console.Write("\b \b"); // Erase the last character		

			Console.Write("+");
			Thread.Sleep(500);
		}
		//Console.WriteLine("\ndotcounter finished.");
		Console.WriteLine();

	}

	public static void ShowDotsTimer(int time = 10)
	{
		for (int i = 0; i < time; i++)
		{
			Console.Write("..");

			Thread.Sleep(500);
			Console.Write("\b \b"); // Erase the last character		

			Console.Write("*.");
			Thread.Sleep(500);
		}
		//Console.WriteLine("\ndotcounter finished.");
		Console.WriteLine();

	}

	public static void BreathingTimer(int seconds = 20)
	{
		if (loopCount == 0)
		{
			Console.WriteLine("Are you ready to BREATHE..");
			WaitForReturnKey();
		}
		List<string> breathOut = new List<string> { "B", "R", "E", "A", "T", "H", " ", "O", "U", "T" };
		List<string> breathHold = new List<string> { "H", "", "O", "", "L", "", " D ", "" };

		List<string> breathIn = new List<string> { "B", "R", "E", "A", "T", "H", " ", "I", "N", "" };
		Console.Clear();

		foreach (string letter in breathOut)
		{
			//Console.Clear();

			Console.Write($"  {letter}   ");
			System.Threading.Thread.Sleep(500); // Sleep for 1 second
			Console.Write("\b "); // Erase the last character

		}
		Console.Write(" "); // Erase the last character

		foreach (string letter in breathHold)
		{

			Console.Write($" - {letter}  ");
			System.Threading.Thread.Sleep(300); // Sleep for 1 second
			Console.Write("\b"); // Erase the last character
								 //Console.WriteLine(" "); // Erase the last character

		}
		Console.Write(" "); // Erase the last character

		foreach (string letter in breathIn)
		{
			Console.Write($"  {letter} ");
			System.Threading.Thread.Sleep(500); // Sleep for 1 second
			Console.Write("\b "); // Erase the last character

		}
		loopCount++;
		Console.WriteLine(" "); // Erase the last character

	}

}







