using System.Collections.Generic;

namespace BReports.Services
{
    public interface IUserService
    {
        void GetAll();
        int GetCount();

        void GetById(int id);
        void Create();
        void Update(int id);
        void Delete(int id);

    }
}
