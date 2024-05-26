namespace GoalTrackingApp
{
    public class ChecklistGoal : Goal
    {
        public int AmountCompleted { get; set; }
        private int _target;
        private int _bonus;

        public int Bonus { get { return _bonus; } }

        public ChecklistGoal(string name, string description, int points, int target, int bonus)
            : base(name, description, points)
        {
            AmountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }

        public override void RecordEvent()
        {
            AmountCompleted++;
        }

        public override bool IsComplete()
        {
            return AmountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            return $"[ ] {_shortName}: {_description} - Points: {_points} - Completed: {AmountCompleted}/{_target} - Bonus: {_bonus}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{AmountCompleted}";
        }
    }
}