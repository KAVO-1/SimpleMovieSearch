using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMovieSearch.DAL.Interfaces
{
    public interface IbaseRepositoriy<T>
    {
        Task<bool> Create(T entity);

        Task<bool> Delete(T entity);

        Task<T> Get(int id);

        Task<List<T>> Select();
        Task<T> Update(T entity);

        IQueryable<T> GetAll();  //это БАЗА
    }
}
