using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleMovieSearch.Domain.ViewModels.Movie
{
    public class MovieViewModels
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите имя")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше одного символа")]
        public string Name { get; set; }

        public string? Slogan { get; set; } 

        public string? Country { get; set; }
         
        public string? MoviesCategory { get; set; }
        public string? Image { get; set; }
        public string? Video { get; set; }
        public string? WorldPremiere { get; set; }
        public string? Producer { get; set; }
        public string? Director { get; set; }
        public string? Age { get; set; }
        public string? Fees { get; set; }
        public int? Time { get; set; }
    }
}
