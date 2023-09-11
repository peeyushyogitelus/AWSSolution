using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSMavenPages.Models
{
    public class LogInUserDetails
    {
        public string AccessToken { get; set; }
        public string MLUser { get; set; }
        public string MLAccount { get; set; }
        public string MLUserEmail { get; set; }
        public string MLUserId { get; set; }
        public string MLPermissions { get; set; }
    }
}
