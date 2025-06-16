using System;
using System.Collections.Generic;
using System.Security.Principal;


class PrayingActivity : Activity
{	
	private static new string _activityName = "Praying";
	private static new string _description = "Prayer can be a great calming factor in your life. Think of what you need to pray for for yourself, your family, your friend or others. How might others pray for you?";
	//****Class Properties

	private static List<string> _whoNeedsPrayer = new List<string>();
	private static string _personPrayFor;

	private static List<string> _askFor = new List<string>();
	private static string _personAsk;

	private static List<string> _listToPrayForMe = new List<string>();
	private static string _personPrayForMe;

	private static List<string> _iNeed = new List<string>();
	private static string _forWhat;
	//private static int _thisActivityDuration = 0;
	//private static int _thisActivityTotalDuration = 0;
	private static int _thisActivityCount = 0;
	private static int _prayedForSomeone = 0;
	private static int _peopleAskedForMe = 0;
	//private static int _timerDuration  = 5;

	//****class Constructors

	public PrayingActivity() : base(_activityName, _description)
	{
		//DisplayDescription();
		GetActivityDurationInput();

		SetActivityDescription(_description);
		SetActivityName(_activityName);
		//SetActivityDuration(_activityDuration);
		DateTime start = StartTime();
		RunActivity();
		DateTime end = EndTime();
		int time = CalculateTime(start, end);
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
		Activity._activityCount = _thisActivityCount;
	}
	public static void SetPrayActivityName()
	{
		Activity._activityName = _activityName;
	}
	public void DisplayPrayerInfo()
	{
		Console.WriteLine($"You are doing the {_activityName} Activity, {_description}");
	}
	public void RunActivity()
	{
		_timerDuration = _activityDuration / 2; //split the activity for two parts
		Console.WriteLine($"How many people do you want to pray for?  Enter Integer up to 10.");
		string answer = Console.ReadLine();
		int selectNum = int.Parse(answer);
		int numberToPrayFor = selectNum;
		Console.WriteLine($"");
		Console.WriteLine($"");

		Console.WriteLine($"How many people will you ask to pray for you?  Enter Integer up to 10.");
		string answer2 = Console.ReadLine();
		int selectNum2 = int.Parse(answer2);
		int numberToPrayForYou = selectNum2;
		Console.WriteLine($"");
		Console.WriteLine($"");

		for (int i = 0; i < selectNum; i++)
		{
			Console.WriteLine($"What is the name of person #{i + 1} to pray for?");
			_personPrayFor = Console.ReadLine();
			_whoNeedsPrayer.Add(_personPrayFor);
			Console.WriteLine($"");

			Console.WriteLine($"What will you ask for?");
			string personAsk = Console.ReadLine();
			_askFor.Add(personAsk);
			Console.WriteLine($"");

			Console.WriteLine($"====>>> Pray now for {_personPrayFor} and ask for {personAsk}  <<<====");
			Console.WriteLine($"Timer will begin for you to pray for {_timerDuration} seconds.");
			Console.WriteLine($"");
			Console.WriteLine($"");
			//SpinnerTimer(_timerDuration);
			RunRandomTimerFromList(_timerDuration); //split activity time
													//CountDownTimer(_timerDuration);
			_prayedForSomeone++;

		}

		for (int j = 0; j < selectNum2; j++)
		{
			Console.WriteLine($"What is the name of person #{j + 1} you will ask to pray for you?");
			string personPrayForMe = Console.ReadLine();
			_listToPrayForMe.Add(personPrayForMe);
			Console.WriteLine($"");

			Console.WriteLine($"What do YOU need?");
			string _forWhat = Console.ReadLine();

			_iNeed.Add(_forWhat);
			Console.WriteLine($"Call or Text {personPrayForMe} NOW and ask for {_iNeed[j]}.");
			Console.WriteLine($"Timer for {_timerDuration} seconds will begin for call or text.");
			_peopleAskedForMe++;
			Console.WriteLine($"");
			Console.WriteLine($"");

			Console.WriteLine($"Timer will begin for you to contact {personPrayForMe}.");

			Console.WriteLine($"");
			Console.WriteLine($"");
			RunRandomTimerFromList(_timerDuration);
			//CountDownTimer(_timerDuration);
		}

		_activityCount += (_prayedForSomeone + _peopleAskedForMe);
		Console.WriteLine($"You Have Prayed for someone, and have asked someone to pray for you. You have spent {_activityDuration} seconds and {_activityCount} tasks! You have helped {_prayedForSomeone} people and {_peopleAskedForMe} Prayed for You.\n See what has happened because you trusted and prayed. \n");
		CountDownTimer(2);


		for (int k = 0; k < _whoNeedsPrayer.Count; k++)
		{
			Console.WriteLine($"*****  {_whoNeedsPrayer[k]} thanks you for asking God for {_askFor[k]}  *****");
			Console.WriteLine();
		}
		for (int l = 0; l < _listToPrayForMe.Count; l++)
		{
			Console.WriteLine($"*****  {_listToPrayForMe[l]} prayed and asked for you to have {_iNeed[l]}  *****");
			Console.WriteLine();
		}


		//_todaysTotalActivityDuration = _activityDuration + _todaysTotalActivityDuration;
		//Console.WriteLine($"This Activity Time is {_activityDuration}.Today your total time spent in {_activityName} activity is {_todaysTotalActivityDuration} seconds.");

		//WaitABit(4000);

	}
}



