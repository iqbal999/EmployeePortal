using EP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Business.Repository.IRepository
{
    public interface ILeaveTypeRepository
    {
        public Task<LeaveTypeDTO> Create(LeaveTypeDTO objDTO);
        public Task<LeaveTypeDTO> Update(LeaveTypeDTO objDTO);
        public Task<int> Delete(int id);
        public Task<LeaveTypeDTO> Get(int id);
        public Task<IEnumerable<LeaveTypeDTO>> GetAll();
    }
}
