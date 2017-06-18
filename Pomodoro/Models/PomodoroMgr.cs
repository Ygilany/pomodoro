using System;
using System.Collections.Generic;
using Pomodoro.Helpers;

namespace Pomodoro.Models
{
    public class PomodoroMgr
    {
        // Singelton Class.
        public List<Todo> Tasks { get; set; }
        public int CurrentTaskIndex { get; set; }
        public int CyclesCount { get; set; }
        public TimerHelper Timer { get; set; }

        public PomodoroMgr(EventHandler e)
        {
			Timer = new TimerHelper();
			Timer.InitTimer(5 * (int)TimeUnitsInSecondsEnum.Second, e);
            Tasks = new List<Todo>();
		}

        public bool Toggle()
        {
			if (Timer.IsEnabled)
			{
				Timer.StopTimer();
                return false;
            }
			else
			{
				Timer.StartTimer();
                return true;
            }
        }

        public void Reset()
        {
            Timer.ResetTimer();
        }
    }
}
