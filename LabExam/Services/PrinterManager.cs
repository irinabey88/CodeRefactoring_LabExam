using System;
using System.Collections.Generic;
using System.IO;
using LabExam.Exceptions;
using LabExam.Interfaces;
using LabExam.Printers.Base;

namespace LabExam.Services
{
    public class PrinterManager : IPrinterManager<Printer>
    {
        private readonly ILogger _logger;
        private readonly IRepository<Printer> _printerList;

        public PrinterManager(ILogger logger, IRepository<Printer> printersList)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._printerList = printersList ?? throw new ArgumentNullException(nameof(printersList));
        }

        public void Print(Printer printer, string fileName)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(nameof(printer));
            }

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("Empty or null file name");
            }

            var foundPrinter = this._printerList.Get(printer) ?? throw new PrinterNotFoundException($"{printer.Name} {printer.Model}");

            this._logger.Log($"Printer {printer.Name} {printer.Model} prints ...");

            using (FileStream fileStream = File.OpenRead(fileName))
            {
                foundPrinter.Print(fileStream);
            }
        }

        public Printer Add(Printer printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(nameof(printer));
            }            

            var addedPrinter = this._printerList.Add(printer);

            if (addedPrinter != null)
            {
                this._logger.Log($"Printer {addedPrinter.Name} {addedPrinter.Model} was added to printer list");
            }
            else
            {
                this._logger.Log($"Printer {printer.Name} {printer.Model} wasn't added to printer list");
            }

            return addedPrinter;
        }

        public IEnumerable<Printer> GetPrinterList()
        {
            return this._printerList.GetAll();
        }           
    }
}