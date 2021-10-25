using System;
using System.Collections.Generic;

namespace DocuraeAPI.Models.Entities
{
    public partial class LogTextAdditionsType
    {
        public LogTextAdditionsType()
        {
            LogTextAdditions = new HashSet<LogTextAdditions>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<LogTextAdditions> LogTextAdditions { get; set; }
    }
}
