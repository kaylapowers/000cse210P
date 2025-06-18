using System.Runtime.CompilerServices;
using System.IO;
using System;
using System.Collections.Generic;
public abstract class Goal(string name, string description, int points)
{
	///String Representation- refNum(int), name(of goal str), description(str), points(int), totalPoints (int),_numTimesNeeded(int), NumTimesRecorded(int), bonusAtLevel(int), bonus points(int), checkboxValue (string [] or [✔️] ), status (x of y| numTimesNeeded/numTimesRecorded) 
	protected string _stringRepresentation; //string array with 
	protected string _detailsString; //string from fileio
	protected string _getDetailsString; //string from fileio
	protected int _refNum; //

	protected string _name = name; //**of goal
	protected string _description = description;   //**
	protected int _points = points;  //**
	protected int _totalAccumulatedPoints; // *//'104' 

	protected int _numTimesNeeded; //*//increment with recordevent
	protected int _numTimesRecorded; //*//increment with recordevent
	protected int _bonusAtLevel  = 5; // '3'*// 
	protected int _bonusPoints = 50 ; // *//'104' 

	protected string _checkBoxVal = "[ ]"; //*//" x complete of y- faults not completed
	protected string _status = "0/0"; //*//" x complete of y- faults not completed

	protected string _isComplete; //*//" x complete of y- faults not completed
								  //	public abstract bool IsComplete();
								  //{_refNum}, {_name}, {_description}, {_points}, {_totalAccumulatedPoints}, {_checkBoxVal}, {_numTimesRecorded}, {_numTimesNeeded}, {_status} , {_bonusAtLevel}, {_bonusPoints}";
	public abstract void RecordEvent(int index);
	public abstract bool IsComplete();

	public abstract string GetStringRepresentation();
	// // {_refNum}, {_name}, {_description}, {_points}, {_totalAccumulatedPoints}, {_checkBoxVal}, {_numTimesRecorded}, {_numTimesRecorded}, {_numTimesNeeded}, {_status},{_bonusAtLevel}, {_bonusPoints}  	public abstract bool IsComplete();

	public virtual string GetDetailsString() //*****
	{
		// Set _detailsString to a formatted string with relevant details
		string detailsString = $"{_refNum}, {_name}, {_description}, {_points}, {_totalAccumulatedPoints}, {_checkBoxVal}" ;
		return detailsString;                          //checkbox,name, description, 

	}
	}


