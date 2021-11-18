using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnglishNumberToText : INumberToText
{
    private const long TEN = 10;
    private const long HUNDRED = 100;
    private const long THOUSAND = 1000;
    private const long MILLION = 1000000;
    private const long BILLION = 1000000000;

    private static readonly string[] UP_TO_19 = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
    private static readonly string[] UP_TO_100 = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

    public string NumberToText(long n)
    {
        if (n < 0)
        {
            return "minus " + NumberToText(-n);
        }
        else if (n == 0)
        {
            return "zero";
        }
        else if (n <= 19)
        {
            return $"{UP_TO_19[n - 1]} ";
        }
        else if (n <= 99)
        {
            var value = UP_TO_100[n / TEN - 2];
            if (n % TEN != 0) { value = $"{value} {NumberToText(n % TEN)}"; }
            return value;
        }
        else if (n <= 999)
        {
            var value = $"{NumberToText(n / HUNDRED)} hundred ";
            if (n % HUNDRED != 0) { value = $"{value} {NumberToText(n % HUNDRED)}"; }
            return value;
        }
        else if (n <= 999999)
        {
            var value = $"{NumberToText(n / THOUSAND)} thousand ";
            if (n % THOUSAND != 0) { value = $"{value} {NumberToText(n % THOUSAND)}"; }
            return value;
        }
        else if (n <= 999999999)
        {
            var value = $"{NumberToText(n / MILLION)} million ";
            if (n % MILLION != 0) { value = $"{value} {NumberToText(n % MILLION)}"; }
            return value;
        }
        else
        {
            var value = $"{NumberToText(n / BILLION)} billion ";
            if (n % BILLION != 0) { value = $"{value} {NumberToText(n % BILLION)}"; }
            return value;
        }
    }
}
