using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUpdateCRUD<T>
    {
        public void Update(T Entity);
    }
}
