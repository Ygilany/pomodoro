using System;
namespace Pomodoro.Helpers
{
    public enum TimeUnitsInMillisecondsEnum : int
    {
        MilliSecond = 1,
        Second = 1000 * TimeUnitsInMillisecondsEnum.MilliSecond,
        Minute = 60 * TimeUnitsInMillisecondsEnum.Second,
        Hour = 60 * TimeUnitsInMillisecondsEnum.Minute,
        Day = 24 * TimeUnitsInMillisecondsEnum.Hour
    }
}
