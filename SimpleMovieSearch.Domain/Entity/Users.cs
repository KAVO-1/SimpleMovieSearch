using SimpleMovieSearch.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.Domain.Entity
{
    public class Users 
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
