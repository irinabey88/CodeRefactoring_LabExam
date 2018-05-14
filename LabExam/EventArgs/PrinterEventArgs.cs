using System;
using LabExam.Printers.Base;

namespace LabExam.EventArgs
{
    public class PrinterEventArgs : System.EventArgs
    {
        private Printer _printer;

        public PrinterEventArgs(Printer printer)
        {
            this._printer = printer ?? throw new ArgumentNullException(nameof(printer));
        }

        public string Name => this._printer.Name;

        public string Model => this._printer.Model;       
    }
}