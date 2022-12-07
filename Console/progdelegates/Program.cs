namespace progdelegates
{
    internal class Program
    {
        public delegate string ValidationChaine(string s);
        static void Main(string[] args)
        {
            string nom = PoserQuestionUtilisateur("Quel est votre nom ?", CheckValidationNom);
            string tel = PoserQuestionUtilisateur("Quel est votre numero de tel ?", CheckValidationTel);
            Console.WriteLine();
            Console.WriteLine("Bonjour " + nom + ", vous etes joignable au " + tel);
        }
        static string PoserQuestionUtilisateur(string message, ValidationChaine fonctionValidation = null)
        {
            Console.Write(message+ " ");
            string reponse = Console.ReadLine();
            if (fonctionValidation != null)
            {
                if (erreur != null)
                {
                    string erreur = fonctionValidation(reponse);

                    Console.WriteLine("ERREUR : " + erreur);
                    return PoserQuestionUtilisateur(message, fonctionValidation);
                }
            }
           
            return reponse;
        }

        static string CheckValidationNom(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return "Le nom ne doit pas etre vide";
            }

            if (s.Any(char.IsDigit))
            {
                return "le nom ne doit pas contenir de chiffres";
            }
            return null;
        }

        static string CheckValidationTel(string s)
        {
            if (s.Length != 10)
            {
                return "Le numero doit contenir 10 chiffres";
            }
            if (string.IsNullOrWhiteSpace(s))
            {
                return "Le numero de telephone ne doit pas etre vide";
            }

            if (!s.All (char.IsDigit))
            {
                return "le numero de telephone doit contenir uniquement des chiffres";
            }
            return null;
        }
    }
}