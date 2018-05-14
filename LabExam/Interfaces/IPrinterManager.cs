using System.Collections.Generic;
using LabExam.Printers.Base;

namespace LabExam.Interfaces
{
    public interface IPrinterManager<T> where T : Printer
    {
        void Print(T printer, string fileName);

        T Add(T printer);

        IEnumerable<T> GetPrinterList();
    }
}