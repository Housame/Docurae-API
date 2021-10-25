using System;
using System.Collections.Generic;

namespace DocuraeAPI.Models.Entities
{
    public partial class Reminder
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int LogTextId { get; set; }
        public int UnitId { get; set; }
        public int SignerId { get; set; }

        public LogText LogText { get; set; }
        public User Signer { get; set; }
    }
}
