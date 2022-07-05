using EP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Business.Repository.IRepository
{
    public interface IStatusRepository
    {
        public Task<StatusDTO> Create(StatusDTO objDTO);
        public Task<StatusDTO> Update(StatusDTO objDTO);
        public Task<int> Delete(int id);
        public Task<StatusDTO> Get(int id);
        public Task<IEnumerable<StatusDTO>> GetAll();
    }
}
