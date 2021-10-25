using System;
using System.Collections.Generic;

namespace DocuraeAPI.Models.Entities
{
    public partial class Individual
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public int? PermanentSectionId { get; set; }
        public int UserId { get; set; }

        public Unit Unit { get; set; }
        public User User { get; set; }
    }
}
