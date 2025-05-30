using System.Configuration.Assemblies;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Transactions;

public class Video
{

	public string _title;
	public string _author;
	public int _lengthSeconds;
	public int _videoId;
	public int _commentCount = 0;

	public List<Comment> _commentsList; //initialize the List<Comment>
										//public Video video = new Video();


	public Video(int videoID, string title, string author, int lengthSeconds)

	{
		_videoId = videoID;
		_title = title;
		_author = author;
		_lengthSeconds = lengthSeconds;
		_commentsList = new List<Comment>();

		DisplayVideoInfo();

	}


	//methods


	public void AddComment(Comment comment)
	{
		_commentsList.Add(comment);

	}
	public void DisplayVideoInfo()
	{

		//	Console.WriteLine($"Display Video in video:");
		Console.WriteLine($"VideoID: '{_videoId}' Title: '{_title}' Author: '{_author}' Seconds Length: {_lengthSeconds}");



		//	DisplayComments();
	}
	public void DisplayComments()
	{

		Console.WriteLine($"Has {_commentsList.Count} Comments: ");
		int i = 0;
		//	Console.WriteLine($"Comments for video: {_title} ");
		foreach (var line in _commentsList)
		{
			_commentCount++;
			i++;

			Console.WriteLine($"Comment {i}- {line._nameOfPerson} said  '{line._commentText}'");
		}
	}

	public void GetNumOfComments()
	{
		//	Console.WriteLine($"GetNumofComm:");

		int count = _commentsList.Count;
		//	Console.WriteLine($"#: {count}");

		//	return count;
	}

	public static void waitabit()
	{
		Console.WriteLine("Wait in Video Press enter to continue");
		Console.ReadKey();

	}
}