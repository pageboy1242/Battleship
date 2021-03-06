﻿using System;
using Battleship.Interfaces;

namespace Battleship.Model
{
    /// <summary>
    /// Concrete implementation of the console writer
    /// </summary>
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

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
