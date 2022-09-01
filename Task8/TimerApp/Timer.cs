using System;
using System.Threading;

namespace TimerApp
{
    public class Timer
    {
        private readonly double _seconds;

        public event Action OnTimerEnds;

        public Timer(double seconds)
        {
            _seconds = seconds;
        }

        public void Start()
        {
            Thread.Sleep((int)(_seconds * 1000));
            OnTimerEnds?.Invoke();
        }
    }
}
