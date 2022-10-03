using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.DAL.Interfaces
{
    public interface IBaseRepositoriy<T>
    { 
        Task Create(T entity);
        Task Delete(T entity);
        IQueryable<T> GetAll();  //это БАЗА
        Task<T> Update(T entity);

       

       
    }
}
