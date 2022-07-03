using EP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Business.Repository.IRepository
{
    public interface IEmployeeLeaveRepository
    {
        public Task<EmployeeLeaveDTO> Create(EmployeeLeaveDTO objDTO);
        public Task<EmployeeLeaveDTO> Update(EmployeeLeaveDTO objDTO);
        public Task<int> Delete(int id);
        public Task<EmployeeLeaveDTO> Get(int id);
        public Task<IEnumerable<EmployeeLeaveDTO>> GetAll(int? id = null);
    }
}
