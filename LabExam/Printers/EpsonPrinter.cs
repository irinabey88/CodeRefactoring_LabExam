using System;
using System.IO;
using LabExam.Printers.Base;

namespace LabExam.Printers
{
    internal class EpsonPrinter : Printer
    {
        public EpsonPrinter(string model) : base("Epson", model) { }

        protected override void CustomPrint(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            for (int i = 0; i < stream.Length; i++)
            {
                // simulate printing
                Console.WriteLine(stream.ReadByte());
            }
        }
    }
}