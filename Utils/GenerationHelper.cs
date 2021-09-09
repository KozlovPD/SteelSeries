using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class GenerationHelper
    {
        private readonly Random _random = new Random();
        private String getRandomAlpabeticalString(int StringLength, bool withNumbers)
        {
            String src;
            if (withNumbers)
            {
                src = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            }
            else
            {
                src = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            int length = StringLength;
            var sb = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                var c = src[_random.Next(0, src.Length)];
                sb.Append(c);
            }
            ;
            return Convert.ToString(sb);
        }

        public string GetRandomPassword(int StringLength)
        {
            return getRandomAlpabeticalString(StringLength, true);
        }

        private int getRandomNumber()
        {
            return _random.Next(0, 9);
        }

        public string getRandomEmail(int StringLength)
        {
            return getRandomAlpabeticalString(StringLength, false) + getRandomNumber() + "@gmail.com";
        }

    }
}
