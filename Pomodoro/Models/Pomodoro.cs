using System;
using System.Collections.Generic;

namespace Pomodoro.Models
{
    public class Pomodoro
    {
        // Singelton Class.
        public List<Todo> Tasks { get; set; }
        public int CurrentTaskIndex { get; set; }
        public int CyclesCount { get; set; }
    }
}
