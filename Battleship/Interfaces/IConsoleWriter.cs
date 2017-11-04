using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Interfaces
{
    public interface IConsoleWriter
    {
        void Write(string format, params object[] args);
        void WriteLine(string format, params object[] args);
    }
}
