Console.WriteLine("Demo Lettura e Scrittura da File");

string path = @"C:\Users\fcado\source\repos\Avanade_Internship\Week1\Day1\ConsoleApp1.01\LetturaScritturaDaFile\FileProva.txt";


StreamWriter sw = new StreamWriter(path);

sw.WriteLine("La luna non esiste");
sw.Close();

using(StreamWriter sw1 = new StreamWriter(path, true))
{
    sw1.WriteLine("è solo il retro del sole");
    sw1.Close();
}
using (StreamReader sr2 = new StreamReader(path))
{
    Console.WriteLine(sr2.ReadToEnd());

}