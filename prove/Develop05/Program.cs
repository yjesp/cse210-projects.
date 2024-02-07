using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Base class for all types of goals
abstract class Goal
{
    protected string name;
    protected int points;

    public Goal(string name, int points)
    {
        this.name = name;
        this.points = points;
    }

    public abstract void RecordEvent();
    public abstract string Progress();
}

// Simple goal class
class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        // For simple goals, marking as complete awards points
        Console.WriteLine($"Congratulations! You completed the goal: {name}");
        // Code to award points
    }

    public override string Progress()
    {
        return $"[{name}]";
    }
}

// Eternal goal class
class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        // For eternal goals, recording events awards points
        Console.WriteLine($"You recorded progress for the eternal goal: {name}");
        // Code to award points
    }

    public override string Progress()
    {
        return $"[{name}]";
    }
}

// Checklist goal class
class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;

    public ChecklistGoal(string name, int points, int targetCount) : base(name, points)
    {
        this.targetCount = targetCount;
        this.currentCount = 0;
    }

    public override void RecordEvent()
    {
        // For checklist goals, recording events awards points and updates progress
        Console.WriteLine($"You recorded progress for the checklist goal: {name}");
        currentCount++;
        // Code to award points

        if (currentCount == targetCount)
        {
            Console.WriteLine($"Congratulations! You completed the checklist goal: {name}");
            // Code to award bonus points
        }
    }

    public override string Progress()
    {
        return $"[{name} Completed {currentCount}/{targetCount} times]";
    }
}

// Class to manage goals and scores
class EternalQuest
{
    private List<Goal> goals;
    private int totalScore;

    public EternalQuest()
    {
        goals = new List<Goal>();
        totalScore = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void RecordGoalCompletion(int index)
    {
        if (index >= 0 && index < goals.Count)
        {
            goals[index].RecordEvent();
            // Update total score
            // Code to update total score
        }
        else
        {
            Console.WriteLine("Invalid goal index!");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Current Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Progress()}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Total Score: {totalScore}");
    }

    public void SaveGoals(string filename)
    {
        // Code to save goals to a file
    }

    public void LoadGoals(string filename)
    {
        // Code to load goals from a file
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Instantiate EternalQuest
        EternalQuest quest = new EternalQuest();

        // Add goals
        quest.AddGoal(new SimpleGoal("Run a marathon", 1000));
        quest.AddGoal(new EternalGoal("Read scriptures", 100));
        quest.AddGoal(new ChecklistGoal("Attend the temple", 50, 10));

        // Display goals
        quest.DisplayGoals();

        // Record goal completion
        quest.RecordGoalCompletion(0); // Mark running a marathon as complete
        quest.RecordGoalCompletion(2); // Record attending the temple
        quest.RecordGoalCompletion(2); // Record attending the temple again

        // Display score
        quest.DisplayScore();
    }
}
