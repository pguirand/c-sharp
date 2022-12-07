using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FORMATIONCS
{
    static class outils
    {
        public static int DemanderNbPosnotNull(string question)
        {
            return DemanderNbEntre(question, 1, int.MaxValue, "ERREUR : Le nombre doit etre positif et non nul");
        }
        public static int DemanderNbEntre(string question, int min, int max, string msgerreurperso = null)
        {
            int nombre = DemanderNombre(question);
            if ((nombre >= min) && (nombre <= max))
            {
                return nombre;
            }
            if (msgerreurperso == null)
            {
                Console.WriteLine($"Nombre doit etre entre {min} et {max}");
            } else
            {
                Console.WriteLine(msgerreurperso);
            }

            return DemanderNbEntre(question, min, max, "ERREUR : Le nombre doit etre positif et non nul");

        }
        public static int DemanderNombre(string question)
        {
            while (true)
            {
                Console.Write(question);
                string reponse = Console.ReadLine();
                try
                {
                    int reponseInt = int.Parse(reponse);
                    return reponseInt;
                }
                catch
                {
                    Console.WriteLine("Vous devez rentrer un nombre");
                }
            }

        }
    }
}
