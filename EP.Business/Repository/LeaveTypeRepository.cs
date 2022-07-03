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
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public LeaveTypeRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<LeaveTypeDTO> Create(LeaveTypeDTO objDTO)
        {
            var obj = _mapper.Map<LeaveTypeDTO, LeaveType>(objDTO);
            obj.AddBy = CurrentUser.UserId;
            obj.AddedDateTime = DateTime.Now;

            var addedObj = await _db.LeaveTypes.AddAsync(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<LeaveType, LeaveTypeDTO>(addedObj.Entity);
        }


        public async Task<int> Delete(int id)
        {
            var obj = await _db.LeaveTypes.FindAsync(id);
            if (obj != null)
            {
                obj.IsArchived = true;
                _db.LeaveTypes.Update(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<LeaveTypeDTO> Get(int id)
        {
            var obj = await _db.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id && x.IsArchived == false);
            if (obj != null)
            {
                return _mapper.Map<LeaveType, LeaveTypeDTO>(obj);
            }
            return new LeaveTypeDTO();
        }

        public async Task<IEnumerable<LeaveTypeDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<LeaveType>, IEnumerable<LeaveTypeDTO>>(_db.LeaveTypes.Where(x => x.IsArchived == false));
        }

        public async Task<LeaveTypeDTO> Update(LeaveTypeDTO objDTO)
        {
            var obj = await _db.LeaveTypes.FindAsync(objDTO.Id);
            if (obj != null)
            {
                obj.LeaveTypeName = objDTO.LeaveTypeName;
                obj.Remarks = objDTO.Remarks;

                _db.LeaveTypes.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<LeaveType, LeaveTypeDTO>(obj);
            }

            return objDTO;
        }
    }
}
