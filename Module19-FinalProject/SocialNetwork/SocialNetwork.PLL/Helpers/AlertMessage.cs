﻿using System;

namespace SocialNetwork.PLL.Helpers
{
    public class AlertMessage
    {
        public static void Show(string message)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }
    }
}
