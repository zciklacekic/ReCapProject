using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEntityService<T>
    {
        List<T> GetAll();
        T GetById(int Id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
