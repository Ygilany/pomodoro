using System;
using System.ComponentModel;
using Pomodoro.Helpers;

namespace Pomodoro.ViewModels
{
    public class PomodoroViewModel : BaseViewModel
    {
		private TimerHelper timer;
        double progress;
        public double TimerProgress { 
            get{
                return progress;
            }
            set{
                SetProperty(ref progress, value); 
            } 
        }
        string elapsedTime;
        public string ElapsedTime { 
            get
            {
                return elapsedTime;
            }
            set {
                SetProperty(ref elapsedTime, value);
            }
        }


		public PomodoroViewModel () {
            Title = "Pomodoro";

            TimerProgress = 0;

			ElapsedTime = "00:00";

			timer = new TimerHelper();
			timer.InitTimer(5 * (int)TimeUnitsInSecondsEnum.Second, LogStuff);
			timer.StartTimer();
        }

		public void LogStuff(object o, EventArgs e)
		{
            TimerProgress = this.timer.TimerProgress;
            ElapsedTime = this.timer.ElapsedTime;
		}
    }
}
