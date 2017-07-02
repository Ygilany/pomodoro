using System;
using Pomodoro.Helpers;

namespace Pomodoro.Models
{
    public class Todo
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationMinutes { get; set; } = 25;
        public int PomodoroCounter { get; set; }
        public bool IsComplete { get; set; }
    }
}
