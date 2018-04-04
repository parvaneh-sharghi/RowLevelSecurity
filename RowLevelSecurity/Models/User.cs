using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowLevelSecurity.Models
{
    public class User
    {
        public enum UserType
        {
            Admin,
            Ordinary
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public UserType Type { get; set; }
    }
}
