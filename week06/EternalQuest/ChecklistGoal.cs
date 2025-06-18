using System.IO;
using System;
using System.Collections.Generic;

public class ChecklistGoal : Goal
{
	// Removed unused GoalManager instantiation to resolve ambiguity and simplify code.
	protected static List<string> _cluesForChecklistGoals = new List<string> { "3 daily prayers", "temple Visit", "20 minutes of scripture study", "Institue Class", "Face to Face Sacrament Meeting", "Giving Testimony", "Giving monthly tithe", "Completing a church responsibility" };
	private static int _numCompleted;
	private static int _index;
	private static string[] _detailsStringArray;
	//private static string _detailsString;


	public ChecklistGoal(string name, string description, string points, int target, int bonus)
		: base(name, description, int.Parse(points))
	{
		_bonusAtLevel = target;  //the y of x of y completions- t
		_bonusPoints = bonus;	 // bonus value for getting to the y target value
	}


	public override bool IsComplete()
	{


		if (_numTimesNeeded == _numTimesRecorded) //iscomplete
		{
			_totalAccumulatedPoints += _bonusPoints;
			_checkBoxVal = "X";
			return true;
		}
		else
		{
			_status = _numTimesRecorded + "/" + _numTimesNeeded;
			return false;
		}
	}


	public override void RecordEvent( int index)
	{
		_index = index;
		Console.WriteLine($"Recording Checklist goal completion of {_name} -{_description} for {_points}");

		_numTimesRecorded++;
		_numCompleted--;
		IsComplete();

		_totalAccumulatedPoints += _points;

		string instring = GetStringRepresentation();

		Console.WriteLine($"Recording Checklist goal completion of one of {_numTimesNeeded} events for  {_name} -{_description} for {_points}");

		if (IsComplete())
		{
			Console.WriteLine($"Congratulations You have Completed All {_numTimesNeeded} Checklist events for {_name} -{_description} for {_points} ");
			Console.WriteLine($"You have earned a bonus of {_bonusPoints} points.");
			GoalManager.GetAnAttaBoyGirl();

			Console.WriteLine($"");
		}
		Console.WriteLine($"{_detailsString}");

	}

	public override string GetStringRepresentation()
	{
		_detailsStringArray = GoalManager.GetDetailsStringArray(_index);
		_detailsString = $"{_refNum}, {_name}, {_description}, {_points}, {_totalAccumulatedPoints}, {_checkBoxVal}, {_numTimesRecorded}, {_numTimesNeeded}, {_status} , {_bonusAtLevel}, {_bonusPoints}";
		return _detailsString;
	}
	public override string GetDetailsString()      //override
	{
		string detailsString = $"{_refNum.ToString()}, {_name}, {_description}, {_points.ToString()}, {_totalAccumulatedPoints.ToString()}, {_checkBoxVal}, {_numTimesRecorded.ToString()}, {_numTimesNeeded.ToString()}, {_status} , {_bonusAtLevel.ToString()}, {_bonusPoints.ToString()}";

		return detailsString;                          //checkbox,name, description, 

	}

}