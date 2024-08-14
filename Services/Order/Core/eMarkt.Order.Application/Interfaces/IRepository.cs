using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eMarkt.Order.Application.Interfaces
{
    //Dışardan bi T değeri alacak.Ve değeri class olmalı
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        //T giriş değeri, bool çıkış değeri
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
