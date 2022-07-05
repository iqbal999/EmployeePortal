using AutoMapper;
using EP.Business.Repository.IRepository;
using EP.DataAccess;
using EP.DataAccess.Data;
using EP.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
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

        public DepartmentRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<DepartmentDTO> Create(DepartmentDTO objDTO)
        {
            var obj = _mapper.Map<DepartmentDTO, Department>(objDTO);
            obj.AddBy = CurrentUser.UserId;
            obj.AddedDateTime = DateTime.Now;

            var addedObj = await _db.Departments.AddAsync(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Department, DepartmentDTO>(addedObj.Entity);
        }


        public async Task<int> Delete(int id)
        {
            var obj = await _db.Departments.FindAsync(id);
            if (obj != null)
            {
                obj.IsArchived = true;
                _db.Departments.Update(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<DepartmentDTO> Get(int id)
        {
            var obj = await _db.Departments.FirstOrDefaultAsync(x => x.Id == id && x.IsArchived == false);
            if (obj != null)
            {
                return _mapper.Map<Department, DepartmentDTO>(obj);
            }
            return new DepartmentDTO();
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDTO>>(_db.Departments.Where(x => x.IsArchived == false));
        }

        public async Task<DepartmentDTO> Update(DepartmentDTO objDTO)
        {
            var obj = await _db.Departments.FindAsync(objDTO.Id);
            if (obj != null)
            {
                obj.Name = objDTO.Name;
                obj.Remarks = objDTO.Remarks;

                _db.Departments.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<Department, DepartmentDTO>(obj);
            }

            return objDTO;
        }
    }
}
