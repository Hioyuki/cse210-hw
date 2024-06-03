public abstract class Event
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Date { get; private set; }
    public string Time { get; private set; }
    public Address Address { get; private set; }

    protected Event(string title, string description, string date, string time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Address = address;
    }

    public string GetStandardDetails()
    {
        return $"{Title}\n{Description}\nDate: {Date}\nTime: {Time}\nAddress: {Address}";
    }

    public abstract string GetFullDetails();
    public string GetShortDescription()
    {
        return $"{GetType().Name}: {Title} on {Date}";
    }
}