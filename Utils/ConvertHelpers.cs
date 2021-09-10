using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Utils
{
    public class ConvertHelpers
    {
        public List<decimal> ParsePricesToDecimal(List<IWebElement> list)
        {
            NumberStyles style;
            CultureInfo culture;
            style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            culture = CultureInfo.CreateSpecificCulture("es-es");
            var ListOfPricesAsString = list;
            var pricesList = new List<decimal>();
            foreach (IWebElement element in list)
            {
                decimal number;
                var value = element.Text;
                if (Decimal.TryParse(value, style, culture, out number))
                    Console.WriteLine("Converted '{0}' to {1}.", value, number);
                else
                    Console.WriteLine("Unable to convert '{0}'.", value);
                pricesList.Add(number);
            }
            return pricesList;
        }
    }
}
