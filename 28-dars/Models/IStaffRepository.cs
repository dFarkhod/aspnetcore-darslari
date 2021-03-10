using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.Models
{
    public interface IStaffRepository
    {
        Staff Get(int id);

        IEnumerable<Staff> GetAll();

        Staff Create(Staff staff);
    }
}
