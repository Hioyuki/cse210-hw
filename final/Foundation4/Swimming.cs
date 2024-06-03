public class Swimming : Activity
{
    public int Laps { get; private set; }

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }
}