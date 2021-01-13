using System;

namespace HW_1
{
    class MainClass
    {
        delegate double delegateConvertTemperature(double param);

        public static void Main(string[] args)
        {
            var temp = new TemperatureConverterImp();

            delegateConvertTemperature[] arrayOfDelegates = { temp.ConvertrCelsiaIntoFarengate, temp.ConvertFarengateIntoCelsia };

            double testC = 0;
            double testF = 32.1;

            do
            {
                Console.WriteLine($"{arrayOfDelegates[0](testC):F3} F");
                Console.WriteLine($"{arrayOfDelegates[1](testF):F3} C");

                double temperature;
                do
                {
                    Console.WriteLine(" Введите температуру в градусах Цельсия:");
                } while (!double.TryParse(Console.ReadLine(), out temperature));

                Console.WriteLine(" ------------------------------------ ");
                Console.WriteLine("| Сelsius | Kelvin | Reomur | Rankin |");
                Console.WriteLine(" -------------------------------------------- ");
                Console.WriteLine($"| {temperature:F3} | {StaticTempConverters.ConvertIntoKelvin(temperature):F3}" +
                    $" | {StaticTempConverters.ConvertIntoReomur(temperature):F3} | {StaticTempConverters.ConvertIntoRankin(temperature):F3} |");
                Console.WriteLine($" ------------------------------------ {Environment.NewLine}");
                Console.WriteLine(" Для выхода нажмите ESC...");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);


        }
    }

    class TemperatureConverterImp
    {
        internal double ConvertrCelsiaIntoFarengate(double tempF) => 5.0 * (tempF - 32) / 9;

        internal double ConvertFarengateIntoCelsia(double tempC) => 9.0 * tempC / 5 + 32;
    }

    static class StaticTempConverters
    {
        internal static double ConvertIntoKelvin(double tempC) => tempC + 273.15;

        internal static double ConvertIntoReomur(double tempC) => tempC / 1.25;

        internal static double ConvertIntoRankin(double tempC) => 9.0 * ConvertIntoKelvin(tempC) / 5;

    }

}

