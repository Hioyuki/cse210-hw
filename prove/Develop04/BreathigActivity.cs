public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "Helps you control your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        ShowCountDown(3);

        int repetitions = 3;

        for (int i = 0; i < repetitions; i++)
        {
            ShowBreathingPhase("Breathe in...", 3);
            ShowBreathingPhase("Hold...", 3);
            ShowBreathingPhase("Breathe out...", 3);
            ShowBreathingPhase("Hold...", 3);
        }

        DisplayEndingMessage();
    }

    private void ShowBreathingPhase(string message, int duration)
    {
        Console.WriteLine(message);
        ShowCountDown(duration);
    }
}