using AsciiArt;
using System.ComponentModel.DataAnnotations;

namespace pendu
{
    internal class Program
    {

        static void AfficherMot(string mot, List<char> lettres)
        {
            int wordlen = mot.Length;
            for (int i=0;i<wordlen;i++)
            {
                char lettre = mot[i];
                if (lettres.Contains(lettre))
                {
                    Console.Write($"{lettre} ");
                } else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine("\n");
        }

        static char DemanderUneLettre()
        {
            Console.Write("Rentrer une lettre : ");
            string reponse = Console.ReadLine();
            if (reponse.Length == 1)
            {
                reponse = reponse.ToUpper();
                Console.WriteLine("Vous avez rentre : " + reponse);
                return reponse[0];
            }
            Console.WriteLine("ERREUR : Vous devez rentrer une lettre");
            return DemanderUneLettre();
        }

        static void DevinerMot(string mot)
        {
            var LettresDevinees = new List<char>();
            var LettresIncorrectes = new List<char>();
            const int NB_VIES = 6;
            int viesRestantes = NB_VIES;

            while (viesRestantes>0)
            {
                Console.WriteLine(Ascii.PENDU[NB_VIES-viesRestantes]);
                Console.WriteLine();

                AfficherMot(mot, LettresDevinees);
                var lettre = DemanderUneLettre();
                Console.Clear();
                if (mot.Contains(lettre))
                {
                    Console.WriteLine("Cette lettre est dans le mot");
                    LettresDevinees.Add(lettre);
                    if (ToutesLettresDevinees(mot, LettresDevinees))
                    {
                        Console.WriteLine();
                        AfficherMot(mot, LettresDevinees);
                        Console.WriteLine();
                        Console.WriteLine("GAGNE !!!");

                        return;
                    }
                } else
                {
                    if (!LettresIncorrectes.Contains(lettre))
                    {
                        LettresIncorrectes.Add(lettre);
                        viesRestantes--;
                    }
                    
                }
                if (LettresIncorrectes.Count > 0)
                {
                    Console.WriteLine("Ce mot ne contient pas les lettres : " + String.Join(", ", LettresIncorrectes));
                }

                Console.WriteLine($"NB de vies restantes : {viesRestantes}");
                Console.WriteLine();
            }
            if (viesRestantes == 0)
            {
                Console.WriteLine(Ascii.PENDU[NB_VIES - viesRestantes]);
                Console.WriteLine();
                Console.WriteLine("PERDU !");
                Console.WriteLine($"le mot etait : {mot}");
            }

        }

        static bool ToutesLettresDevinees(string mot, List<char> lettres)
        {
            foreach (var lettre in lettres)
            {
                mot = mot.Replace(lettre.ToString(), "");
            }
            if (mot.Length == 0)
            {
                return true;
            }
            return false;
        }

        static string[] ChargerLesMots(string nomfile)
        {
            try
            {
                return File.ReadAllLines(nomfile);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erreur Lecture fichier " + ex.Message);
            }
            return null;
        }
        static void Main(string[] args)
        {
            var mots = ChargerLesMots("mots.txt");

            if ((mots == null) || (mots.Length ==0))
            {
                Console.WriteLine("Liste mots est vide.");
            }
            else
            {
                int len = mots.Length;
                var r = new Random();
                
                string texte = mots[r.Next(len)].Trim().ToUpper();
                Console.WriteLine(texte);
                DevinerMot(texte);

                Console.Write("Voulez-vous rejouer (o/n) ?");
            }
            //char lettre = DemanderUneLettre();
            //AfficherMot(texte, new List<char> { lettre });
            //Console.WriteLine(ToutesLettresDevinees(texte, new List<char> { 'D', 'E', 'C' }));

        }
    }
}