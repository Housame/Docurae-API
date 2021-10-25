using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocuraeAPI.Models
{
    public class LogInDTO
    {
            [Required]
            public string UserName { get; set; }
            [Required]
            public string Password { get; set; }
    }
    public class RefreshDTO
    {
        [Required]
        public string UserName { get; set; }
    }
}
