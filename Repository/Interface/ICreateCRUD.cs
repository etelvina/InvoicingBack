using System;

namespace Repository.Interface
{
    public interface ICreateCRUD<T>
    {
        public void Create(T Entity);
    }
}
