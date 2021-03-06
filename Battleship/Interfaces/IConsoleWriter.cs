﻿namespace Battleship.Interfaces
{
    public interface IConsoleWriter
    {
        void Clear();
        void Write(string format, params object[] args);
        void WriteLine(string format, params object[] args);
        string ReadLine();
    }
}
