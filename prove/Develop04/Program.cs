using System;
using System.Threading;

// Base class for all activities
public class MindfulnessActivity
{
    protected int duration;

    public MindfulnessActivity(int duration)
    {
        this.duration = duration;
    }

    protected void DisplayStartingMessage(string activityName, string description)
    {
        Console.WriteLine($"{activityName} Activity");
        Console.WriteLine(description);
        Console.WriteLine($"Set duration to {duration} seconds.");
        Console.WriteLine("Prepare to begin...");
        PauseWithSpinner(3);
    }

    protected void DisplayEndingMessage(string activityName)
    {
        Console.WriteLine("Great job!");
        Console.WriteLine($"You have completed the {activityName} activity for {duration} seconds.");
        PauseWithSpinner(3);
    }

    protected void PauseWithSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Breathing activity class
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base(duration) { }

    public void Start()
    {
        DisplayStartingMessage("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            PauseWithSpinner(2);
            Console.WriteLine("Breathe out...");
            PauseWithSpinner(2);
        }

        DisplayEndingMessage("Breathing");
    }
}

// Reflection activity class
public class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] reflectionQuestions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration) { }

    public void Start()
    {
        DisplayStartingMessage("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Random random = new Random();

        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);

            foreach (var question in reflectionQuestions)
            {
                Console.WriteLine(question);
                PauseWithSpinner(2);
            }
        }

        DisplayEndingMessage("Reflection");
    }
}

// Listing activity class
public class ListingActivity : MindfulnessActivity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration) { }

    public void Start()
    {
        DisplayStartingMessage("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Random random = new Random();
        string prompt = listingPrompts[random.Next(listingPrompts.Length)];

        Console.WriteLine(prompt);
        PauseWithSpinner(5);

        Console.WriteLine("Start listing...");
        Console.WriteLine("Press Enter after each item.");

        int itemsCount = 0;
        while (true)
        {
            string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
                break;

            itemsCount++;
        }

        Console.WriteLine($"You listed {itemsCount} items.");

        DisplayEndingMessage("Listing");
    }
}

// Main program
class Program
{
    static void Main()
    {
        Console.WriteLine("Mindfulness App");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");

        Console.Write("Choose an activity (1-3): ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                BreathingActivity breathingActivity = new BreathingActivity(duration);
                breathingActivity.Start();
                break;
            case 2:
                ReflectionActivity reflectionActivity = new ReflectionActivity(duration);
                reflectionActivity.Start();
                break;
            case 3:
                ListingActivity listingActivity = new ListingActivity(duration);
                listingActivity.Start();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}
