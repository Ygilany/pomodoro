using System;
using System.ComponentModel;
using System.Windows.Input;
using Pomodoro.Helpers;
using Xamarin.Forms;
using Pomodoro.Models;

namespace Pomodoro.ViewModels
{
    public class PomodoroViewModel : BaseViewModel
    {
        private readonly PomodoroMgr Pomodoro;

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

            Pomodoro = new PomodoroMgr(UpdateUI);

			

			TogglePomodoro = new Command(() =>
			{
                ToggledBtnImage = Pomodoro.Toggle() ? "pause.png" : "play.png";
			});

            ResetPomodoro = new Command(() =>
			{
                Pomodoro.Reset();
                TimerProgress = 0;
				ElapsedTime = "00:00";
				ToggledBtnImage = "play.png";

			});

		}

		public void UpdateUI(object o, EventArgs e)
		{
            TimerProgress = Pomodoro.Timer.TimerProgress;
            ElapsedTime = Pomodoro.Timer.ElapsedTime;
		}
    }
}