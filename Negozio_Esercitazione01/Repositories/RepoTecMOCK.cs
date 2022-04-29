using Negozio_Esercitazione01.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negozio_Esercitazione01.Repositories
{

    public class RepoTecMOCK : IRepoTec
    {
        private List<ProdTec> list = new List<ProdTec>();
        private string path = @"C:\Users\fcado\source\repos\Avanade_Internship\Week1\Day1\ConsoleApp1.01\Negozio_Esercitazione01\Backups\Tecnologici.txt";

        public RepoTecMOCK()
        {

        }

        public List<ProdTec> AddProduct(ProdTec product)
        {
            list.Add(product);
            return list;
        }

        public List<ProdTec> DeleteProduct(int code)
        {
            foreach (var prodTec in list)
            {
                if (prodTec.code == code)
                {
                    list.Remove(prodTec);
                    return list;
                }
            }
            Console.WriteLine("Il codice inserito non è presente nel database.");
            return list;
            
        }

        public string FindByBrand(string brand)
        {
            foreach (var prodTec in list)
            {
                if (prodTec.brand.ToLower() == brand.ToLower())
                {
                    return prodTec.SchedaProdotto + "\n";
                }
            }
            return "Il marchio inserito non è presente nel database.";
        }

        public string GetAll()
        {
            var wholeList = "";
            foreach(var prodTec in list)
            {
                wholeList += prodTec.SchedaProdotto() + "\n";
            }
            return wholeList;
        }

        public string GetNew()
        {
            var newList = "";
            foreach(var prodTec in list)
            {
                if(prodTec.isNew)
                    newList += prodTec.SchedaProdotto() + "\n";
            }
            return newList;
        }

        public List<ProdTec> UpdateProduct(ProdTec product, int code)
        {
            

            foreach (var prodTec in list)
            {
                if (prodTec.code == code)
                {
                    prodTec.price = product.price;
                    prodTec.description = product.description;
                    prodTec.isNew = product.isNew;
                    prodTec.brand = product.brand;

                    Console.WriteLine("Modifica effettuata.");
                    return list;
                }
            }
            Console.WriteLine("Il codice inserito non è presente nel database.");
            return list;
        }

        List<ProdTec> IRepository<ProdTec>.AddProduct(ProdTec product)
        {
            throw new NotImplementedException();
        }

        List<ProdTec> IRepository<ProdTec>.DeleteProduct(int code)
        {
            throw new NotImplementedException();
        }

        List<ProdTec> IRepository<ProdTec>.UpdateProduct(ProdTec product, int code)
        {
            throw new NotImplementedException();
        }
    }
}
