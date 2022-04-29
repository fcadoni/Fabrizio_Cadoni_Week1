using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negozio_Esercitazione01
{
    public class ProdTec : Prodotto
    {
        #region Properties
        public string brand { get; set; }
        public bool isNew { get; set; }

        #region Constructors
        public ProdTec()
        {

        }
        public ProdTec(int code, string description, double price, string brand, bool isNew) : base(code, description, price)
        {
            this.brand = brand;
            this.isNew = isNew;
        }
        #endregion

        #endregion
        #region Methods
        public override string SchedaProdotto()
        {
            return $"{base.SchedaProdotto}\n\tMarca: {brand}\n\tCondizioni: {NewOrUsed()}";
        }

        private string NewOrUsed()
        {
            return isNew ? "Nuovo" : "Usato";
        }
        #endregion
    }
}
