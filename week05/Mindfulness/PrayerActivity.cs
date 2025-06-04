using System;
using System.Collections.Generic;


public class PrayerActivity : Activity
{
	private static string _activityName = "Prayer";
	//****Class Properties

	private static List<string> _promptQuestions = new List<string>
		{"A mindfulness activity to promote relaxation and focus.",
			"Breathing exercises to calm the mind and body." };
	private static List<string> _reflectionPrompts = new List<string> {"What did you learn about yourself during this activity?",
	"What thoughts or feelings arose during the activity?"};
	/*
			private static string _activityName = "Breathing Activity";
			private static int _activityDuration = 2; // in minutes
			private static int _count = 0; // in 
			private static string _activitySound = "Bell";
			private static bool _isActivityRunning = false;
			private static DateTime _activityStartTime;
			private static DateTime _activityEndTime;
			private static string _activityStatus = "Stopped";
			private static List<string> _focusQuestions = new List<string> { " A mindfulness activity to promote relaxation and focus.", "Breathing exercises to calm the mind and body." };

				*/

	//****class Constructors

	public PrayerActivity(string _activityName, int _activityDuration)
		: base(_activityName, _activityDuration)
	{
		// Initialize the activity with default values
		//	_activityStartTime = DateTime.MinValue;
		//	_activityEndTime = DateTime.MinValue;
		//	_isActivityRunning = false;
		//	_activityStatus = "Not Started";
		//	Console.WriteLine($"{_activityName} initialized.");
	}


	//*****Get/Set


	public void RunActivity(int duration)
	{
		//gets internal variable

	}

	public string GetRandomPrompt()
	{
		//gets a random prompt from the list of reflection prompts
		Random random = new Random();
		int index = random.Next(_reflectionPrompts.Count);
		return _reflectionPrompts[index];
	}

	public void GetRandomQuestion()
	{
		//gets internal variable
		Random random = new Random();
		int index = random.Next(_promptQuestions.Count);
		Console.WriteLine(_promptQuestions[index]);

	}

	public void DisplayRandomPrompt()
	{
		// Display a random prompt from the list of reflection prompts
		string prompt = GetRandomPrompt();
		Console.WriteLine($"Reflection Prompt: {prompt}");

	}

	public void DisplayRandomQuestion()
	{
		// Display a random question from the list of prompt questions

	}
	public void DisplayReflectionPrompt()
	{
		// Display a random reflection prompt
		string prompt = GetRandomPrompt();
		Console.WriteLine($"Reflection Prompt: {prompt}");
	}
}



