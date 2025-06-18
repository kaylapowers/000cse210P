using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public class SimpleGoal : Goal
{
	protected static List<string> _cluesForSimpleGoals = new List<string> { "Call or Text a Friend", "Take a gift", "Take a meal to a senior", "Give an hour of service", "Help a friend study the scriptures", "lose 5 pounds", "Exercise for 20 minutes.", "Walk 1 block", "Study 30 minutes", "Go to bed at same time for one week", "Do miindful exercise for 3 minutes" };
	private static int _index;
	private static string[] _detailsStringArray;
	//private static string _detailsString;
	public SimpleGoal(string name, string description, string points)
	: base(name, description, int.Parse(points))
	{

	}


	public override bool IsComplete()
	{
		if ((_numTimesNeeded == -1) || (_numTimesNeeded == _numTimesRecorded))
			//simple goals are complete on first record event
			_numTimesNeeded = -1;
			_checkBoxVal = "[✔️]";
			 return true; 
		
	}

	public override void RecordEvent(int index)
	{
		_index = index;
		_numTimesNeeded = -1;
		_totalAccumulatedPoints += _points;
		string instring = GetStringRepresentation();

		IsComplete();
		Console.WriteLine($"Recording Simple goal completion of {_name} -{_description} for {_points}");
		Console.WriteLine($"{_detailsString}");

		
	}

	public override string GetStringRepresentation()
	{
		_detailsStringArray = GoalManager.GetDetailsStringArray(_index);
		string emp = "";
		_detailsString = $"{_refNum}, {_name}, {_description}, {_points}, {_totalAccumulatedPoints}, {_checkBoxVal},{emp} ,{emp} ,{emp} ,{emp} ,{emp} ";
		return _detailsString;

	}
}