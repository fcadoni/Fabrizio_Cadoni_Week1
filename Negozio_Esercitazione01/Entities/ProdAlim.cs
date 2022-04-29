using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negozio_Esercitazione01
{
    public class ProdAlim : Prodotto
    {
        #region Properties
        public int amount { get; set; }
        public DateTime expiration { get; set; }
        public int edibilityTime { get; set; }
        #endregion
        #region Constructors
        public ProdAlim()
        {

        }
        public ProdAlim(int code, string description, double price, int dd, int mm, int yyyy) : base(code,description, price)
        {
            this.amount = amount;
            this.expiration = new DateTime(yyyy, mm, dd);
            this.edibilityTime = EdibilityTime();
        }
        #endregion
        #region Methods
        private int EdibilityTime()
        {
            TimeSpan ts = expiration - DateTime.UtcNow;

            return ts.Days;

        }
        public override string SchedaProdotto()
        {
            return $"{base.SchedaProdotto}\n\tQuantita': {amount}\n\tScadenza: {expiration.Date} - {EdibilityTime()} giorni rimasti\n";

        }

        #endregion
    }
}
