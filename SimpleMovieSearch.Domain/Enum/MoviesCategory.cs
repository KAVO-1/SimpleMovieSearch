using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleMovieSearch.Domain.Enum
{
    public enum MoviesCategory
    {
        [Display(Name = "Исторический")]
        Historical = 0,
        [Display(Name = "Триллер")]
        Thriller = 1,
        [Display(Name = "Фантастика")]
        Fantasty = 2,
        [Display(Name = "Комедия")]
        Comedy = 3,
        [Display(Name = "Ужасы")]
        Horror = 4,
    }
}
