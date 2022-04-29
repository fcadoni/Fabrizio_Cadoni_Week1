using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negozio_Esercitazione01.Interfaces
{
    public interface IRepository<T>
    {
        List<T> AddProduct(T product);
        string GetAll();
        List<T> UpdateProduct(T product, int code);
        List<T> DeleteProduct(int code);
    }
}
