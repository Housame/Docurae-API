using System;
using System.Collections.Generic;

namespace DocuraeAPI.Models.Entities
{
    public partial class LogTextAdditions
    {
        public int Id { get; set; }
        public int LogTextId { get; set; }
        public int LtadditionsTypeId { get; set; }
        public string LtadditionsText { get; set; }
        public DateTime SigningsDate { get; set; }
        public int SignerId { get; set; }
        public DateTime ActualDate { get; set; }

        public LogText LogText { get; set; }
        public LogTextAdditionsType LtadditionsType { get; set; }
        public User Signer { get; set; }
    }
}
