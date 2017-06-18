using System;
using System.Collections.Generic;
using Pomodoro.Helpers;

namespace Pomodoro.Models
{
    public class Pomodoro
    {
        // Singelton Class.
        public List<Todo> Tasks { get; set; }
        public int CurrentTaskIndex { get; set; }
        public int CyclesCount { get; set; }
        public TimerHelper Timer { get; set; }
    }
}
