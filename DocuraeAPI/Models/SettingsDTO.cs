using DocuraeAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocuraeAPI.Models
{
    public class SettingsDTO
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; }
        public List<SectionsDTO> Sections { get; set; }
        //public ICollection<Section> Sections { get; set; }
    }
    public class SectionsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PatientDTO> Patients { get; set; }
    }
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialNumber { get; set; }
        public bool Public { get; set; }
    }
}
