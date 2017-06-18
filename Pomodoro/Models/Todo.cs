using System;
using Pomodoro.Helpers;

namespace Pomodoro.Models
{
    public class Todo
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int DurationMin { get; set; }
        public int PomodoroCounter { get; set; }
        public TimerHelper timer { get; set; }
    }
}
