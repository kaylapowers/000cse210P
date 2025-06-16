using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
	//****Class Properties
	private static new string _activityName = "Listing";
	private static new string _description = "This activity helps you reflect on the good things in your life by having you list as many things as you can in a certain area."; // required

	private static bool _timeIsOver = false;
	//private int _activityDuration = Activity._activityDuration; // in minutes //required
	private static int _inputCounts = 0; // required
	private static List<string> _userInputList = new List<string>();
	//required	
	private static List<string> _focusQuestions = new List<string>
	{
		"What did you hear during this activity?",
		"What thoughts or feelings arose during the activity?",
		"How did listening to others impact your perspective?",
		"Who are people that you appreciate?",
		"What are personal strengths of yours?",
		"Who are people that you have helped this week?",
		"When have you felt the Holy Ghost this month?",
		"Who are some of your personal heroes?"

	};




	public ListingActivity() : base(_activityName, _description, _activityDuration, _activityCount)
	{
		GetActivityDurationInput();
		SetActivityDescription(_description);
		SetActivityName(_activityName);
		//SetActivityDuration(_activityDuration);
		DateTime start = StartTime();
		RunActivity(_activityDuration);
		DateTime end = EndTime();
		int time = CalculateTime(start, end);


	}
	//Standard Message Opening   
	// get duration from user     
	// purpose message
	// random prompt for questions
	// display prompt
	// countdown and animation to ponder 
	// get a list of inputs from the user while counting down
	// //quit activity after coundown zero


	private static void RunActivity(int duration)
	{   //run standard opening


		GetListFromUser();
		listingStats();

	}

	private static void GetRandomPrompt()
	{
		int focusListLength = _focusQuestions.Count();
		int randomNum = GetRandomInteger(focusListLength, 0);
		string userPrompt = _focusQuestions[randomNum];
		Console.WriteLine($"Here is a Focus Question: {userPrompt}");

	}

	private static List<string> GetListFromUser()
	{
		_inputCounts =1;
		GetRandomPrompt();

		//Console.WriteLine($"Enter your answers to the prompt continuing line by line until time stops. ");
		Console.WriteLine($"Enter your answers to the prompt continuing line by line until time stops. ");
		if (_activityDuration < 20)
		{ _activityDuration = 20; }

		DateTime startTime = DateTime.Now;
		DateTime endTime = startTime.AddSeconds(_activityDuration + 2);

		while (DateTime.Now < endTime)
		{
			Console.WriteLine($"{_inputCounts++}: >>  ");
			string userInputString = Console.ReadLine();
			_userInputList.Add(userInputString);
			_activityCount = _inputCounts;
			ShowDotsTimer(1);
			//Console.Write($"\b \b");
			//Console.WriteLine();

		}

		return _userInputList;

	}

	private static void listingStats()
	{
		Console.WriteLine($"You completed {_activityDuration} seconds and listed {_inputCounts} items:");

	}
}



