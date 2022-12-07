using System.Security.Cryptography.X509Certificates;

namespace programme_POO1
{
    internal class Program
    {
        class TableMultiplication : IAffichable
        {
            int numero;

            public TableMultiplication(int numero)
            {
                this.numero = numero;
            }

            public void AfficherInfos()
            {
                Console.WriteLine("Table de Multiplication de " + this.numero);

                for (int i = 1;i <11;i++)
                {
                    Console.WriteLine(i + " x " + this.numero + " = " + i * this.numero);
                }
            }
        }

        interface IAffichable
        {
            void AfficherInfos();
        }

        class Enfant : Etudiant
        {
            string ClassEcole;
            Dictionary<string, float> notes;
            public Enfant(string nom, int age, string ClassEcole, Dictionary<string, float> notes) : base(nom, age, null)
            {
                this.ClassEcole = ClassEcole;
                this.notes = notes;
            }

            public override void AfficherInfos()
            {
                AfficherNometAge();
                Console.WriteLine("Enfant en classe de : " + this.ClassEcole);
                if((notes != null)&&(notes.Count>0))
                {
                    Console.WriteLine("      Notes : ");
                    foreach (var note in notes)
                    {
                        Console.WriteLine("      " + note.Key + "  :  " + note.Value + "  / 10");
                    }
                }
              

                AfficherProfPrinc();

            }
        }
        class Etudiant : Personne
        {
            string InfoEtudes;
            public Personne ProfPrincipal;
            public Etudiant(string nom, int age, string InfoEtudes) : base(nom, age)
            {
                this.InfoEtudes = InfoEtudes;
            }

            protected void AfficherProfPrinc()
            {
                if (ProfPrincipal != null)
                {
                    Console.WriteLine("Professeur Principal est : ");
                    ProfPrincipal.AfficherInfos();
                }
            }
            public override void AfficherInfos()
            {
                AfficherNometAge();               
                Console.WriteLine("Etudiant en : " + InfoEtudes);
                AfficherProfPrinc();
                Console.WriteLine();
            }

        }
        

        class Personne : IAffichable
        {

            static int NbPersonnes = 0;
            public string nom;
            public int age { get; init; }
            string emploi;
            protected int NumeroPersonne;


            //public Personne(string nom, int age) : this(nom, age, "(non specifie)")
            //{

            //}

            public Personne (string nom, int age, string emploi = null)
            {
                this.nom = nom;
                this.age = age;
                this.emploi = emploi;

                NbPersonnes++;

                this.NumeroPersonne = NbPersonnes;
            }
            protected void AfficherNometAge()
            {
                Console.WriteLine("No : " + this.NumeroPersonne);
                Console.WriteLine("Nom : " + this.nom);
                Console.WriteLine("Age : " + this.age);
            }

            public virtual void AfficherInfos()
            {
                AfficherNometAge();
                if (emploi != null)
                {
                    Console.WriteLine("Emploi : " + this.emploi);

                } else
                {
                    Console.WriteLine("Aucun emploie specifie");
                }
                Console.WriteLine();

            }
        }

        static void Main(string[] args)
        {
            //var ListPers = new List<Personne>();
            var ListPers = new List<IAffichable>();
            ListPers.Add(new Personne("Mike", 35, "Programmeur"));
            ListPers.Add(new Personne("Nathalie", 28, "Secretaire"));
            ListPers.Add(new Etudiant("Jonas", 17, "Plombier"));
            ListPers.Add(new Enfant("Smith", 7, "CP", null));
            ListPers.Add(new Personne("Neo", 27, "Architecte"));
            ListPers.Add(new TableMultiplication(6));


            //ListPers = ListPers.OrderBy(p => p.nom).ToList();
            //ListPers = ListPers.Where(p => p.age >= 35).ToList();
            //ListPers = ListPers.Where(p => p is Etudiant).ToList();
            //ListPers = ListPers.Where(p => (p.nom[0] == 'N')&&(p.age>=28)).ToList();

            foreach (var employee in ListPers)
            {
                employee.AfficherInfos();
            }

            //var table = new TableMultiplication(6);
            //table.AfficherInfos();

            //var person1 = new Personne("Mike", 25, "Programmeur");
            //person1.AfficherInfos();
            //var prof = new Personne("Emma", 32, "Professeur");
            //var prof2 = new Personne("John", 30, "Professeur");
            //prof.AfficherInfos();
            //var etudiant = new Etudiant("David", 15, "Cyber Security"/*, prof*/);
            //etudiant.ProfPrincipal = prof;
            //etudiant.AfficherInfos();

            //var notes1 = new Dictionary<string, float> { { "Maths", 5f }, { "Geo", 8.5f }, { "Dictee",6f } };
            //var enfant = new Enfant("Samuel", 8, "CM2", notes1) /*{ ProfPrincipal = prof2}*/;
            ////enfant.ProfPrincipal = prof;
            //enfant.AfficherInfos();
        }
    }
}