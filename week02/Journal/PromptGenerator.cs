using System;
using System.Collections.Generic;

//namespace JournalSpace;

// This class represents a Prompt for a resume entry
public class PromptGenerator
{

	public string _prompt;
	private List<string> promptList = ["What great thing happened today?", " What miracle happened today?", "Describe your love for God.", "What Change have you seen in one of your kids today?", "What was your favorite meal today?", "What was todays FUN?", "What Scripture did you study today?", "What were the promtings from the spirit today?", "What were the miracles you had or saw today?", "How does it feel to be truly loved by God?"];

	public PromptGenerator()
	{
		//if (_prompt === "")
		//{
		_prompt = GetRandomPrompt();
		//}
	}
	// Default constructor	

	public string GetRandomPrompt()
	{

		int length = promptList.Count;
		// array from 0
		//Console.WriteLine($"leng Promptlist: {length}");

		Random random = new Random();
		int index = length - 1;
		int randNum = random.Next(0, index);
		//Console.WriteLine($"Random Num: {randNum}");
		string prompt = promptList[randNum];

		Console.WriteLine($"# {randNum} Today's Prompt: {prompt}");
		return prompt;
	}
}




