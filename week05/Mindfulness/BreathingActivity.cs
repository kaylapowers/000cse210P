using System;
using System.Collections.Generic;


public class BreathingActivity : Activity
{
	private static string _activityName = "Breathing Activity";
	private static int _activityDuration = 2; // in seconds
	private static int _count = 0; // in 

	/*
		//****Class Properties
		
		private static string _activitySound = "Bell";
		private static bool _isActivityRunning = false;
		private static DateTime _activityStartTime;
		private static DateTime _activityEndTime;
		private static string _activityStatus = "Stopped";
		private static List<string> _focusQuestions = new List<string> { " A mindfulness activity to promote relaxation and focus.", "Breathing exercises to calm the mind and body." };
		private static List<string> _activityDescriptions = new List<string>
		{"A mindfulness activity to promote relaxation and focus.",
			"Breathing exercises to calm the mind and body."
			*/

	//****class Constructors

	public BreathingActivity(string _activityName, int _activityDuration)
		: base(_activityName, _activityDuration)
	{
		// Optionally, you can initialize additional BreathingActivity-specific fields here.
	}






	public void RunActivity()
	{
		//doingsomething

	}

}



