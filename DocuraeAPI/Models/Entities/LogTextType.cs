using System;
using System.Collections.Generic;

namespace DocuraeAPI.Models.Entities
{
    public partial class LogTextType
    {
        public LogTextType()
        {
            LogText = new HashSet<LogText>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string InfoText { get; set; }
        public bool Enabled { get; set; }

        public ICollection<LogText> LogText { get; set; }
    }
}
