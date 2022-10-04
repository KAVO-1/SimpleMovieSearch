using SimpleMovieSearch.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
        public StatusName StatusName { get; set; }
        public T Data { get; set; } //Результат запроса (пример получаем коллекцию элементов объекта из БД и записываем их в Data)
    }

    public interface IBaseResponse<T>
    {
        string Description { get;}
        StatusName StatusName { get; }
        T Data { get; }
    }
}
