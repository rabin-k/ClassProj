using ClassProj.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassProj.Data.Services
{
    public interface ICollegeService
    {
        List<College> GetAllColleges();
        College GetCollegeById(int id);
        void AddCollege(College college);
        void UpdateCollege(College college);
        void DeleteCollege(int id);
    }
}
