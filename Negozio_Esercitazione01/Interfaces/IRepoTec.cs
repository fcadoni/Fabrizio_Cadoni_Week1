using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negozio_Esercitazione01.Interfaces
{
    public interface IRepoTec : IRepository<ProdTec>
    {
        string GetNew();
        string FindByBrand(string brand);
    }
}
