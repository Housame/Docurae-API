using System;
using System.Collections.Generic;

namespace DocuraeAPI.Models.Entities
{
    public partial class User
    {
        public User()
        {
            Individual = new HashSet<Individual>();
            LogText = new HashSet<LogText>();
            LogTextAdditions = new HashSet<LogTextAdditions>();
            Reminder = new HashSet<Reminder>();
        }

        public int Id { get; set; }
        public string CompanyId { get; set; }
        public string FirstName { get; set; }
        public string HashId { get; set; }
        public string LastName { get; set; }
        public string SocialNumber { get; set; }
        public string JobTitle { get; set; }

        public ICollection<Individual> Individual { get; set; }
        public ICollection<LogText> LogText { get; set; }
        public ICollection<LogTextAdditions> LogTextAdditions { get; set; }
        public ICollection<Reminder> Reminder { get; set; }
    }
}
