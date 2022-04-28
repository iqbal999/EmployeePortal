using EP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Business.Repository.IRepository
{
    public interface IDepartmentRepository
    {
        public Task<DepartmentDTO> Create(DepartmentDTO objDTO);
        public Task<DepartmentDTO> Update(DepartmentDTO objDTO);
        public Task<int> Delete(int id);
        public Task<DepartmentDTO> Get(int id);
        public Task<IEnumerable<DepartmentDTO>> GetAll();
    }
}
