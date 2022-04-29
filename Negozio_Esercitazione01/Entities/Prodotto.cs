using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negozio_Esercitazione01
{
    public abstract class Prodotto
    {
        #region Properties
        private static List<int> savedCodes = new List<int>();
        public int code { get; }
        public string description { get; set; }
        public double price { get; set; }
        #endregion
        #region Constructors
        public Prodotto()
        {

        }
        public Prodotto(int code, string description, double price)
        {
            this.code = CreateCode(code);
            this.description = description;
            this.price = price;
        }

        #endregion
        #region Methods
        private int CreateCode(int newCode)
        {
            var codeFound = false;
            foreach(var id in savedCodes)
            {
                codeFound = id == newCode ? true : codeFound;
            }
            if (codeFound)
            {
                do
                {
                    Console.WriteLine("Hai inserito un codice già presente in archivio, inserisci un altro codice numerico.");
                } while (int.TryParse(Console.ReadLine(), out newCode));
            }
            savedCodes.Add(newCode);
            return newCode;
        }

        public virtual string SchedaProdotto()
        {
            return $"\tCodice Prodotto: ID{code}\n\tDescrizione: {description}\n\tPrezzo: {price}€";
        }
        
        #endregion
    }
}
