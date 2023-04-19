using BReports.Models.DBModels;
using System.Collections.Generic;

namespace BReports.Services
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        int GetCount();
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
