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
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public StatusRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<StatusDTO> Create(StatusDTO objDTO)
        {
            if (_db.Statuses.Any(s => s.StatusName == objDTO.StatusName)) return new StatusDTO();

            var obj = _mapper.Map<StatusDTO, Status>(objDTO);
            obj.AddBy = CurrentUser.UserId;
            obj.AddedDateTime = DateTime.Now;

            var addedObj = await _db.Statuses.AddAsync(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Status, StatusDTO>(addedObj.Entity);
        }


        public async Task<int> Delete(int id)
        {
            var obj = await _db.Statuses.FindAsync(id);
            if (obj != null)
            {
                obj.IsArchived = true;
                _db.Statuses.Update(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<StatusDTO> Get(int id)
        {
            var obj = await _db.Statuses.FirstOrDefaultAsync(x => x.Id == id && x.IsArchived == false);
            if (obj != null)
            {
                return _mapper.Map<Status, StatusDTO>(obj);
            }
            return new StatusDTO();
        }

        public async Task<IEnumerable<StatusDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Status>, IEnumerable<StatusDTO>>(_db.Statuses.Where(x => x.IsArchived == false));
        }

        public async Task<StatusDTO> Update(StatusDTO objDTO)
        {
            var obj = await _db.Statuses.FindAsync(objDTO.Id);
            if (obj != null)
            {
                obj.StatusName = objDTO.StatusName;
                obj.Remarks = objDTO.Remarks;

                _db.Statuses.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<Status, StatusDTO>(obj);
            }

            return objDTO;
        }
    }
}
