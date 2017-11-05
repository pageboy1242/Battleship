using System;
using System.Collections.Generic;
using System.Text;
using Battleship.Interfaces;

namespace Battleship.Model
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Clear()
        {
            Console.Clear();    
        }

        public void Write(string format, params object[] args)
        {
            Console.Write(format, args);
        }

        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}
