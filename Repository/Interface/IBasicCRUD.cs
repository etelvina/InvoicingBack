using System;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IBasicCRUD<T>
    {
        public T GetById(int pId);
        public IEnumerable<T> GetAll();
    }
}
