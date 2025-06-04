using System;
using System.Collections.Generic;


public class ListeningActivity : Activity
{
	//****Class Properties
	private static string _activityName = "Listening";
	private static List<string> _focusPrompts = new List<string> { " A mindfulness activity to promote relaxation and focus.", "Breathing exercises to calm the mind and body." }; //required
																																												   //private static int _activityDuration = 2; // in minutes //required
	private static int _count = 0; // required	


	private static string _activitySound = "Bell";
	//private static string _activityDescription = "S"; //required
	private static bool _isActivityRunning = false;
	private static DateTime _activityStartTime;
	private static DateTime _activityEndTime;
	private static string _activityStatus = "Stopped";
	//	private static List<string> _activityDescriptions = new List<string>
	//	{"A mindfulness activity to promote relaxation and focus.",
	//		"Breathing exercises to calm the mind and body."
	//	};
	//****class Constructors

	public ListeningActivity(string _activityName, int _activityDuration)
		: base(_activityName, _activityDuration)
	{
		/*
		// Initialize the activity with default values
		_activityStartTime = DateTime.MinValue;
		_activityEndTime = DateTime.MinValue;
		_isActivityRunning = false;
		_activityStatus = "Not Started";
		Console.WriteLine($"{_activityType} initialized."); */
	}



	//*****Get/Set


	public string GetVariableName()
	{
		//gets internal variable

		return _activityName;
	}

	public void SetVariableName(string inName)
	{
		//sets the internal variable

		_activityName = inName;
	}

	//***** Class Methods

	public void RunActivity()
	{
		//doingsomething

	}
	public void GenerateRandomPrompt()
	{
		//doingsomething

	}
	public List<string> GetListFromUser()
	{
		//doingsomething
		List<string> inlist = new List<string> { "Prompt 1", "Prompt 2", "Prompt 3" }; // Example list	
		return inlist;
	}
	public void UserInput()
	{
		//doingsomething

	}

}



