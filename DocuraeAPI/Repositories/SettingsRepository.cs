using DocuraeAPI.Models;
using DocuraeAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocuraeAPI.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly ApplicationDbContext _context;
        public SettingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SettingsDTO> GetSettingsAsync() 
        {
            var model = await _context.Company.Where(c => c.Id == 1)
                .Include(c => c.Unit)
                .ThenInclude(c => c.Section)
                .Select(c => new SettingsDTO()
                {
                    CompanyId = c.Id,
                    Name = c.Name,
                    UnitId = c.Unit.FirstOrDefault().Id,
                    Sections = c.Section.Select(s => new SectionsDTO()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Patients = _context.Patient.Where(p=>p.SectionId == s.Id).Select(p => new PatientDTO()
                        {
                            Id = p.Id,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            SocialNumber = p.SocialNumber,
                            Public = (bool)p.Public
                        }).ToList()

                    }).OrderBy(s => s.Id).ToList()

                }).FirstOrDefaultAsync();

            
            return model;
        }
    }
}
