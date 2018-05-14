using System;
using System.IO;
using LabExam.Printers.Base;

namespace LabExam.Printers
{
    internal class CanonPrinter : Printer
    {
        public CanonPrinter(string model) : base ("Canon", model) { }

        protected override void CustomPrint(Stream stream)
        {
            for (int i = 0; i < stream.Length; i++)
            {
                // simulate printing
                Console.WriteLine(stream.ReadByte());
            }
        }
    }
}