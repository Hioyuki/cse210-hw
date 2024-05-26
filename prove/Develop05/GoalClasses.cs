namespace GoalTrackingApp
{
    public abstract class Goal
    {
        protected string _shortName;
        protected string _description;
        protected int _points;

        public int Points { get { return _points; } }

        public Goal(string name, string description, int points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }

        public abstract void RecordEvent();
        public abstract bool IsComplete();
        public abstract string GetDetailsString();
        public abstract string GetStringRepresentation();
    }

    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _isComplete = false;
        }

        public override void RecordEvent()
        {
            _isComplete = true;
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetDetailsString()
        {
            return $"[ ] {_shortName}: {_description} - Points: {_points}";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
        }
    }

    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override void RecordEvent()
        {
            // Points are recorded each time, but goal is never complete
        }

        public override bool IsComplete()
        {
            return false; // Eternal goals are never truly complete
        }

        public override string GetDetailsString()
        {
            return $"[ ] {_shortName}: {_description} - Points: {_points}";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{_shortName},{_description},{_points}";
        }
    }
}