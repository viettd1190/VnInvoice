using System;

namespace vnyi.HaLinh.Models
{
    public class UserToken
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string DomainName { get; set; }

        public string Token { get; set; }

        public DateTime ExpiredOn { get; set; }

        public int ValidFor { get; set; }
    }
}
