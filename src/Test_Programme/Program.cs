using Modeles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static System.Console;

namespace Test
{
    class Test_Programme
    {
        static void Main(string[] args)
        {
            WriteLine("Test de la classe Programme : \n");
            var u1 = new Utilisateur("Fenouil", "Jean", "jean.fenouil@gmail.com", "jf1992", new DateTime(1992, 06, 12), new ObservableCollection<Programme>(), false, "Jeanouil");

            List<Acteur> acteurs = new List<Acteur>();
            acteurs.AddRange(new Acteur[]
            {
                new Acteur("Álvaro Morte", "img/professor.jpg"),
                new Acteur("Miguel Herrán", "img/rio.jpg")
            });

            var p1 = new Programme("La casa de Papel", TypeP.Série, RestrictionAge.seize, "img/La_Casa_de_Papel.webp", new System.DateTime(2020, 6, 13), new System.DateTime(2020, 6, 13, 18, 00, 00), new System.DateTime(2020, 6, 13), new System.DateTime(2020, 6, 13, 19, 00, 00), "", "Ici la description de la casa de papel", acteurs);


            WriteLine(p1.HorraireD.Minute - p1.HorraireF.Minute);

            WriteLine(p1 + "\n");
            WriteLine(p1.HorraireF.Hour + "h" + p1.HorraireF.Minute);
            WriteLine(u1);
            WriteLine(u1.AfficherAge(u1.DateDeNaissance) + "\n");
            WriteLine(p1.VerifAge(u1, p1.AgeMinimal));


        }
    }
}