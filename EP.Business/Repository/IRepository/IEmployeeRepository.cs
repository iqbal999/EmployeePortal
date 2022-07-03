using EP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Business.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        public Task<EmployeeDTO> Create(EmployeeDTO objDTO);
        public Task<EmployeeDTO> Update(EmployeeDTO objDTO);
        public Task<int> Delete(int id);
        public Task<EmployeeDTO> Get(int id);
        public Task<IEnumerable<EmployeeDTO>> GetAll();
    }
}
