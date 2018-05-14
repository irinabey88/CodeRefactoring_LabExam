using System;
using System.Collections.Generic;
using System.Linq;
using LabExam.Exceptions;
using LabExam.Interfaces;
using LabExam.Printers.Base;

namespace LabExam.Services
{
    public class PrinterRepository : IRepository<Printer>
    {
        private List<Printer> _printers = new List<Printer>();

        public Printer Get(Printer model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return Get(model.Name, model.Model);
        }

        public Printer Get(string name, string model)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException(nameof(model));
            }

            return this._printers.FirstOrDefault(x => x.Name == name && x.Model == model);
        }

        public Printer Add(Printer model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var foundPrinter = this._printers.Contains(model);

            if (foundPrinter)
            {
                throw new ExistedPrinterException($"Printer {model.Name} {model.Model} already exists");
            }

            this._printers.Add(model);

            return model;
        }

        public IEnumerable<Printer> GetAll()
        {
            return this._printers;
        }
    }
}