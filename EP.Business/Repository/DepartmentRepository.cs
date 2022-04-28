using AutoMapper;
using EP.Business.Repository.IRepository;
using EP.DataAccess;
using EP.DataAccess.Data;
using EP.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Business.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public DepartmentRepository(ApplicationDbContext db, IMapper mapper, AuthenticationStateProvider authenticationStateProvider)
        {
            _db = db;
            _mapper = mapper;
            _authenticationStateProvider = authenticationStateProvider;

        }
        public async Task<DepartmentDTO> Create(DepartmentDTO objDTO)
        {
            var obj = _mapper.Map<DepartmentDTO, Department>(objDTO);
            //obj.AddBy =

            var authstate = _authenticationStateProvider.GetAuthenticationStateAsync();
        }



        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DepartmentDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentDTO> Update(DepartmentDTO objDTO)
        {
            throw new NotImplementedException();
        }
    }
}
