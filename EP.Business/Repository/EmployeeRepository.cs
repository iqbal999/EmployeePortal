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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public EmployeeRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }
        public async Task<EmployeeDTO> Create(EmployeeDTO objDTO)
        {
            var obj = _mapper.Map<EmployeeDTO, Employee>(objDTO);
            obj.AddBy = CurrentUser.UserId;
            obj.AddedDateTime = DateTime.Now;

            var addedObj = await _db.Employees.AddAsync(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Employee, EmployeeDTO>(addedObj.Entity);
        }


        public async Task<int> Delete(int id)
        {
            var obj = await _db.Employees.FindAsync(id);
            if (obj != null)
            {
                obj.IsArchived = true;
                _db.Employees.Update(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<EmployeeDTO> Get(int id)
        {
            var obj = await _db.Employees
                .Include(u => u.Department)
                .Include(u => u.Designation)
                .Include(u => u.Manager)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsArchived == false);
            if (obj != null)
            {
                return _mapper.Map<Employee, EmployeeDTO>(obj);
            }
            return new EmployeeDTO();
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(_db.Employees
                .Include(u => u.Department)
                .Include(u => u.Designation)
                .Include(u => u.Manager)
                .Where(x => x.IsArchived == false));
        }

        public async Task<EmployeeDTO> Update(EmployeeDTO objDTO)
        {
            var obj = await _db.Employees.FindAsync(objDTO.Id);
            if (obj != null)
            {
                obj.FirstName = objDTO.FirstName;
                obj.LastName = objDTO.LastName;
                obj.Email = objDTO.Email;
                obj.Phone = objDTO.Phone;
                obj.Phone2 = objDTO.Phone2;
                obj.DesignationId = objDTO.DesignationId;
                obj.DepartmentId = objDTO.DepartmentId;
                obj.ManagerId = objDTO.ManagerId;
                obj.JoiningDate = objDTO.JoiningDate;
                obj.PresentAddress = objDTO.PresentAddress;
                obj.PermanentAddress = objDTO.PermanentAddress;
                obj.ImageFileExtension = objDTO.ImageFileExtension;
                obj.ImagePath = objDTO.ImagePath;

                _db.Employees.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<Employee, EmployeeDTO>(obj);
            }

            return objDTO;
        }
    }
}
