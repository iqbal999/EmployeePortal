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
    public class DesignationRepository : IDesignationRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public DesignationRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<DesignationDTO> Create(DesignationDTO objDTO)
        {
            var obj = _mapper.Map<DesignationDTO, Designation>(objDTO);
            obj.AddBy = CurrentUser.UserId;
            obj.AddedDateTime = DateTime.Now;

            var addedObj = await _db.Designations.AddAsync(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Designation, DesignationDTO>(addedObj.Entity);
        }


        public async Task<int> Delete(int id)
        {
            var obj = await _db.Designations.FindAsync(id);
            if (obj != null)
            {
                obj.IsArchived = true;
                _db.Designations.Update(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<DesignationDTO> Get(int id)
        {
            var obj = await _db.Designations.FirstOrDefaultAsync(x => x.Id == id && x.IsArchived == false);
            if (obj != null)
            {
                return _mapper.Map<Designation, DesignationDTO>(obj);
            }
            return new DesignationDTO();
        }

        public async Task<IEnumerable<DesignationDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Designation>, IEnumerable<DesignationDTO>>(_db.Designations.Where(x => x.IsArchived == false));
        }

        public async Task<DesignationDTO> Update(DesignationDTO objDTO)
        {
            var obj = await _db.Designations.FindAsync(objDTO.Id);
            if (obj != null)
            {
                obj.Name = objDTO.Name;
                obj.Remarks = objDTO.Remarks;

                _db.Designations.Update(obj);
                await _db.SaveChangesAsync();
                return _mapper.Map<Designation, DesignationDTO>(obj);
            }

            return objDTO;
        }
    }
}
