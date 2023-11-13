using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography;
namespace WpfAppAuthentication
{
    public class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Password { get; internal set; }
    }
}
