using System.Transactions;
using System.Collections.Generic;
using System.Dynamic;
using System.Security;

public class Comment
{
	public static int _commentId = 100;

	public string _commentText;// Example property
	public int _videoId;  // key
	public string _nameOfPerson;

	public List<Comment> _commentsListC = new List<Comment>();
	public string commentLineText;


	//constructor
	public Comment(int videoId, string nameOfPerson, string aStringComment) //add comments list 
	{

		_videoId = videoId;
		_nameOfPerson = nameOfPerson;
		_commentText = aStringComment;
		int _commentID = UpdateCommentID();

		//	MakeAComment();
		//	DisplayComment();

	}

	//class methods

	public int UpdateCommentID()
	{

		_commentId++;
		//		Console.WriteLine($"UpdateCommentID in comment");
		//Console.WriteLine($"CL: {comment}");

		//		Console.WriteLine($"CommentID: {_commentId}");
		//Console.WriteLine($"_comments");

		return _commentId;
	}

	public void MakeAComment()
	{

		//	Console.WriteLine($"MakeAComment in comment");
		commentLineText = ($"VID: {_videoId}  {_nameOfPerson}  {_commentText} CID: {_commentId} ");
		//	Console.WriteLine($"CLT: {commentLineText}");



	}

	public void DisplayComment()
	{

		//	Console.WriteLine("Displaying comment in comment : ");
		//	Console.WriteLine($"{commentLineText}");
	}

	public static void waitabit()
	{
		Console.WriteLine("Wait in Comment- Press enter to continue");
		Console.ReadKey();

	}

}