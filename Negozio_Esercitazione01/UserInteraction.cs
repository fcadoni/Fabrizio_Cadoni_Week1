using Negozio_Esercitazione01.Interfaces;
using Negozio_Esercitazione01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negozio_Esercitazione01
{
    public static class UserInteraction
    {
        public static void Start()
        {
            var isOn = true;
            while (isOn)
            {
                switch (Menu())
                {
                    case 0:
                        isOn = false;
                        break;
                    case 1:
                        Visualizza();
                        break;
                    case 2:
                        //AggiungiProdotto();
                        break;
                    case 3:
                        Cerca();
                        break;
                    default:
                        Console.WriteLine("Hai inserito una scelta non valida");
                        break;
                }
            }
        }

        private static int Menu()
        {
            int result;
            do
            {
                Console.WriteLine("Cosa vuoi fare?");
                Console.WriteLine("1. Visualizza prodotti");
                Console.WriteLine("2. Aggiungi un prodotto");
                Console.WriteLine("3. Effettua una ricerca");
                Console.WriteLine("\n0. Esci");

            } while (int.TryParse(Console.ReadLine(), out result) && result > 0 && result < 4);
            return result;
        }
        private static void Cerca()
        {
            IRepoAlim repoAlim = new RepoAlimMOCK();
            IRepoTec repoTec = new RepoTecMOCK();
            var isOn = true;
            while (isOn)
            {
                switch (CercaMenu())
                {
                    case 0:
                        // INDIETRO
                        isOn = false;
                        break;
                    case 1:
                        // CERCA PRODOTTO ALIMENTARE PER CODICE
                        int code;
                        while (int.TryParse(Console.ReadLine(), out code))
                        {
                            Console.WriteLine("Inserisci il codice del prodotto alimentare che vuoi trovare:");
                        };
                        Console.WriteLine(repoAlim.FindByCode(code));
                        Console.WriteLine("\nPremi Invio per tornare al MENU RICERCA");
                        Console.ReadLine();
                        break;
                    case 2:
                        // CERCA PRODOTTO TECNOLOGICO PER MARCA
                        
                        Console.WriteLine("Inserisci il marchio del prodotto tecnologico che vuoi trovare:");
                        string brand = Console.ReadLine();
                        Console.WriteLine(repoTec.FindByBrand(brand));
                        Console.WriteLine("\nPremi Invio per tornare al MENU RICERCA");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Hai effettuato una scelta non valida");
                        Console.WriteLine("\nPremi Invio per tornare al MENU RICERCA");
                        Console.ReadLine();
                        break;
                }
            }
        }
        private static int CercaMenu()
        {
            while (int.TryParse(Console.ReadLine(), out int result) && result >= 0 && result < 3)
            {
                Console.WriteLine("MENU CERCA\n\nChe tipo di ricerca vuoi effettuare?");
                Console.WriteLine("1. Cerca un prodotto alimentare per codice");
                Console.WriteLine("2. Cerca un prodotto tecnologico per marca");
                Console.WriteLine("\n0. Indietro");
                return result;
            }
            return -1;
        }
        private static void Visualizza()
        {
            IRepoAlim repoAlim = new RepoAlimMOCK();
            IRepoTec repoTec = new RepoTecMOCK();
            var isOn = true;
            while (isOn)
            {
                switch (VisualizzaMenu())
                {
                    case 0:
                        // INDIETRO
                        isOn = false;
                        break;
                    case 1:
                        // MOSTRA TUTTI I PRODOTTI
                        Console.WriteLine(repoAlim.GetAll() + repoTec.GetAll());
                        Console.WriteLine("\nPremi Invio per tornare al MENU VISUALIZZAZIONE");
                        Console.ReadLine();
                        break;
                    case 2:
                        // MOSTRA TUTTI I PRODOTTI ALIMENTARI
                        Console.WriteLine(repoAlim.GetAll());
                        Console.WriteLine("\nPremi Invio per tornare al MENU VISUALIZZAZIONE");
                        Console.ReadLine();
                        break;
                    case 3:
                        // MOSTRA TUTTI I PRODOTTI TECNOLOGICI
                        Console.WriteLine(repoTec.GetAll());
                        Console.WriteLine("\nPremi Invio per tornare al MENU VISUALIZZAZIONE");
                        Console.ReadLine();
                        break;
                    case 4:
                        // MOSTRA TUTTI I PRODOTTI TECNOLOGICI NUOVI
                        Console.WriteLine(repoTec.GetNew());
                        Console.WriteLine("\nPremi Invio per tornare al MENU VISUALIZZAZIONE");
                        Console.ReadLine();
                        break;
                        break;
                    case 5:
                        // MOSTRA TUTTI I PRODOTTI ALIMENTARI IN SCADENZA OGGI
                        Console.WriteLine(repoAlim.GetExpired());
                        Console.WriteLine("\nPremi Invio per tornare al MENU VISUALIZZAZIONE");
                        Console.ReadLine();
                        break;
                    case 6:
                        //GetExpiring()
                        // MOSTRA TUTTI I PRODOTTI ALIMENTARI IN SCADENZA ENTRO 3 GIORNI
                        Console.WriteLine(repoAlim.GetExpiring());
                        Console.WriteLine("\nPremi Invio per tornare al MENU VISUALIZZAZIONE");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Hai effettuato una scelta non valida");
                        Console.WriteLine("\nPremi Invio per tornare al MENU VISUALIZZAZIONE");
                        Console.ReadLine();
                        break;

                }
            }
        }
        private static int VisualizzaMenu()
        {
            while (int.TryParse(Console.ReadLine(), out int result) && result >= 0 && result <= 6)
            {
                Console.WriteLine("MENU VISUALIZZAZIONE\n\nChe cosa vuoi visualizzare?");
                Console.WriteLine("1. Tutti i prodotti");
                Console.WriteLine("2. I prodotti alimentari");
                Console.WriteLine("3. I prodotti tecnologici");
                Console.WriteLine("4. I prodotti tecnologici nuovi");
                Console.WriteLine("5. I prodotti alimentari in scadenza oggi");
                Console.WriteLine("6. I prodotti alimentari che scadono tra meno di 3 giorni");
                Console.WriteLine("\n0. Indietro");
                return result;
            }
            return -1;
        }
        private static void Add()
        {
            IRepoAlim repoAlim = new RepoAlimMOCK();
            IRepoTec repoTec = new RepoTecMOCK();
            var isOn = true;
            while (isOn)
            {
                switch (VisualizzaMenu())
                {
                    case 0:
                        // INDIETRO
                        isOn = false;
                        break;
                    case 1:
                        // AGGIUNGI UN PRODOTTO ALIMENTARE
                        double priceA;
                        int codeA, amountA, yyyyA, mmA, ddA;
                        while (int.TryParse(Console.ReadLine(), out codeA))
                        {
                            Console.WriteLine("Codice: ");
                        }
                        Console.WriteLine("Descrizione: ");
                        var descriptionA = Console.ReadLine();
                        while (double.TryParse(Console.ReadLine(), out priceA))
                        {
                            Console.WriteLine("Prezzo: ");
                        }
                        while (int.TryParse(Console.ReadLine(), out amountA))
                        {
                            Console.WriteLine("Quantità: ");
                        }
                        while (int.TryParse(Console.ReadLine(), out yyyyA))
                        {
                            Console.WriteLine("Anno di scadenza: ");
                        }
                        while (int.TryParse(Console.ReadLine(), out mmA))
                        {
                            Console.WriteLine("Mese di scadenza: ");
                        }
                        while (int.TryParse(Console.ReadLine(), out ddA))
                        {
                            Console.WriteLine("Giorno di scadenza: ");
                        }
                        repoAlim.AddProduct(new ProdAlim(codeA, descriptionA, priceA, ddA, mmA, yyyyA));
                        Console.WriteLine("Prodotto alimentare aggiunto correttamente");
                        Console.WriteLine();
                        break;
                    case 2:
                        // AGGIUNGI UN PRODOTTO TECNOLOGICO
                        double priceT;
                        int codeT;
                        
                        while (int.TryParse(Console.ReadLine(), out codeT))
                        {
                            Console.WriteLine("Codice: ");
                        }
                        Console.WriteLine("Descrizione: ");
                        var descriptionT = Console.ReadLine();
                        while (double.TryParse(Console.ReadLine(), out priceT))
                        {
                            Console.WriteLine("Prezzo: ");
                        }
                        Console.WriteLine("Marca: ");
                        var brand = Console.ReadLine();
                        
                        var conditions = "";
                        Console.WriteLine("Condizioni (nuovo o usato): ");
                        while(!(conditions.ToLower() == "nuovo" || conditions.ToLower() == "usato"))
                        {
                            conditions = Console.ReadLine();
                        }
                        
                        repoTec.AddProduct(new ProdTec(codeT, descriptionT, priceT, brand, conditions == "Nuovo"));
                        Console.WriteLine("Prodotto tecnologico aggiunto correttamente");
                        Console.WriteLine();
                        break;
                        
                    default:
                        break;
                }
            }
        }
        private static int AddMenu()
        {
            while (int.TryParse(Console.ReadLine(), out int result) && result >= 0 && result < 3)
            {
                Console.WriteLine("MENU AGGIUNGI\n\nChe cosa vuoi aggiungere al catalogo?");
                Console.WriteLine("1. Un prodotto alimentare");
                Console.WriteLine("2. Un prodotto tecnologico");
                Console.WriteLine("\n0. Indietro");
                return result;
            }
            return -1;
        }
    }
}
