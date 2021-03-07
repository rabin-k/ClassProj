using ClassProj.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassProj.Data.Services
{
    public class CollegeService : ICollegeService
    {
        private readonly ClassDbContext _dbContext;
        public CollegeService(ClassDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCollege(College college)
        {
            _dbContext.College.Add(college);
            _dbContext.SaveChanges();
        }

        public void DeleteCollege(int id)
        {
            College C = _dbContext.College.FirstOrDefault(x => x.ID == id);
            if (C != null)
                _dbContext.College.Remove(C);
            _dbContext.SaveChanges();
        }

        public List<College> GetAllColleges()
        {
            return _dbContext.College.ToList();
        }

        public College GetCollegeById(int id)
        {
            return _dbContext.College.FirstOrDefault(x => x.ID == id);
        }

        public void UpdateCollege(College college)
        {
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var dbCollege = _dbContext.College.FirstOrDefault(x => x.ID == college.ID);
                    if (dbCollege != null)
                    {
                        dbCollege.Name = college.Name;
                        dbCollege.Email = college.Email;
                        dbCollege.Address = college.Address;

                        _dbContext.College.Update(dbCollege);
                        _dbContext.SaveChanges();
                    }
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }
            }
        }
    }
}
