using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleSpinner.Demo
{
    internal static class Program
    {
        internal static async Task Main()
        {
            foreach (SpinnerType spinnerType in Enum.GetValues(typeof(SpinnerType)))
            {
                var spinner = new ConsoleSpinner(spinnerType);

                var tokenSource = new CancellationTokenSource();
                tokenSource.CancelAfter(TimeSpan.FromSeconds(6));

                Console.Write($"{spinnerType}");
                // spinner.Write(tokenSource.Token);
                await spinner.WriteAsync(tokenSource.Token);

                Console.WriteLine();
            }
        }
    }
}
