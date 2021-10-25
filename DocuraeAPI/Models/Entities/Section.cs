using System;
using System.Collections.Generic;

namespace DocuraeAPI.Models.Entities
{
    public partial class Section
    {
        public Section()
        {
            Patient = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int UnitId { get; set; }
        public string Name { get; set; }

        public Company Company { get; set; }
        public Unit Unit { get; set; }
        public ICollection<Patient> Patient { get; set; }
    }
}
