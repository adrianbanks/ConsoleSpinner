using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleSpinner.Demo
{
    internal static class Program
    {
        internal static async Task Main()
        {
            var cycleDuration = 100;

            foreach (SpinnerType spinnerType in Enum.GetValues(typeof(SpinnerType)))
            {
                // DoIt(spinnerType, cycleDuration);
                await DoItAsync(spinnerType, cycleDuration);

                Console.WriteLine();
            }
        }

        private static void DoIt(SpinnerType spinnerType, int cycleDuration)
        {
            var spinner = new ConsoleSpinner(spinnerType, cycleDuration);

            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(TimeSpan.FromSeconds(6));

            Console.Write($"{spinnerType} ");
            spinner.Write(tokenSource.Token);
        }

        private static async Task DoItAsync(SpinnerType spinnerType, int cycleDuration)
        {
            var spinner = new ConsoleSpinner(spinnerType, cycleDuration);

            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(TimeSpan.FromSeconds(4));

            Console.Write($"{spinnerType} ");
            await spinner.WriteAsync(tokenSource.Token);
        }
    }
}
