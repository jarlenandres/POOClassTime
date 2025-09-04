namespace POOConcepts.Core;

public class Time
{
    // Private attributes
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;

    // Constructor method with overloading
    public Time()
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }
    public Time(int hour)
    {
        Hour = hour;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }
    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
        Second = 0;
        Millisecond = 0;
    }
    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = 0;
    }
    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }

    // Public properties
    public int Hour
    {
        get => _hour;
        set
        {
            _hour = ValidHour(value);
        }
    }

    public int Minute
    {
        get => _minute;
        set
        {
            _minute = ValidMinute(value);
        }
    }

    public int Second
    {
        get => _second;
        set
        {
            _second = ValidSecond(value);
        }
    }

    public int Millisecond
    {
        get => _millisecond;
        set
        {
            _millisecond = ValidMillisecond(value);
        }
    }

    //Overwrite ToString method
    public override string ToString()
    {
        DateTime dt = new DateTime(1, 1, 1, Hour, Minute, Second, Millisecond);
        return dt.ToString("hh:mm:ss.fff tt");
    }

    // Private methods
    private int ValidHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new Exception($"The hour: {hour}, is not valid.");
        }
        return hour;
    }

    private int ValidMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception($"The minute: {minute}, is not valid.");
        }
        return minute;
    }

    private int ValidSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception($"The second: {second}, is not valid.");
        }
        return second;
    }

    private int ValidMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new Exception($"The millisecond: {millisecond}, is not valid.");
        }
        return millisecond;
    }

    public int ToMilliseconds()
    {
        return (Hour * 3600000) + (Minute * 60000) + (Second * 1000) + Millisecond;
    }

    public int ToSeconds()
    {
        return (Hour * 3600) + (Minute * 60) + Second;
    }

    public int ToMinutes()
    {
        return (Hour * 60) + Minute;
    }

    public int ToHours()
    {
        return Hour;
    }
    
    public object Add(Time t)
    {
        int Milliseconds = this.ToMilliseconds() + t.ToMilliseconds();
        int hours = (Milliseconds / 3600000) % 24;
        int minutes = (Milliseconds / 60000) % 60;
        int seconds = (Milliseconds / 1000) % 60;
        int milliseconds = Milliseconds % 1000;
        return new Time(hours, minutes, seconds, milliseconds);
    }

    public bool IsOtherDay(Time d)
    {
        int hour = this.Hour + d.Hour;
        return (hour > 23);
    }
}
