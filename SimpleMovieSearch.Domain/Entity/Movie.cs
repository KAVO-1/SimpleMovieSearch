﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.Domain.Entity
{
    public class Movie // Ладно виталя не лох извиняюся
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }

        public string? MoviesCategory { get; set; }

    }
}
