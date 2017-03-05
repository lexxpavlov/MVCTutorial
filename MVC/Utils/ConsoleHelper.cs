﻿using System;

namespace MVC.Utils
{
    public static class ConsoleHelper
    {
        public static int ReadInt(string message = null)
        {
            int num;
            do
            {
                if (!string.IsNullOrWhiteSpace(message))
                {
                    Console.Write(message);
                }
            }
            while (!int.TryParse(Console.ReadLine(), out num));
            return num;
        }

        public static double ReadDouble(string message = null)
        {
            double num;
            do
            {
                if (!string.IsNullOrWhiteSpace(message))
                {
                    Console.Write(message);
                }
            }
            while (!double.TryParse(Console.ReadLine(), out num));
            return num;
        }

        public static string ReadString(string message = null)
        {
            string str;
            do
            {
                if (!string.IsNullOrWhiteSpace(message))
                {
                    Console.Write(message);
                }
                str = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(str));
            return str;
        }
    }
}
