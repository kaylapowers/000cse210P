using System;
using System.Collections.Generic;
using System.Threading;
// MindfulnessTimer.cs

public class MindfulnessTimer
{
	//*class proqerties
	private static string timerType = "Timer";
	private static string timerName = "Mindfulness Timer";
	private static int timerDuration = 5; // in minutes
	private static string timerSound = "Bell";
	private static bool isTimerRunning = false;
	private static DateTime timerStartTime;
	private static DateTime timerEndTime;
	private static string timerStatus = "Stopped";

	//****class Constructors

	public MindfulnessTimer()
	{
		// Initialize the timer with default values
	}



	//*****Get/Set


	public void GetVariableName()
	{


	}

	public void SetVariableName()
	{


	}

	//***** Class Methods

	public void StopTimer()
	{
		/*
		// Stop the timer
		isTimerRunning = false;
		timerStatus = "Stopped";
		Console.WriteLine($"{timerName} stopped.");  */
	}

	public void ResetTimer()
	{
		/*
	// Reset the timer
	isTimerRunning = false;
	timerStartTime = DateTime.MinValue;
	timerEndTime = DateTime.MinValue;
	timerStatus = "Reset";
	Console.WriteLine($"{timerName} reset to {timerDuration} minutes."); */

	}
	public void StartTimer()
	{
		/*
		// Start the timer
		isTimerRunning = true;
		timerStartTime = DateTime.Now;
		timerEndTime = timerStartTime.AddMinutes(timerDuration);
		timerStatus = "Running";
		Console.WriteLine($"{timerName} started for {timerDuration} minutes."); */
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



	public void ShowDots(int seconds)
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


	public void ShowCountdown(int seconds)
	{
		/*
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
		*/
	}

	public void Breathing(int seconds)
	{
		/*
		// This method is used to show a countdown for a specified number of seconds

		Console.WriteLine("Countdown starting...");
		System.Threading.Thread.Sleep(seconds * 1000); // Sleep for 1 second
		list<string> BreathOut = new List<string> { "B", "R", "E", "A", "T", "H", " ", "O" , "U", "T" };
		list<string> BreathHold = new List<string> { "H", "", "O", "", "L", "", " D ", ""  };

		list<string> BreathIn = new List<string> { "B", "R", "E", "A", "T", "H", " ", "I" , "N", "" };
		foreach (string frame in animationFrames)
		{
		animationFrames.Add(frame);

		}

			// Clear the console before starting the countdown	
		Console.Clear();

			for (int i = seconds; i > 0; i--)
		{
			Console.Write($"{animationFrames[i % animationFrames.Count]} ");
			System.Threading.Thread.Sleep(1000); // Sleep for 1 second
			Console.Write("\b \b"); // Erase the last character

		}
		Console.WriteLine("\nCountdown finished.");
		*/
	}

	public void ShowSpinner(int seconds)
	{
		/*
		// This method is used to show a countdown for a specified number of seconds

		Console.WriteLine("Countdown starting...");
		System.Threading.Thread.Sleep(1000); // Sleep for 1 second

		list<string> animationFrames = new List<string> { "|", "/", "-", "\\", "|", "/", "-", "\\" };
		foreach (string frame in animationFrames)
		{
		animationFrames.Add(frame);

		}

			// Clear the console before starting the countdown	
		Console.Clear();

			for (int i = seconds; i > 0; i--)
		{
			Console.Write($"{animationFrames[i % animationFrames.Count]} ");
			System.Threading.Thread.Sleep(1000); // Sleep for 1 second
			Console.Write("\b \b"); // Erase the last character

		}
		Console.WriteLine("\nCountdown finished.");
		*/
	}


}

