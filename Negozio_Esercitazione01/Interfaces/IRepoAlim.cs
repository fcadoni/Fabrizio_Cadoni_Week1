using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negozio_Esercitazione01.Interfaces
{
    public interface IRepoAlim : IRepository<ProdAlim>
    {
        string GetExpiring();
        string GetExpired();
        string FindByCode(int code);
    }
}
