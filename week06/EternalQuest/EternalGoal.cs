using System.IO;
using System;
using System.Collections.Generic;

public class EternalGoal : Goal
{
	protected static List<string> _cluesForEternalGoals = new List<string> { "3 daily prayers", "temple Visit", "20 minutes of scripture study", "Institue Class", "Face to Face Sacrament Meeting", "Giving Testimony", "Giving monthly tithe", "Completing a church responsibility" };
	private static int index;
	private static string[] _detailsStringArray;
	//private static string _detailsString;


	public EternalGoal(string name, string description, string points)
		: base(name, description, int.Parse(points))
	{


	}

	
	public override bool IsComplete()
	{

		if ((_numTimesNeeded == -1) || (_numTimesNeeded == _numTimesRecorded))
		{
			_numTimesNeeded += 25;
			_status = _numTimesRecorded + "/" + _numTimesNeeded;
		} //just increment as eternal goal endless
		 return false; 
	}

	public override void RecordEvent(int nindex)
	{
		index = nindex;
		_numTimesRecorded++;
	
		_totalAccumulatedPoints += _points; //add pint amount to total
		

	}

	public override string GetStringRepresentation()
	{
		string _sepStr = ",";
		_detailsStringArray = GoalManager.GetDetailsStringArray(index);
		_detailsString = _refNum.ToString() + _sepStr + _name + _sepStr + _description + _sepStr + _points.ToString() + _sepStr + _totalAccumulatedPoints.ToString() + _sepStr + _checkBoxVal + _sepStr + _numTimesRecorded.ToString() + _sepStr + _numTimesNeeded.ToString() + _sepStr + _status + _sepStr + _bonusAtLevel.ToString() + _sepStr + _bonusPoints.ToString();
		return _detailsString;
	}
}
