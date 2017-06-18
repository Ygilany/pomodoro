using System;
using System.Timers;

namespace Pomodoro.Helpers
{
    public class TimerHelper
    {
        Timer timer;
        int duration;
        int elapsedTime;
        EventHandler OneSecondElapsedHandler;

		public TimerHelper InitTimer(int duration, EventHandler e)
		{
			if (this.timer == null)
			{
                this.timer = new Timer((int)TimeUnitsInMillisecondsEnum.Second);
				this.timer.Elapsed += this.Tick;
				this.timer.AutoReset = true;
			}

			this.duration = duration;
            this.elapsedTime = 0;
			this.OneSecondElapsedHandler = e;

            return this;
		}

        public void Tick(object O, EventArgs e)
        {
            elapsedTime++;
			if (elapsedTime > this.duration) {
				this.StopTimer();
            } else {
				OneSecondElapsedHandler.Invoke(O, e);
			}
        }

		public void StartTimer()
		{
			if (this.timer != null)
			{
				if (!this.timer.Enabled)
				{
					this.timer.Start();
				}
			}
			else
			{
				throw new NullReferenceException("Timer not initialized. You should call initTimer function first!");
			}
		}

		public void StopTimer()
		{
			if (this.timer != null)
			{
				if (this.timer.Enabled)
				{
					this.timer.Stop();
				}
			}
			else
			{
				throw new NullReferenceException("Timer not initialized. You should call initTimer function first!");
			}
		}

        public void ResetTimer()
        {
			if (this.timer != null)
			{
				if (this.timer.Enabled)
				{
					this.timer.Stop();
                    this.elapsedTime = 0;
				}
			}
			else
			{
				throw new NullReferenceException("Timer not initialized. You should call initTimer function first!");
			}
        }

		public bool IsEnabled
		{
			get
			{
				return this.timer.Enabled;
			}
		}

		public int Duration
		{
			get
			{
				return this.duration;
			}
			set
			{
				this.duration = value;
			}
		}

        public string ElapsedTime
        {
            get
            {
                return TimeSpan.FromSeconds(this.elapsedTime).ToString(@"mm\:ss");

			}
        }

		public double TimerProgress
		{
			get
			{
                return (double)this.elapsedTime/this.duration;

			}
		}
    }
}
