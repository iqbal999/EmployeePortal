using EP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Business.Repository.IRepository
{
    public interface ILeaveApplicationRepository
    {
        public Task<LeaveApplicationDTO> Create(LeaveApplicationDTO objDTO);
        public Task<LeaveApplicationDTO> Update(LeaveApplicationDTO objDTO);
        public Task<int> Delete(int id);
        public Task<LeaveApplicationDTO> Get(int id);
        public Task<IEnumerable<LeaveApplicationDTO>> GetAll(int? id = null);
    }
}
