namespace collec2
{
    internal class Program
    {
        static void AfficherListe(List<string> l)
        {
            Console.WriteLine(string.Join(", ", l));

            for (int i=0;i<l.Count;i++)
            {
                Console.WriteLine(l[i]);
            }
        }

        static void AfficherElementsCommuns(List<string> l1, List<string> l2)
        {
            var aggliste = new List<string>();
            for (int i=0; i<l1.Count;i++)
            {
                if (l2.Contains(l1[i])) {
                    aggliste.Add(l1[i]);
                }
            }
            Console.WriteLine($"Element Communs : {string.Join(", ", aggliste)}");

        }
        static void Main(string[] args)
        {
            var liste1 = new List<string>() { "Pierre", "Jude", "Martin", "Emilie" };
            List<string> liste2 = new List<string>() { "Pierre", "Sophia", "Martin", "Elsa" };

            AfficherListe(liste1);
            AfficherListe(liste2);
            AfficherElementsCommuns(liste1, liste2);
        }
    }
}