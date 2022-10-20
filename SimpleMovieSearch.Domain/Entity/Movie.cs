using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.Domain.Entity
{
    public class Movie 
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Slogan { get; set; } 
        public string? Country { get; set; }
        public string? MoviesCategory { get; set; } //////DB//////
        public string? Image { get; set; }
        public string? Video { get; set; } 
        public string? WorldPremiere { get; set; } 
        public string? Producer { get; set; } 
        public string? Age { get; set; } 
        public string? Director { get; set; } 
        public string? Fees { get; set; } 
        public int? Time { get; set; } 

    }
}
