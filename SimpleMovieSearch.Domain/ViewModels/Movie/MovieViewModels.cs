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

        public string? Description { get; set; }

        public string? Country { get; set; }
         
        public string? MoviesCategory { get; set; }
        public byte[]? Image { get; set; }
    }
}
