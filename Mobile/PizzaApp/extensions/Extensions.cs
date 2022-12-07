﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.extensions
{
    public static class StringExtensions
    {
        public static string FirstCapitalLetter(this string str)
        {
            if (string.IsNullOrEmpty(str))
            { 
                return str;
            }
            string ret = str.ToLower();

            ret = ret.Substring(0, 1).ToUpper() + ret.Substring(1, ret.Length-1);

            return ret;
        }

    }
}
