namespace POOConcepts.Core;

public class Time
{
    // Private attributes
    private int _hour;
    private int _millisecond;
    private int _minute;
    private int _second;

    // Constructor method with overloading
    public Time()
    {
        Hour = 0;
        Millisecond = 0;
        Minute = 0;
        Second = 0;
    }
    public Time(int hour)
    {
        Hour = hour;
        Millisecond = 0;
        Minute = 0;
        Second = 0;
    }
    public Time(int hour, int minute)
    {
        Hour = hour;
        Millisecond = 0;
        Minute = minute;
        Second = 0;
    }
    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Millisecond = 0;
        Minute = minute;
        Second = second;
    }
    public Time(int hour, int millisecond, int minute, int second)
    {
        Hour = hour;
        Millisecond = millisecond;
        Minute = minute;
        Second = second;
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

    public int Millisecond
    {
        get => _millisecond;
        set
        {
            _millisecond = ValidMillisecond(value);
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

    //Overwrite ToString method
    public override string ToString()
    {
        // Se asegura de usar las propiedades públicas para mantener la lógica de la clase
        DateTime dt = new DateTime(1, 1, 1, Hour, Minute, Second, Millisecond);
        return dt.ToString("hh:mm:ss.fff tt");
    }

    // Private methods

    private int ValidHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new Exception($"La hora: {hour}, debe estar entre 0 y 23.");
        }
        return hour;
    }

    private int ValidMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception($"El minuto: {minute}, debe estar entre 0 y 59.");
        }
        return minute;
    }

    private int ValidSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception($"El segundo: {second}, debe estar entre 0 y 59.");
        }
        return second;
    }

    private int ValidMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new Exception($"El milisegundo: {millisecond}, debe estar entre 0 y 999.");
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
}
