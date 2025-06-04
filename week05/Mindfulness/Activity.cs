using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System;

public class Activity
{
	//****Class Properties
	private static string _activityName = "Mindfulness Activity"; //required
	private static int _activityDuration = 2; // in minutes //required
	private static string _activityDescriptions = "A mindful Exercise";  //required

	private static List<string> _activityNames = ["Breathing", "Listening", "Reflection", "Movement", "Prayer", "Visualization"];
	static string _breaths;
	//	private static string _activitySound = "Bell";
	//private static bool _isActivityRunning = false;
	//private static DateTime _activityStartTime;
	//private static DateTime _activityEndTime;
	//private static string _activityStatus = $"Notprivate static string activityType {_activityType}";
	private static string _activityType = "None";
	private static string _activityDescription = "A mindfulness activity to promote relaxation and focus.";
	//private static List<string> _timerTypes = ["Spinner", "dots", "countdown", "breathing", "showSpinner"];
	//private static List<string> _focusQuestions = new List<string> { " A mindfulness activity to promote relaxation and focus.", "Breathing exercises to calm the mind and body." };


	//****class Constructors

	public Activity(string name, int duration)
	{
		_activityName = name; // required
		_activityDuration = duration * 1000; // in seconds

		//_activityDescription = description;

		/*
		// Initialize the activity with provided values
		
		_activitySound = sound;
		_isActivityRunning = false;
		_activityStartTime = DateTime.MinValue;
		_activityEndTime = DateTime.MinValue;
		_activityStatus = "Not Started";*/
	}



	//*****Get/Set

	//****** Class Methods
	public string DisplayStartingMessage()
	{
		return "";

	}
	public string DisplayEndingMessage()
	{
		return "";

	}
	private void TrackActivity()
	{
		/*
		// This method is used to initialize the activity
	Console.WriteLine("Initializing activity...");
		_activityStartTime = DateTime.Now;
		_activityStatus = "In Progress";
		_isActivityRunning = true;
		Console.WriteLine($"{_activityName} started at {_activityStartTime}.");*/
	}
	private static void Randomizer(int lower, int upper)
	{   /*
		// This method is used to generate a random number between lower and upper bounds
		Random random = new Random();
		int randomNumber = random.Next(lower, upper);
		Console.WriteLine($"Random number generated: {randomNumber}");
		*/
	}
	public void RunActivity(string activityName, int duration)
	{
		// This method is used to run the activity with the specified name and duration
		Console.WriteLine($"Running activity: {activityName} for {duration} minutes.");
		_activityName = activityName;
		_activityDuration = duration;
		//InActivity();
		//ShowSpinner(3);
		//ShowCountdown(duration * 60);
		Console.WriteLine($"{activityName} completed.");
	}

	private void Pausing(int duration)
	{
		/*
		// This method is used to pause the activity
		Console.WriteLine("Pausing activity...");
		if (_isActivityRunning)
		{
			_activityEndTime = DateTime.Now;
			_activityStatus = "Paused";
			_isActivityRunning = false;
			Console.WriteLine($"{_activityName} paused at {_activityEndTime}.");
		}
		else
		{
			Console.WriteLine("Activity is not currently running.");
		}
		*/
	}
	public void AnimateString(string old, string newOne, int _duration)
	{
		Console.Write("old");
		Thread.Sleep(_duration);
		Console.Write("\b \b"); // Erase the last character		

		Console.Write(newOne);
		Thread.Sleep(_duration);
	}

	public void SleepTime(int seconds)
	{
		// This method is used to pause the execution for a specified number of seconds
		Console.WriteLine($"Sleeping for {seconds} seconds...");
		System.Threading.Thread.Sleep(seconds * 1000); // Sleep for specified seconds
		Console.WriteLine("Sleep finished.");
	}



	public static void ShowDots(int seconds)
	{
		/*
		// This method is used to show a spinner for a specified number of seconds
		Console.WriteLine("Showing spinner for {0} seconds...", seconds);
		for (int i = 0; i < seconds; i++)
		{
			Console.Write(".");
			System.Threading.Thread.Sleep(1000); // Sleep for 1 second
		}
		Console.WriteLine("\nSpinner finished.");
		*/
	}


	public static void ShowCountDown(int seconds)
	{

		// This method is used to show a countdown for a specified number of seconds
		Console.WriteLine("Countdown starting...");
		for (int i = seconds; i > 0; i--)
		{
			Console.Clear();

			Console.Write($"{i} ");
			System.Threading.Thread.Sleep(1000); // Sleep for 1 second
			Console.Write("\b \b"); // Erase the last character

		}
		Console.WriteLine("\nCountdown finished.");

	}

	public static void Breathing(int seconds)
	{
		//Console.WriteLine("In this exercise, you will breathe out, hold, and breath in.");

		//Console.WriteLine("GET READY TO BREATH.... Take a Deep Breath IN and Push Enter to Begin...");
		//	Console.ReadLine(); // Wait for user to press Enter
		Console.Clear(); // Clear the console
		Thread.Sleep(500); // Sleep for 1 second
		List<string> _breatheOut = new List<string> { "B", "R", "E", "A", "T", "H", "E", " ", "O", "U", "T" };
		List<string> _breatheHold = new List<string> { "H", "", "", "O", "", "", "L", "", "", "D", "", "" };
		List<string> _breatheIn = new List<string> { "B", "R", "E", "A", "T", "H", "E", " ", "I", "N", "" };


		// Clear the console before starting the countdown	
		Console.Clear();

		foreach (string s in _breatheOut)
		{

			Console.Write($"{s} -");
			Console.WriteLine();
			Thread.Sleep(250); // Sleep for.4 second
			Console.Write("\b \b"); // Erase the last character

		}

		foreach (string s in _breatheHold)
		{
			Console.Clear();
			Console.WriteLine();

			Console.Write($"{s}  ");
			Thread.Sleep(200);
			Console.Write($"{s}  ");



			Thread.Sleep(500); // Sleep for .4 second
							   //Console.Write("\b \b"); // Erase the last character
			Console.Clear();

		}

		foreach (string s in _breatheIn)
		{

			Console.WriteLine($"        {s} + ");
			Console.WriteLine();
			Thread.Sleep(250); // Sleep for.4 second
							   //Console.Write("\b \b"); // Erar

		}
		Console.WriteLine("\nCountdown finished.");

	}


	public static void ShowSpinner(int seconds)
	{
		// This method is used to show a countdown for a specified number of seconds

		Console.WriteLine("Countdown starting...");
		System.Threading.Thread.Sleep(1000); // Sleep for 1 second

		List<string> animationFrames = new List<string> { "|", "/", "-", "\\", "|", "/", "-", "\\" };


		// Clear the console before starting the countdown	
		Console.Clear();

		foreach (string s in animationFrames)
		{
			Console.Write($"{s}");
			Thread.Sleep(1000); // Sleep for 1 second
			Console.Write("\b \b"); // Erase the last character

		}
		Console.WriteLine("\nCountdown finished.");
	}

}





