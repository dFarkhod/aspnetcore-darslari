using StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagement.DataAccess.Models
{
    public class SqlserverStaffRepository : IStaffRepository
    {
        private readonly AppDbContext dbContext;

        public SqlserverStaffRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        Staff IStaffRepository.Create(Staff staff)
        {
            dbContext.Staffs.Add(staff);
            dbContext.SaveChanges();
            return staff;
        }

        Staff IStaffRepository.Delete(int id)
        {
            var staff = dbContext.Staffs.Find(id);
            if (staff != null)
            {
                dbContext.Staffs.Remove(staff);
                dbContext.SaveChanges();
            }
            return staff;
        }

        Staff IStaffRepository.Get(int id)
        {
           return dbContext.Staffs.Find(id);
        }

        IEnumerable<Staff> IStaffRepository.GetAll()
        {
           return dbContext.Staffs;
        }

        Staff IStaffRepository.Update(Staff updateStaff)
        {
            var staff = dbContext.Staffs.Attach(updateStaff);
            staff.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return updateStaff;
        }
    }
}
