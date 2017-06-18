using System;
using System.ComponentModel;
using System.Windows.Input;
using Pomodoro.Helpers;
using Xamarin.Forms;

namespace Pomodoro.ViewModels
{
    public class PomodoroViewModel : BaseViewModel
    {
        private readonly TimerHelper timer;

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

		string toggledBtnImage;
		public string ToggledBtnImage
		{
			get
			{
				return toggledBtnImage;
			}
			set
			{
				SetProperty(ref toggledBtnImage, value);
			}
		}

		public ICommand TogglePomodoro { get; }
		public ICommand ResetPomodoro { get; }

		public PomodoroViewModel () {
            Title = "Pomodoro";

            TimerProgress = 0;
			ElapsedTime = "00:00";
            ToggledBtnImage = "play.png";

			timer = new TimerHelper();
			timer.InitTimer(5 * (int)TimeUnitsInSecondsEnum.Second, UpdateUI);

			TogglePomodoro = new Command(() =>
			{
				if (timer.IsEnabled)
				{
					timer.StopTimer();
					ToggledBtnImage = "play.png";
				}
				else
				{
					timer.StartTimer();
					ToggledBtnImage = "pause.png";
				}
			});

            ResetPomodoro = new Command(() =>
			{
                timer.ResetTimer();
				TimerProgress = 0;
				ElapsedTime = "00:00";
				ToggledBtnImage = "play.png";

			});

		}

		public void UpdateUI(object o, EventArgs e)
		{
            TimerProgress = this.timer.TimerProgress;
            ElapsedTime = this.timer.ElapsedTime;
		}
    }
}