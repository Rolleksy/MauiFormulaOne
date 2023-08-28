namespace LapTimes;

public class Rootobject
{
    public Mrdata MRData { get; set; }
}

public class Mrdata
{
    public string xmlns { get; set; }
    public string series { get; set; }
    public string url { get; set; }
    public string limit { get; set; }
    public string offset { get; set; }
    public string total { get; set; }
    public Racetable RaceTable { get; set; }
}

public class Racetable
{
    public string season { get; set; }
    public string round { get; set; }
    public Race[] Races { get; set; }
}

public class Race
{
    public string season { get; set; }
    public string round { get; set; }
    public string url { get; set; }
    public string raceName { get; set; }
    public Circuit Circuit { get; set; }
    public string date { get; set; }
    public string time { get; set; }
    public Lap[] Laps { get; set; }
}

public class Circuit
{
    public string circuitId { get; set; }
    public string url { get; set; }
    public string circuitName { get; set; }
    public Location Location { get; set; }
}

public class Location
{
    public string lat { get; set; }
    public string _long { get; set; }
    public string locality { get; set; }
    public string country { get; set; }
}

public class Lap
{
    public string number { get; set; }
    public Timing[] Timings { get; set; }
}

public class Timing
{
    public string driverId { get; set; }
    public string position { get; set; }
    public string time { get; set; }
}
