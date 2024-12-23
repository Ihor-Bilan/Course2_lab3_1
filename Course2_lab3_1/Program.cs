using System;

struct MyTime
{
    public int hour, minute, second;

    public MyTime(int h, int m, int s)
    {
        hour = h;
        minute = m;
        second = s;
    }

    public override string ToString()
    {
        return $"{hour}:{minute:D2}:{second:D2}";
    }
}

class Program
{
    static int TimeSinceMidnight(MyTime t)
    {
        return t.hour * 3600 + t.minute * 60 + t.second;
    }

    static MyTime TimeSinceMidnight(int t)
    {
        int secPerDay = 86400;
        t %= secPerDay;
        if (t < 0)
            t += secPerDay;
        int h = t / 3600;
        int m = (t / 60) % 60;
        int s = t % 60;
        return new MyTime(h, m, s);
    }

    static MyTime AddOneSecond(MyTime t)
    {
        return TimeSinceMidnight(TimeSinceMidnight(t) + 1);
    }

    static MyTime AddOneMinute(MyTime t)
    {
        return TimeSinceMidnight(TimeSinceMidnight(t) + 60);
    }

    static MyTime AddOneHour(MyTime t)
    {
        return TimeSinceMidnight(TimeSinceMidnight(t) + 3600);
    }

    static MyTime AddSeconds(MyTime t, int s)
    {
        return TimeSinceMidnight(TimeSinceMidnight(t) + s);
    }

    static int Difference(MyTime mt1, MyTime mt2)
    {
        return TimeSinceMidnight(mt1) - TimeSinceMidnight(mt2);
    }

    static string WhatLesson(MyTime mt)
    {
        int seconds = TimeSinceMidnight(mt);

        if (seconds < 8 * 3600) return "Пари ще не почалися";
        if (seconds < 9 * 3600 + 20 * 60) return "1-а пара";
        if (seconds < 9 * 3600 + 30 * 60) return "Перерва між 1-ю та 2-ю парами";
        if (seconds < 10 * 3600 + 50 * 60) return "2-а пара";
        if (seconds < 11 * 3600 + 00 * 60) return "Перерва між 2-ю та 3-ю парами";
        if (seconds < 12 * 3600 + 20 * 60) return "3-я пара";
        if (seconds < 12 * 3600 + 30 * 60) return "Перерва між 3-ю та 4-ю парами";
        if (seconds < 13 * 3600 + 50 * 60) return "4-а пара";
        if (seconds < 14 * 3600 + 00 * 60) return "Перерва між 4-ю та 5-ю парами";
        if (seconds < 15 * 3600 + 20 * 60) return "5-а пара";
        if (seconds < 15 * 3600 + 30 * 60) return "Перерва між 5-ю та 6-ю парами";
        if (seconds < 16 * 3600 + 50 * 60) return "6-а пара";

        return "Пари вже скінчилися";
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        Console.Write("Введіть годину: ");
        int hour = int.Parse(Console.ReadLine());

        Console.Write("Введіть хвилини: ");
        int minute = int.Parse(Console.ReadLine());

        Console.Write("Введіть секунди: ");
        int second = int.Parse(Console.ReadLine());

        MyTime userTime = new MyTime(hour, minute, second);

        Console.WriteLine("Введений час: " + userTime.ToString());

        int secondsSinceMidnight = TimeSinceMidnight(userTime);
        Console.WriteLine("Кількість секунд від початку доби: " + secondsSinceMidnight);

        MyTime timeFromSeconds = TimeSinceMidnight(secondsSinceMidnight);
        Console.WriteLine("Час з кількості секунд: " + timeFromSeconds.ToString());

        MyTime addedSecondTime = AddOneSecond(userTime);
        Console.WriteLine("Час після додавання однієї секунди: " + addedSecondTime.ToString());

        MyTime addedMinuteTime = AddOneMinute(userTime);
        Console.WriteLine("Час після додавання однієї хвилини: " + addedMinuteTime.ToString());

        MyTime addedHourTime = AddOneHour(userTime);
        Console.WriteLine("Час після додавання однієї години: " + addedHourTime.ToString());

        Console.Write("Введіть кількість секунд для додавання: ");
        int additionalSeconds = int.Parse(Console.ReadLine());
        MyTime addedSecondsTime = AddSeconds(userTime, additionalSeconds);
        Console.WriteLine("Час після додавання секунд: " + addedSecondsTime.ToString());

        Console.Write("Введіть годину для другого часу: ");
        int hour2 = int.Parse(Console.ReadLine());

        Console.Write("Введіть хвилини для другого часу: ");
        int minute2 = int.Parse(Console.ReadLine());

        Console.Write("Введіть секунди для другого часу: ");
        int second2 = int.Parse(Console.ReadLine());

        MyTime userTime2 = new MyTime(hour2, minute2, second2);
        int difference = Difference(userTime, userTime2);
        Console.WriteLine("Різниця між введеними часами в секундах: " + difference);

        string lesson = WhatLesson(userTime);
        Console.WriteLine("Поточний урок: " + lesson);
    }
}
