using System;
using System.Collections.Generic;
using Pomodoro.Helpers;

namespace Pomodoro.Models
{
    public class PomodoroMgr
    {
        // Singelton Class.
        public List<Todo> Tasks { get; set; }
        public Todo CurrentTask { get; set; }
        public int CyclesCount { get; set; }
        public TimerHelper Timer { get; set; }

        public PomodoroMgr(EventHandler callback)
        {
			Timer = new TimerHelper();
            Timer.InitTimer(callback);
            Tasks = new List<Todo>();
            Tasks.Add(new Todo(){
                Name = "First Todo",
                Description = "First Task here",
                DurationMinutes = 2
            });
		}

        private void Run()
        {
            CurrentTask = Tasks.Find((Todo obj) => obj.IsComplete == false);
            Timer.Duration = CurrentTask.DurationMinutes * (int)TimeUnitsInSecondsEnum.Minute;
            Timer.StartTimer();
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
                this.Run();
                return true;
            }
        }

        public void Reset()
        {
            Timer.ResetTimer();
        }
    }
}
