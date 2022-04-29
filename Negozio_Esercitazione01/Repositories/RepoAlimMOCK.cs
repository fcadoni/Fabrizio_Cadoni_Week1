using Negozio_Esercitazione01.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negozio_Esercitazione01.Repositories
{
    public class RepoAlimMOCK : IRepoAlim
    {
        private string path = @"C:\Users\fcado\source\repos\Avanade_Internship\Week1\Day1\ConsoleApp1.01\Negozio_Esercitazione01\Backups\Alimentari.txt";
        private static List<ProdAlim> list = new List<ProdAlim>();
        public List<ProdAlim> AddProduct(ProdAlim product)
        {
            list.Add(product);
            return list;
        }

        

        public List<ProdAlim> DeleteProduct(int code)
        {
            foreach (var prodAlim in list)
            {
                if (prodAlim.code == code)
                {
                    list.Remove(prodAlim);
                    return list;
                }
            }
            Console.WriteLine("Il codice inserito non è presente nel database.");
            return list;

        }

        public string FindByCode(int code)
        {
            foreach(var prodAlim in list)
            {
                if (prodAlim.code == code)
                    return prodAlim.SchedaProdotto() + "\n";
            }
            return "Il codice inserito non è presente nel database\n";
        }

        public string GetAll()
        {
            var wholeList = "";
            foreach (var prodAlim in list)
            {
                wholeList += prodAlim.SchedaProdotto() + "\n";
            }
            return wholeList;
        }

        public string GetExpired()
        {
            var resultList = "";
            foreach (var prodAlim in list)
            {
                if(prodAlim.edibilityTime == 0)
                    resultList += prodAlim.SchedaProdotto() + "\n";
            }
            return resultList;
        }

        public string GetExpiring()
        {
            var resultList = "";
            foreach (var prodAlim in list)
            {
                if (prodAlim.edibilityTime >= 0 && prodAlim.edibilityTime <= 3)
                    resultList += prodAlim.SchedaProdotto() + "\n";
            }
            return resultList;
        }

        public List<ProdAlim> UpdateProduct(ProdAlim product, int code)
        {


            foreach (var prodAlim in list)
            {
                if (prodAlim.code == code)
                {
                    prodAlim.price = product.price;
                    prodAlim.description = product.description;
                    prodAlim.amount = product.amount;
                    prodAlim.expiration = product.expiration;
                    prodAlim.edibilityTime = product.edibilityTime;

                    Console.WriteLine("Modifica effettuata.");
                    return list;
                }
            }
            Console.WriteLine("Il codice inserito non è presente nel database.");
            return list;
        }

        

        
    }
}
