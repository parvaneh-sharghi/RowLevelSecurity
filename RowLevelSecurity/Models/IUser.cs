using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowLevelSecurity.Models
{
    public interface IUser
    {
        int UserId { get; set; }
        User User { get; set; }
    }
}
