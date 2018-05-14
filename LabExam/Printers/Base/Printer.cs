using System;
using System.IO;
using LabExam.EventArgs;
using LabExam.Interfaces;

namespace LabExam.Printers.Base
{
    public abstract class  Printer : IPrint
    {
        private string _name;

        private string _model;

        public event EventHandler<PrinterEventArgs> OnPrinted;

        public string Name  
        {
            get => this._name;
            private set => this._name = value;
        }

        public string Model
        {
            get => this._model;
            private set => this._model = value;
        }

        public Printer(string name, string model)
        {
            this.Model = model ?? throw new ArgumentNullException(nameof(model));
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Print(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            CustomPrint(stream);
        }

        protected abstract void CustomPrint(Stream stream);

        protected virtual void OnPrint() => OnPrinted?.Invoke(this, new PrinterEventArgs(this));
    }
}