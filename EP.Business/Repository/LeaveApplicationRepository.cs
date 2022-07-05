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
    public class LeaveApplicationRepository : ILeaveApplicationRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public LeaveApplicationRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<LeaveApplicationDTO> Create(LeaveApplicationDTO objDTO)
        {
            var obj = _mapper.Map<LeaveApplicationDTO, LeaveApplication>(objDTO);
            obj.AddBy = CurrentUser.UserId;
            obj.AddedDateTime = DateTime.Now;

            var addedObj = await _db.LeaveApplications.AddAsync(obj);
            await _db.SaveChangesAsync();

            string applicationId = "LA-" + DateTime.Now.ToString("ddMMyy") + "-";
            applicationId += addedObj.Entity.Id;

            obj.ApplicationId = applicationId;
            _db.LeaveApplications.Attach(obj).Property(x => x.ApplicationId).IsModified = true;
            _db.SaveChanges();

            return _mapper.Map<LeaveApplication, LeaveApplicationDTO>(addedObj.Entity);
        }


        public async Task<int> Delete(int id)
        {
            var obj = await _db.LeaveApplications.FindAsync(id);
            if (obj != null)
            {
                obj.IsArchived = true;
                _db.LeaveApplications.Update(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<LeaveApplicationDTO> Get(int id)
        {
            var obj = await _db.LeaveApplications
                .Include(a => a.Applicant)
                .Include(a => a.LeaveType)
                .Include(a => a.Manager)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsArchived == false);
            if (obj != null)
            {
                return _mapper.Map<LeaveApplication, LeaveApplicationDTO>(obj);
            }
            return new LeaveApplicationDTO();
        }

        public async Task<IEnumerable<LeaveApplicationDTO>> GetAll(int? id = null)
        {
            if (id != null && id > 0)
            {
                return _mapper.Map<IEnumerable<LeaveApplication>, IEnumerable<LeaveApplicationDTO>>(_db.LeaveApplications
                    .Include(a => a.Applicant)
                    .Include(a => a.LeaveType)
                    .Include(a => a.Manager)
                    .Where(x => x.ApplicantId == id && x.IsArchived == false));
            }
            else
            {
                return _mapper.Map<IEnumerable<LeaveApplication>, IEnumerable<LeaveApplicationDTO>>(_db.LeaveApplications
                    .Include(a => a.Applicant)
                    .Include(a => a.LeaveType)
                    .Include(a => a.Manager)
                    .Where(x => x.IsArchived == false));
            }
        }

        public async Task<LeaveApplicationDTO> Update(LeaveApplicationDTO objDTO)
        {
            var obj = await _db.LeaveApplications.FindAsync(objDTO.Id);
            if (obj != null)
            {
                obj.LeaveTypeId = objDTO.LeaveTypeId;
                obj.LeaveFrom = objDTO.LeaveFrom;
                obj.LeaveTo = objDTO.LeaveTo;
                obj.LeaveDays = objDTO.LeaveDays;
                obj.LeaveReason = objDTO.LeaveReason;

                _db.LeaveApplications.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<LeaveApplication, LeaveApplicationDTO>(obj);
            }

            return objDTO;
        }
    }
}
