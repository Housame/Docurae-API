using System;
using System.Collections.Generic;

namespace DocuraeAPI.Models.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            LogText = new HashSet<LogText>();
        }

        public int Id { get; set; }
        public int SectionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialNumber { get; set; }
        public bool? Public { get; set; }

        public Section Section { get; set; }
        public ICollection<LogText> LogText { get; set; }
    }
}
