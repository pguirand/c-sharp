using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operations
{
    internal class Program
    {
        const int MIN = 1;
        const int MAX = 10;
        const int NB_QUEST = 5;

        static Random random = new Random();

        enum OPERATEUR
        {
            ADDITION,
            MULTIPLICATION, 
            SOUSTRACTION
        }


        private static OPERATEUR GetOperateur()
        {
            int op = random.Next(1,4);
            if (op == 1)
            {
                return OPERATEUR.ADDITION;
            }
            else if (op == 2)
            {
                return OPERATEUR.MULTIPLICATION;
            }
            return OPERATEUR.SOUSTRACTION;
        }
        private static bool DemanderOperation()
        {
            int a = random.Next(MIN, MAX);
            int b = random.Next(MIN, MAX);
            OPERATEUR operateur = GetOperateur();
            int resultatOperation = 0;
            while (true)
            {
                Console.WriteLine("Calculer l'operation Suivante : ");

                switch (operateur)
                {
                    case OPERATEUR.ADDITION:
                        {
                            Console.Write(a + " * " + b + " = ");
                            resultatOperation = a * b;
                        }
                        break;
                    case OPERATEUR.MULTIPLICATION:
                        {
                            Console.Write(a + " + " + b + " = ");
                            resultatOperation = a + b;
                        }
                        break ;
                    case OPERATEUR.SOUSTRACTION:
                        {

                            if (a < b)
                            {
                                int temp = a;
                                a = b;
                                b = temp;
                            }
                            Console.Write(a + " - " + b + " = ");
                            resultatOperation = a - b;
                        }
                        break;
                        default:
                        {
                            Console.WriteLine("Erreur. Ce cas n'est pas géré");
                            Environment.Exit(0);
                        }
                        break;

                }

                String reponse_str = Console.ReadLine();
                int reponse_num = 0;
                if (int.TryParse(reponse_str, out reponse_num))
                {
                    if (reponse_num == resultatOperation)
                    {
                        Console.WriteLine("Bonne reponse");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Mauvaise Reponse");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("ATTENTION reponse doit etre numerique.");
                }
            }
           
        }
        private static void AfficherResultat(int note)
        {
            Console.WriteLine("");
            Console.WriteLine("La note finale est : " + note + "/" + NB_QUEST);
            if (note == NB_QUEST)
            {
                Console.WriteLine("BRAVO !!!");
            }
            else if (note > 2 && note < 5)
            {
                Console.WriteLine("Pas mal !");
            }
            else if (note <= 2) 
            {
                Console.WriteLine("Peut mieux faire"); 
            }
        }
        static void Main(string[] args)
        {
            int note = 0;
            //int i = 0;
            //while (i < 5) 
            for (int i = 0;i < 5;i++)
            {
                Console.WriteLine("Question " + (i+1) + " sur " + NB_QUEST);
                if (DemanderOperation())
                {
                    note++;
                }
                //i++;
            }
            AfficherResultat(note);
          
        }
    }
}


//if (operateur == OPERATEUR.ADDITION)
//{
//    Console.Write(a + " * " + b + " = ");
//    resultatOperation = a * b;
//}
//else if (operateur == OPERATEUR.MULTIPLICATION)
//{
//    Console.Write(a + " + " + b + " = ");
//    resultatOperation = a + b;
//}
//else if (operateur == OPERATEUR.SOUSTRACTION)
//{
//    if (a < b)
//    {
//        int temp = a;
//        a = b;
//        b = temp;
//    }
//    Console.Write(a + " - " + b + " = ");
//    resultatOperation = a - b;
//}