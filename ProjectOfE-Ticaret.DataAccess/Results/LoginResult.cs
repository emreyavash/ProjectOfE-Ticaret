using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectOfE_Ticaret.DataAccess.DTOs;
using ProjectOfE_Ticaret.DataAccess.Entity;

namespace ProjectOfE_Ticaret.DataAccess.Results
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public UserDTO User { get; set; }
    }
}
