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
    public class EmployeeLeaveRepository : IEmployeeLeaveRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public EmployeeLeaveRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }
        public async Task<EmployeeLeaveDTO> Create(EmployeeLeaveDTO objDTO)
        {
            var obj = _mapper.Map<EmployeeLeaveDTO, EmployeeLeave>(objDTO);
            obj.AddBy = CurrentUser.UserId;
            obj.AddedDateTime = DateTime.Now;

            var addedObj = await _db.EmployeeLeaves.AddAsync(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<EmployeeLeave, EmployeeLeaveDTO>(addedObj.Entity);
        }


        public async Task<int> Delete(int id)
        {
            var obj = await _db.EmployeeLeaves.FindAsync(id);
            if (obj != null)
            {
                obj.IsArchived = true;
                _db.EmployeeLeaves.Update(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<EmployeeLeaveDTO> Get(int id)
        {
            var obj = await _db.EmployeeLeaves
                .Include(u => u.Employee)
                .Include(u => u.LeaveType)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsArchived == false);
            if (obj != null)
            {
                return _mapper.Map<EmployeeLeave, EmployeeLeaveDTO>(obj);
            }
            return new EmployeeLeaveDTO();
        }

        public async Task<IEnumerable<EmployeeLeaveDTO>> GetAll(int? id = null)
        {
            if (id != null && id > 0)
            {
                return _mapper.Map<IEnumerable<EmployeeLeave>, IEnumerable<EmployeeLeaveDTO>>(_db.EmployeeLeaves
                .Include(u => u.Employee)
                .Include(u => u.LeaveType)
                .Where(x => x.EmployeeId == id && x.IsArchived == false));
            }
            else
            {
                return _mapper.Map<IEnumerable<EmployeeLeave>, IEnumerable<EmployeeLeaveDTO>>(_db.EmployeeLeaves
                .Include(u => u.Employee)
                .Include(u => u.LeaveType)
                .Where(x => x.IsArchived == false));
            }

        }

        public async Task<EmployeeLeaveDTO> Update(EmployeeLeaveDTO objDTO)
        {
            var obj = await _db.EmployeeLeaves.FindAsync(objDTO.Id);
            if (obj != null)
            {
                obj.EmployeeId = objDTO.EmployeeId;
                obj.LeaveId = objDTO.LeaveId;
                obj.TotalLeaveDays = objDTO.TotalLeaveDays;
                obj.EnjoyLeaveDays = objDTO.EnjoyLeaveDays;
                obj.BalanceLeaveDays = objDTO.BalanceLeaveDays;
                obj.Remarks = objDTO.Remarks;

                _db.EmployeeLeaves.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<EmployeeLeave, EmployeeLeaveDTO>(obj);
            }

            return objDTO;
        }
    }
}
