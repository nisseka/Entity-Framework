using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Basics.Models
{
    public enum TemperatureScaleTypes { Celcius, Fahrenheit };

    public class HumanTemperatureModel
    {
        private List<string> temperatureScaleStrings;

        private TemperatureScaleTypes temperatureScale;
        private double temperature;
        private string message;

        public double Temperature 
        { 
            get => temperature; 
            set 
            {
                double temperatureCelcius;

                temperature = value;

		switch (temperatureScale)
		{
                    case TemperatureScaleTypes.Fahrenheit:
                        temperatureCelcius = (temperature - 32) / 1.8;
                        break;
                    case TemperatureScaleTypes.Celcius:
                    default:
                        temperatureCelcius = temperature;
                        break;
		}

                message = CheckTemperature(temperatureCelcius);
            }
        }

        public TemperatureScaleTypes TemperatureScale
	{
            get => temperatureScale;
            set
	    {
                temperatureScale = value;
            }
	}

        public string TemperatureScaleString 
        { 
            get => temperatureScaleStrings[(int) temperatureScale]; 
            set 
            {
                int index = temperatureScaleStrings.IndexOf(value);

                if (index >= 0)
                    TemperatureScale = (TemperatureScaleTypes) index;
                else
                    TemperatureScale = TemperatureScaleTypes.Celcius;
            } 
        }

        public string TemperatureString
	{
            get => String.Format(CultureInfo.InvariantCulture,"{0:F1}",temperature);
            set
            {
                double temperature;
                // Convert the temperature form number field on the webpage to a decimal number. The browser (hopefully) sent a string 
                // with . (as per the HTML5 standard) as the decimal separator (f.ex: 38.6). But many countries uses , as the decimal
                // separator (including Sweden). Using CultureInfo.InvariantCulture as an additional parameter to ToDouble() forces
                // it to convert with a . as the decimal separator.
                try
                {
                    if (value.IndexOf(".") > 0)                                           // Found . as decimal separator
                        temperature = Convert.ToDouble(value, CultureInfo.InvariantCulture);
                    else
                        temperature = Convert.ToDouble(value);
                } catch
                {
                    temperature = 0;
                }

                Temperature = temperature;
            }
        }

        public string TemperatureScaleUnitString
	{
            get => $"°{TemperatureScaleString.Substring(0, 1)}";
        }

        public string Message { get => message; }

        public HumanTemperatureModel()
	{
            Init();
            temperatureScale = TemperatureScaleTypes.Celcius;
            temperature = 37.0;
            message = string.Empty;
	}

        public HumanTemperatureModel(string temperatureString, string temperatureScaleString)
	{
            Init();
            TemperatureScaleString = temperatureScaleString;
            TemperatureString = temperatureString;
        }

        private void Init()
	{
            temperatureScaleStrings = new List<string>();
            temperatureScaleStrings.Add("Celcius");
            temperatureScaleStrings.Add("Fahrenheit");
        }

        public string MakeHTMLCodeFromMessage()
	{
            string str;
            if (message.Length > 0)
            {
                str = $"\t\t<p>Submitted temperature: {TemperatureString} {TemperatureScaleUnitString}</p>\r\n";
                str += $"\t\t<h2>{message}</h2>\r\n";
            } else
                str = string.Empty;
            return str;
        }

        public bool CheckTemperatureScaleActive(TemperatureScaleTypes aTemperatureScale)
	{
            return temperatureScale == aTemperatureScale;
        }

        public static string CheckTemperature(double temperature)
	{
            string message;

	    if (temperature > 45)
	    {
                message = "You are on fire!!";
            } else
	    if (temperature > 41)
	    {
                message = "You are burning up!!";
            } else
            if (temperature >= 38)
            {
                message = "You have a fever!";
            } else
	    if (temperature >= 32 && temperature < 35)
	    {
                message = "You have mild hypothermia!";
            } else
            if (temperature >= 28 && temperature < 32)
            {
                message = "You have moderate hypothermia!!";
            } else
            if (temperature>= 20 && temperature < 28)
            {
                message = "You have severe hypothermia!!!";
            } else
            if (temperature < 20)
            {
                message = "You are DEAD!!!";
            } else
                message = "Your temperature is normal";

            return message;
	}

    }
}
