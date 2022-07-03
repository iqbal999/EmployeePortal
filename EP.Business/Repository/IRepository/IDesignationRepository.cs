using EP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Business.Repository.IRepository
{
    public interface IDesignationRepository
    {
        public Task<DesignationDTO> Create(DesignationDTO objDTO);
        public Task<DesignationDTO> Update(DesignationDTO objDTO);
        public Task<int> Delete(int id);
        public Task<DesignationDTO> Get(int id);
        public Task<IEnumerable<DesignationDTO>> GetAll();
    }
}
