using System;
namespace Pomodoro.Helpers
{
    public enum TimeUnitsInSecondsEnum : int
    {
        Second = 1,
        Minute = 60 * TimeUnitsInSecondsEnum.Second,
        Hour = 60 * TimeUnitsInSecondsEnum.Minute,
        Day = 24 * TimeUnitsInSecondsEnum.Hour
    }
}
