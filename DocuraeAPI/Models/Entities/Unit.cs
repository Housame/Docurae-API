using System;
using System.Collections.Generic;

namespace DocuraeAPI.Models.Entities
{
    public partial class Unit
    {
        public Unit()
        {
            Individual = new HashSet<Individual>();
            LogText = new HashSet<LogText>();
            Section = new HashSet<Section>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Adress2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CompanyId { get; set; }

        public Company Company { get; set; }
        public ICollection<Individual> Individual { get; set; }
        public ICollection<LogText> LogText { get; set; }
        public ICollection<Section> Section { get; set; }
    }
}
