using System;
using System.Collections.Generic;

namespace DocuraeAPI.Models.Entities
{
    public partial class Company
    {
        public Company()
        {
            Section = new HashSet<Section>();
            Unit = new HashSet<Unit>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoId { get; set; }
        public int UnitsCount { get; set; }

        public ICollection<Section> Section { get; set; }
        public ICollection<Unit> Unit { get; set; }
    }
}
