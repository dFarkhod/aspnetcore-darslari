using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.Models
{
    public class MockStaffRepository : IStaffRepository
    {
        private List<Staff> _staffs = null;

        public MockStaffRepository()
        {
            _staffs = new List<Staff>()
            {
                new Staff() {Id = 1, FirstName = "Malik", LastName = "Shox", Email = "usmon@virtualdars.com", Department="Admin" },
                new Staff() {Id = 2, FirstName = "Salohiddin", LastName = "Ayyubiy", Email = "usmon@virtualdars.com", Department="Production" },
                new Staff() {Id = 3, FirstName = "Usmon", LastName = "G'oziy", Email = "usmon@virtualdars.com", Department="R&D" }
            };
        }
        public Staff Get(int id)
        {
            return _staffs.FirstOrDefault(staff => staff.Id.Equals(id));
        }

        public IEnumerable<Staff> GetAll()
        {
            return _staffs;
        }
    }
}
