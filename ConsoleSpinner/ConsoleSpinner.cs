using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleSpinner
{
    public sealed class ConsoleSpinner
    {
        private readonly ICollection<char> _symbols;
        private readonly int _intervalDurationInMilliseconds;

        public bool InsertPrecedingSpace { get; set; } = true;

        public ConsoleSpinner(SpinnerType spinnerType, int intervalDurationInMilliseconds = 100)
        {
            _symbols = SpinnerSymbols.Get(spinnerType);
            _intervalDurationInMilliseconds = intervalDurationInMilliseconds;
        }

        public void Write(CancellationToken cancellationToken)
        {
            using var currentConsole = new ConsoleSettings();

            while (!cancellationToken.IsCancellationRequested)
            {
                foreach (var symbol in _symbols)
                {
                    WriteSymbol(currentConsole.X, currentConsole.Y, symbol);
                    Thread.Sleep(_intervalDurationInMilliseconds);
                }

                WriteBlank(currentConsole.X, currentConsole.Y);
            }
        }

        public async Task WriteAsync(CancellationToken cancellationToken)
        {
            using var currentConsole = new ConsoleSettings();

            while (!cancellationToken.IsCancellationRequested)
            {
                foreach (var symbol in _symbols)
                {
                    WriteSymbol(currentConsole.X, currentConsole.Y, symbol);
                    await Task.Delay(_intervalDurationInMilliseconds, CancellationToken.None);
                }

                WriteBlank(currentConsole.X, currentConsole.Y);
            }
        }

        private void WriteSymbol(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);

            if (InsertPrecedingSpace)
            {
                Console.Write(" ");
            }

            Console.Write(symbol);
        }

        private static void WriteBlank(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(SpinnerSymbols.Blank);
        }
    }
}
