using System.Collections.Generic;

namespace LabExam.Interfaces
{
    public interface IRepository<TModel> where TModel : class
    {
        TModel Get(TModel model);

        TModel Get(string name, string model);

        TModel Add(TModel model);

        IEnumerable<TModel> GetAll();
    }
}