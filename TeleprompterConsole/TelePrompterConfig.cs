using static System.Math;

namespace TeleprompterConsole
{
    public class TelePrompterConfig
    {
        private readonly object _lockHandle = new object();

        public int DelayInMilliseconds { get; private set; } = 200;

        public bool Done { get; private set; }

        public void SetDone()
        {
            Done = true;
        }

        public void UpdateDelay(int increment) // negative to speed up
        {
            var newDelay = Min(DelayInMilliseconds + increment, 1000);
            newDelay = Max(newDelay, 20);
            lock (_lockHandle)
            {
                DelayInMilliseconds = newDelay;
            }
        }
    }
}