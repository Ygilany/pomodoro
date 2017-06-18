using System;
using System.ComponentModel;
using Pomodoro.Helpers;

namespace Pomodoro.ViewModels
{
    public class PomodoroViewModel : BaseViewModel
    {
		private TimerHelper timer;
        public double TimerProgress;

		public PomodoroViewModel () {
            Title = "Pomodoro";

            TimerProgress = 0.5;

			timer = new TimerHelper();
			timer.InitTimer(5 * (int)TimeUnitsInSecondsEnum.Second, LogStuff);
			timer.StartTimer();
        }

		public void LogStuff(object o, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Log" + this.timer.ElapsedTime);
			System.Diagnostics.Debug.WriteLine("prog" + this.timer.TimerProgress);

			this.TimerProgress = this.timer.TimerProgress;
            OnPropertyChanged("TimerProgress");
		}
    }
}
