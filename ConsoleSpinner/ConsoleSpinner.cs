using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleSpinner
{
    public sealed class ConsoleSpinner
    {
        private readonly SpinnerType _spinnerType;
        private readonly int _intervalDurationInMilliseconds;

        public bool InsertPrecedingSpace { get; set; } = true;

        public ConsoleSpinner(SpinnerType spinnerType, int intervalDurationInMilliseconds = 100)
        {
            _spinnerType = spinnerType;
            _intervalDurationInMilliseconds = intervalDurationInMilliseconds;
        }

        public void Write(CancellationToken cancellationToken)
        {
            var originalEncoding = Console.OutputEncoding;
            var originalCursorVisible = Console.CursorVisible;

            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.CursorVisible = false;
                var currentX = Console.CursorLeft;
                var currentY = Console.CursorTop;
                var symbols = SpinnerSymbols.Get(_spinnerType);

                while (!cancellationToken.IsCancellationRequested)
                {
                    foreach (var symbol in symbols)
                    {
                        Console.SetCursorPosition(currentX, currentY);

                        if (InsertPrecedingSpace)
                        {
                            Console.Write(" ");
                        }

                        Console.Write(symbol);
                        Thread.Sleep(_intervalDurationInMilliseconds);
                    }

                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write(SpinnerSymbols.Blank);
                }
            }
            finally
            {
                Console.OutputEncoding = originalEncoding;
                Console.CursorVisible = originalCursorVisible;
            }
        }

        public async Task WriteAsync(CancellationToken cancellationToken)
        {
            var originalEncoding = Console.OutputEncoding;
            var originalCursorVisible = Console.CursorVisible;

            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.CursorVisible = false;
                var currentX = Console.CursorLeft;
                var currentY = Console.CursorTop;
                var symbols = SpinnerSymbols.Get(_spinnerType);

                while (!cancellationToken.IsCancellationRequested)
                {
                    foreach (var symbol in symbols)
                    {
                        Console.SetCursorPosition(currentX, currentY);

                        if (InsertPrecedingSpace)
                        {
                            Console.Write(" ");
                        }

                        Console.Write(symbol);
                        await Task.Delay(_intervalDurationInMilliseconds, CancellationToken.None);
                    }

                    Console.SetCursorPosition(currentX, currentY);
                    Console.Write(SpinnerSymbols.Blank);
                }
            }
            finally
            {
                Console.OutputEncoding = originalEncoding;
                Console.CursorVisible = originalCursorVisible;
            }
        }
    }
}
