namespace EventUppgiftEtt
{
    internal class Program
    {
        static void Main(string[] args)
        {
           SimpleTimer timer = new SimpleTimer();
            timer.Start();
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine(i);
            }
            timer.Stop();
        }
    }
    public class SimpleTimer
    {
        /// <summary>
        /// Event som triggas varje sekund med aktuell tid
        /// </summary>
        public event EventHandler<DateTime> TimerTick;

        private bool isRunning;
        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// Startar timern som kommer att skicka ut events varje sekund
        /// </summary>
        public void Start()
        {
            if (isRunning)
                return;

            isRunning = true;
            cancellationTokenSource = new CancellationTokenSource();

            // Starta en asynkron task som körs tills den stoppas
            Task.Run(async () =>
            {
                while (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    // Invokera eventet med aktuell tid
                    TimerTick?.Invoke(this, DateTime.Now);

                    try
                    {
                        // Vänta en sekund innan nästa tick
                        await Task.Delay(1000, cancellationTokenSource.Token);
                    }
                    catch (TaskCanceledException)
                    {
                        // Avbryt om timern stoppas
                        break;
                    }
                }
            }, cancellationTokenSource.Token);
        }

        /// <summary>
        /// Stoppar timern från att skicka ut fler events
        /// </summary>
        public void Stop()
        {
            if (!isRunning)
                return;

            cancellationTokenSource.Cancel();
            isRunning = false;
        }

        /// <summary>
        /// Kontrollerar om timern är igång
        /// </summary>
        public bool IsRunning => isRunning;
    }
}
