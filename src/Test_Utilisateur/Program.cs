using System;
using System.Collections.ObjectModel;
using Modeles;
using static System.Console;

namespace Test_Utilisateur
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Test de la classe Utilisateur : \n");
            var u1 = new Utilisateur("Fenouil", "Jean", "jean.fenouil@gmail.com", "jf1992", new DateTime(1992, 06, 12), new ObservableCollection<Programme>(), false, "Jeanouil");
            var u2 = new Utilisateur("Poul", "Monique", "monique.poul@gmail.com", "mp1976", new DateTime(1976, 11, 03), new ObservableCollection<Programme>(), false, "Monoul");
            var u3 = new Utilisateur("Stiti", "Robert", "robert.stiti@gmail.com", "rs2001", new DateTime(2001, 05, 04), new ObservableCollection<Programme>(), false, "RoroSti");
            var u4 = new Utilisateur("Tureck", "Maxime", "maxime.tureck@gmail.com", "mt2001", new DateTime(2001, 06, 28), new ObservableCollection<Programme>(), false, "QuechuaK");

            WriteLine(u1 + "\n");
            WriteLine(u2 + "\n");
            WriteLine(u3 + "\n");
            WriteLine(u1.AfficherAge(u1.DateDeNaissance));
            WriteLine(DateTime.Now);

            WriteLine(u1);
            WriteLine(u1.AfficherAge(u1.DateDeNaissance) + "\n");
            WriteLine(u2);
            WriteLine(u2.AfficherAge(u2.DateDeNaissance) + "\n");
            WriteLine(u3);
            WriteLine(u3.AfficherAge(u3.DateDeNaissance) + "\n");
            WriteLine(u4);
            WriteLine(u4.AfficherAge(u4.DateDeNaissance) + "\n");

            WriteLine(DateTime.Now);
        }
    }
}
