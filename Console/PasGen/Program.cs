using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FORMATIONCS;

namespace PasGen
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            const int NB_PASS = 10;

            const string letters = "ABCDabcd";
            char a = letters[2];
            int c = 70;
            Console.WriteLine((char)45);
            Console.WriteLine(a);
            Console.WriteLine((char)c);
            string chartest = "";
            for (int numerochar = 65; numerochar <65+26;numerochar++)
            {
                chartest += (char)numerochar;
                //Console.Write((char)numerochar);
            }
            Console.WriteLine(chartest);
            //return;
            int passlen = outils.DemanderNbPosnotNull("Longueur du mot de passe : ");
            Console.WriteLine();
            int choixAlphabet = outils.DemanderNbEntre("Vous voulez un mot de passe avec :\n" +
                "1 - Uniquement caracteres minuscules\n" +
                "2 - Caracteres minuscules et majuscules\n" +
                "3 - Caracteres et des chiffres\n" +
                "4 - Caracteres, chiffres et caracteres speciaux\n\n", 1, 4);
            Console.WriteLine("");


            string minuscules = "abcdefghijklmnopqrstuvwxyz";
            string majuscules = minuscules.ToUpper();
            string chiffres = "0123456789";
            string specialchar = "!@#$%&*";
            string alphabet;

            if (choixAlphabet == 1)
                alphabet = minuscules;
            else if (choixAlphabet == 2)
                alphabet = minuscules + majuscules;
            else if (choixAlphabet == 3)
                alphabet = minuscules + majuscules + chiffres;
            else
                alphabet = minuscules + majuscules + chiffres + specialchar;

            int l = alphabet.Length;

            Random rand = new Random();
            

            string motdep = "";
            for (int j=0;j<NB_PASS;j++)
            {
                motdep = "";
                for (int i = 0; i < passlen; i++)
                {
                    int index = rand.Next(0, l);
                    motdep += alphabet[index];
                }
                Console.WriteLine("Mot de Passe : "+motdep);
            }
         
        }
    }
}