using System;
using System.Collections.Generic;

namespace DocuraeAPI.Models.Entities
{
    public partial class LogText
    {
        public LogText()
        {
            LogTextAdditions = new HashSet<LogTextAdditions>();
            Reminder = new HashSet<Reminder>();
        }

        public int Id { get; set; }
        public int LogTextTypeId { get; set; }
        public string LogText1 { get; set; }
        public DateTime SigninDate { get; set; }
        public int UnitId { get; set; }
        public bool? Reminded { get; set; }
        public int PatientId { get; set; }
        public int SignerId { get; set; }
        public DateTime ActualDate { get; set; }

        public LogTextType LogTextType { get; set; }
        public Patient Patient { get; set; }
        public User Signer { get; set; }
        public Unit Unit { get; set; }
        public ICollection<LogTextAdditions> LogTextAdditions { get; set; }
        public ICollection<Reminder> Reminder { get; set; }
    }
}
