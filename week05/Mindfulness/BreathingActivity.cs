using System;
using System.Collections.Generic;

class BreathingActivity : Activity
{
	private static new  string _activityName = "Breathing";
	private static new string _description = "The ability to control your breathing can help calm you on a stressful day. In this exercize you tried to breathe in, hold, and breathe out with the breathing timer. Try to focus on the breath, and count each time you breathe out. "; //private static int _count = 0; // in 
	private static int _breathCount = 0;
	private static int _breaths = 0;
	private static int _breathingRate;


	public BreathingActivity() : base(_activityName, _description, _activityDuration, _activityCount)
	{
		DisplayDescription();
		GetActivityDurationInput();
		_timerDuration = _activityDuration;
		SetActivityDescription(_description);
		SetActivityName(_activityName);
		//SetActivityDuration(_activityDuration);
		DateTime start = StartTime();
		RunActivity();
		DateTime end = EndTime();
		int time = CalculateTime(start, end);
	}

	private static void RunActivity()
	{ //	DisplayDescription();

		DateTime startTime = DateTime.Now;
		DateTime endTime = startTime.AddSeconds(_activityDuration);

		while (DateTime.Now < endTime)
		{
			int time = _activityDuration / 4;

			BreathingTimer(time);
			WaitABit(500);
			_breaths++;

		}
	}
	public static void SetActivityDescription()
	{
		Activity._description = _description;
	}
	public static void SetActivityDuration()
	{
		//	Activity._activityDuration = _activityDuration;
	}
	public static void SetActivityCount()
	{
	//	Activity._activityCount = _thisActivityCount;
	}
	public static void SetPrayActivityName()
	{
		Activity._activityName = _activityName;
	}


	private static void BreathCount()
	{
		_breathingRate = 60 * _breaths / _activityDuration;
		Console.WriteLine($"If you breathed with the timer, you should have been at the rate of {_breathingRate} Breaths per minute.");

		Console.WriteLine($"How many breaths did you take during the exercise?");

		string _userInputString = Console.ReadLine();
		_breaths = int.Parse(_userInputString);
		int breathsPerMinute = (60 / _activityDuration) * _breathCount;
		Console.WriteLine($"Normal breathing is 12 - 15 breaths per minute.");
		Console.WriteLine($"You breathed at a rate of {breathsPerMinute} breaths per minute!!");

	}

}



