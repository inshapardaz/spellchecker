﻿using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Inshapardaz.SpellChecker
{
    public static class Checker
    {
        public static string AutoCorrect(string input)
        {
            return input.RemoveDoubleSpaces()
                        .RemoveLeadingAndTrailingSpaces()
                        .FixFullStops();
        }

        public static string RemoveDoubleSpaces(this string input)
        {
            Regex regex = new Regex("[ ]{2,}");
            return regex.Replace(input, " ");
        }

        public static string RemoveLeadingAndTrailingSpaces(this string input)
        {
            Regex regex = new Regex(@"(?<=^\s*)\s|\s(?=\s*$)");
            return regex.Replace(input, "");
        }

        public static string FixFullStops(this string input)
        {
            Regex regex = new Regex("[.]");
            return regex.Replace(input, "۔");
        }

    }
}
