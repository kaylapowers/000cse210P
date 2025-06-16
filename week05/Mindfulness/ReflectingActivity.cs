using System;
using System.Collections.Generic;


class ReflectingActivity : Activity
{
	private static new string _activityName = "Reflecting";
	private static new string _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

	//****Class Properties
	//private static int _activityDuration = 300;  //seconds
	private static List<string> _reflectingPrompts = new List<string>
		{
		"Why was this experience meaningful to you?",
		"What thoughts or feelings arose during the activity?",
		"Have you ever done anything like this before?",
		"How did you get started?",
		 "How did you feel when it was complete?",
		"What made this time different than other times when you were not as successful?",
		"What is your favorite thing about this experience?",
		"What could you learn from this experience that applies to other situations?",
		"What did you learn about yourself through this experience?",
		"How can you keep this experience in mind in the future?" };
	private static List<string> _promptQuestions = new List<string>
	{
	"Think of a time when you stood up for someone else.",
	"Think of a time when you did something really difficult.",
	"Think of a time when you helped someone in need.",
	"Think of a time when you did something truly selfless.",
};
	private static int _thisActivityCount = 0;

	//****class Constructors

	public ReflectingActivity() : base(_activityName, _description, _activityDuration = 20, _activityCount =0 )
	{
		GetActivityDurationInput();
		SetActivityDescription(_description);
		SetActivityName(_activityName);
		//SetActivityDuration(_activityDuration);
		DateTime start = StartTime();
		RunActivity();
		DateTime end = EndTime();
		int time = CalculateTime(start, end);
	}
	/*
	The activity should begin with the standard starting message and prompt for the duration that is used by all activities.
	The description of this activity should be something like:
	After the starting message, select a random prompt to show the user such as:
*/
	public static void SetActivityCount()
	{
		Activity._activityCount = _thisActivityCount;
	}

	/*
	After each question the program should pause for several seconds before continuing to the next one. While the program is paused it should display a kind of spinner.
	It should continue showing random questions until it has reached the number of seconds the user specified for the duration.
	The activity should conclude with the standard finishing message for all activities.

	*/



	public void RunActivity()
	{
		if (_activityDuration < 60)
		{
			Console.WriteLine($"Reflecting takes more time than  {_activityDuration} you entered. Adjusting it to minimum of 60 seconds. ");
			_activityDuration = 60;
		}
		int smallest;
		int lengthReflect = _reflectingPrompts.Count;
		int lengthQuest = _promptQuestions.Count;
		if (lengthReflect > lengthQuest)
		{
			smallest = lengthQuest;
		}
		else { smallest = lengthReflect; }

		//DisplayPromptQuestion();
		//gets internal variable
		DateTime startTime = DateTime.Now;
		DateTime endTime = startTime.AddSeconds(_activityDuration);


		while (DateTime.Now < endTime)
		{
			int _timerDuration = 20;
			DisplayPromptQuestion();
			Console.WriteLine();
			//RunRandomTimerFromList(_timerDuration);
			PlusMinusTimer(_timerDuration);

			//RunRandomTimerFromList(_timerDuration);
			DisplayReflectionPrompt();
			Console.WriteLine();
			RunRandomTimerFromList(_timerDuration);


		}

	}

	public void DisplayReflectionPrompt()
	{
		//gets a random prompt from the list of reflection prompts
		Random random = new Random();
		int index = random.Next(_reflectingPrompts.Count);
		Console.WriteLine($"********   {_reflectingPrompts[index]}    ********");
	}

	public void DisplayPromptQuestion()
	{
		//gets internal variable
		Random random = new Random();
		int index = random.Next(_promptQuestions.Count);
		Console.WriteLine($" ====>>   { _promptQuestions[index]}   <<====");

	}


}



