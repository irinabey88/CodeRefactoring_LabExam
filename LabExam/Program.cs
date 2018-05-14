using System;
using LabExam.Logger;
using LabExam.Printers;
using LabExam.Services;

namespace LabExam
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Select your choice:");
            Console.WriteLine("0:Add new Epson printer");
            Console.WriteLine("1:Add new Canon printer");
            Console.WriteLine("2:Print on Canon");
            Console.WriteLine("3:Print on Epson");

            DefaultLogger logger = new DefaultLogger();
            PrinterManager printerManager = new PrinterManager(logger, new PrinterRepository());

            var epsonPrinter = new EpsonPrinter("123x");
            var canonPrinter = new CanonPrinter("123x");

            while (true)
            {
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.D0)
                {
                    printerManager.Add(epsonPrinter);
                }

                if (key.Key == ConsoleKey.D1)
                {
                    printerManager.Add(canonPrinter);
                }

                if (key.Key == ConsoleKey.D2)
                {
                    printerManager.Print(canonPrinter, @"D:\1.txt");
                }

                if (key.Key == ConsoleKey.D3)
                {
                    printerManager.Print(epsonPrinter, @"D:\1.txt");
                }

                if (key.Key == ConsoleKey.E)
                {
                    break;
                }
            }
        }      
    }
}
