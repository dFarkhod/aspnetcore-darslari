using System.Collections.Generic;
using System.Linq;

namespace StaffManagement.Models
{
    public class MockStaffRepository : IStaffRepository
    {
        private List<Staff> _staffs = null;

        public MockStaffRepository()
        {
            _staffs = new List<Staff>()
            {
                new Staff() {Id = 1, FirstName = "Malik", LastName = "Shox", Email = "usmon@virtualdars.com", Department=Departments.Admin },
                new Staff() {Id = 2, FirstName = "Salohiddin", LastName = "Ayyubiy", Email = "usmon@virtualdars.com", Department=Departments.Production },
                new Staff() {Id = 3, FirstName = "Usmon", LastName = "G'oziy", Email = "usmon@virtualdars.com", Department=Departments.RnD}
            };
        }

        public Staff Create(Staff staff)
        {
            staff.Id = _staffs.Max(s => s.Id) + 1;
            _staffs.Add(staff);
            return staff;
        }

        public Staff Delete(int id)
        {
            var staff = _staffs.FirstOrDefault(s => s.Id.Equals(id));
            if (staff != null)
            {
                _staffs.Remove(staff);
            }
            return staff;
        }

        public Staff Get(int id)
        {
            return _staffs.FirstOrDefault(staff => staff.Id.Equals(id));
        }

        public IEnumerable<Staff> GetAll()
        {
            return _staffs;
        }

        public Staff Update(Staff updatedStaff)
        {
            var staff = _staffs.FirstOrDefault(s => s.Id.Equals(updatedStaff.Id));
            if (staff != null)
            {
                staff.FirstName = updatedStaff.FirstName;
                staff.LastName = updatedStaff.LastName;
                staff.Email = updatedStaff.Email;
                staff.Department = updatedStaff.Department;

            }
            return staff;
        }
    }
}
