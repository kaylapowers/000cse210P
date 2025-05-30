using System;
using System.Reflection.PortableExecutable;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
	//private static List<Comment> commmentsList1;
	static void Main(string[] args)
	{

		Console.WriteLine("Hello CSE210! This is Kayla Powers and the YouTubeVideos project with another Gread Video update.");
		Console.WriteLine("");

		Video video1 = new Video(1, "Vid1", "Kev", 12);
		List<Comment> comments1 = new List<Comment>
		{
			new Comment(1,"Mona", "Yuk"),
			new Comment(1, "Josretk", "some moe, of the same23#."),
			new Comment(1, "liam", "Bizarre no ick"),
			new Comment(1, "Nick", "Try again."),
			new Comment(1, "john", "wow blaaah"),
			new Comment(1, "kay", "boring")
		};

		foreach (var comment1 in comments1)
		{
			video1.AddComment(comment1);
		}

		video1.DisplayComments();


		Video video2 = new Video(2, "Video Two Lives Again", "Ted Bunson", 187000);
		List<Comment> comments2 = new List<Comment>
		{
			new Comment(2, "James", "GRET Daling"),
			new Comment(2, " Mya larson", "good sleep"),
			new Comment(2, "gregMop", "ok"),
			new Comment(2, "fatso", "Yum yum popcorn.")
		};

		foreach (var comment2 in comments2)
		{
			video2.AddComment(comment2);
		}

		video2.DisplayComments();


		Video video3 = new Video(3, "Winney the Bear", "Ralph Lester", 259);
		List<Comment> comments3 = new List<Comment>
		{
			new Comment(3, "Jan", "oh my Daling"),
			new Comment(3, "Great Scott", "gozzzzz"),
			new Comment(3, "Jeff", "kids laugher"),
			new Comment(3, "Lane Dry", "NAAAA"),
			new Comment(3, "Drip Drt", "Take your money, and rung.")
		};

		foreach (var comment3 in comments3)
		{
			video3.AddComment(comment3);
		}
		video3.DisplayComments();



		//	video1._commentsList.Add(new Comment ( 1,"Mona", "Yuk" ));

		//	video1._commentsList.Add(new Comment(1, "Josretk", "some moe, of the same23#."));
		//	video1._commentsList.Add(new Comment(1, "liam", "Bizarre no ick"));

		//	video1._commentsList.Add(new Comment(1, "Nick", "Try again."));
		//	video1._commentsList.Add(new Comment(1, "john", "wow ick"));

		//	Comment comment15 = new Comment(1, "kay", "boring");
		//	video1._commentsList.Add(comment15);


		//	Video video1 = new Video(1, "Vid1", "Ted", 12);


		//	Video video2 = new Video(2, "Video Two Lives Again", "Ted Bunson", 187000);
		//	video2.commmentsList1 = new List<Comment>();

		//	Comment comment20 = new Comment(2, "James", "GRET Daling");
		//	commmentsList1.Add(comment20);

		//	Comment comment16 = new Comment(2, " Mya larson", "good sleep");
		//	commmentsList1.Add(comment16);

		//	Comment comment17 = new Comment(2, "gregMop", "ok");
		//	commmentsList1.Add(comment17);

		//	Comment comment18 = new Comment(2, "fatso", "Yum yum popcorn.");
		//	commmentsList1.Add(comment18);


		//	Video video2 = new Video(2, "Video Two Lives Again", "Ted Bunson", 187000);

	}
	public static void waitabit()
	{
		Console.WriteLine("Press enter to continue");
		Console.ReadKey();

	}

}