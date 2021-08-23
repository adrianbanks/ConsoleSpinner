using System;
using System.Text;

namespace ConsoleSpinner
{
    internal sealed class ConsoleSettings : IDisposable
    {
        private readonly Encoding _originalEncoding;
        private readonly bool _originalCursorVisible;

        public int X { get; }
        public int Y { get; }

        public ConsoleSettings()
        {
            _originalEncoding = Console.OutputEncoding;
            _originalCursorVisible = Console.CursorVisible;

            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            X = Console.CursorLeft;
            Y = Console.CursorTop;
        }

        public void Dispose()
        {
            Console.OutputEncoding = _originalEncoding;
            Console.CursorVisible = _originalCursorVisible;
        }
    }
}
