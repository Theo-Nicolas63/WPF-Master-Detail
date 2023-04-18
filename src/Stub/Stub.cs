using Managements;
using Modeles;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace Stub
{
    public class Stub : IPersistanceManager
    {

        /// <summary>
        /// Méthode venant de l'interface IPersistanceManager
        /// </summary>
        /// <returns>Renvoie la IEnumerable des chaines et des utilisateurs</returns>
        public (IEnumerable<Chaine> chaines, IEnumerable<Utilisateur> utilisateurs) ChargeDonnées()
        {
            List<Chaine> lesChaines = ChargeChaine(ChargeToutProgramme());
            List<Utilisateur> lesUtilisateurs = ChargeUtilisateur1();
            return (lesChaines, lesUtilisateurs);

        }

        /// <summary>
        /// Méthode venant de l'interface IPersistanceManager
        /// </summary>
        /// <param name="chaines">IEnumerable des chaines de l'application</param>
        /// <param name="utilisateurs">IEnumerable des utilisateurs de l'application</param>
        public void SauvegardeDonnées(IEnumerable<Chaine> chaines, IEnumerable<Utilisateur> utilisateurs)
        {
            Debug.WriteLine("Sauvegarde demandée");
        }


        /// <summary>
        /// Méthode permétant la création de quelques chaines
        /// </summary>
        /// <param name="programmes">Liste de programmes de chaque chaine</param>
        /// <returns>La liste de chaine pour le jeu d'essai</returns>
        public List<Chaine> ChargeChaine(ObservableCollection<Programme> programmes)
        {
            List<Chaine> chaines = new List<Chaine>();

            chaines.Add(new Chaine("TF1", "img/TF1.jpg", "https://www.tf1.fr/tf1/direct", "Télévision française 1, plus connue sous son sigle TF1, est la première et plus ancienne chaîne de télévision généraliste nationale française. Elle a été créée le 6 janvier 1975 pour succéder à la première chaîne de l'ORTF tout juste dissoute. D'abord chaîne du service public, elle est privatisée le 16 avril 1987 et fait désormais partie du groupe TF1, principalement détenu par le groupe industriel Bouygues et dont le président est Gilles Pélisson.", ChargeProgrammes1()));
            chaines.Add(new Chaine("France2", "img/France_2.png", "https://www.france.tv/france-2/direct.html", "", ChargeProgrammes2()));
            chaines.Add(new Chaine("France3", "img/France3.jpg", "https://www.france.tv/france-3/direct.html", "", ChargeProgrammes3()));
            chaines.Add(new Chaine("Canal+", "img/canal.png", "https://www.canalplus.com/live/?channel=601", "", ChargeProgrammes4()));

            return chaines;
        }

        /// <summary>
        /// Méthode permétant la création de quelques acteurs
        /// </summary>
        /// <returns>La liste d'acteur pour le jeu d'essai</returns>
        private List<Acteur> ChargeActeurs1()
        {
            List<Acteur> acteurs = new List<Acteur>();
            acteurs.AddRange(new Acteur[]
            {
                new Acteur("Álvaro Morte", "img/professor.jpg"),
                new Acteur("Miguel Herrán", "img/rio.jpg")
            });
            return acteurs;
        }

        /// <summary>
        /// Méthode appelant les 4 autres qui créent des programme pour les essais
        /// </summary>
        /// <returns>La liste de tout les programmes de toute les chaines</returns>
        private ObservableCollection<Programme> ChargeToutProgramme()
        {
            ObservableCollection<Programme> prog1 = ChargeProgrammes1();
            ObservableCollection<Programme> prog2 = ChargeProgrammes2();
            ObservableCollection<Programme> prog3 = ChargeProgrammes3();
            ObservableCollection<Programme> prog4 = ChargeProgrammes4();
            ObservableCollection<Programme> prog = new ObservableCollection<Programme>(prog1);
            foreach (Programme p in prog2)
            {
                prog.Add(p);
            }
            foreach (Programme p in prog3)
            {
                prog.Add(p);
            }
            foreach (Programme p in prog4)
            {
                prog.Add(p);
            }

            return prog;
        }

        /// <summary>
        /// Méthode permétant la création de quelques programmes
        /// </summary>
        /// <returns>La liste des programmes de la Chaine n°1(TF1)</returns>
        private ObservableCollection<Programme> ChargeProgrammes1()
        {
            ObservableCollection<Programme> prog = new ObservableCollection<Programme>();

            prog.Add(new Programme("La casa de Papel", TypeP.Série, RestrictionAge.seize, "img/La_Casa_de_Papel.webp", new System.DateTime(2020, 6, 13), new System.DateTime(2020, 6, 13, 18, 00, 00), new System.DateTime(2020, 6, 13), new System.DateTime(2020, 6, 13, 19, 00, 00), "", "", ChargeActeurs1()));
            prog.Add(new Programme("Le JT de 20h", TypeP.JT, RestrictionAge.Toutpublic, "", "", "", ChargeActeurs1()));
            prog.Add(new Programme("La Pat-Patrouille", TypeP.Jeunesse, RestrictionAge.Toutpublic, "", "", "", ChargeActeurs1()));
            prog.Add(new Programme("Grands Reportages", TypeP.Documentaire, RestrictionAge.dix, "", "", "", ChargeActeurs1()));
            prog.Add(new Programme("Koh Lanta", TypeP.Emission, RestrictionAge.Toutpublic, "", "", "", ChargeActeurs1()));

            return prog;
        }

        /// <summary>
        /// Méthode permétant la création de quelques programmes
        /// </summary>
        /// <returns>La liste des programmes de la Chaine n°2(France2)</returns>
        private ObservableCollection<Programme> ChargeProgrammes2()
        {
            ObservableCollection<Programme> prog = new ObservableCollection<Programme>();

            prog.Add(new Programme("The Walking Dead", TypeP.Série, RestrictionAge.seize, "", "", "", ChargeActeurs1()));
            prog.Add(new Programme("Journal de 20h", TypeP.JT, RestrictionAge.Toutpublic, "", "", "", ChargeActeurs1()));
            prog.Add(new Programme("N'oubliez pas les paroles", TypeP.Divertissement, RestrictionAge.Toutpublic, "", "", "", ChargeActeurs1()));
            prog.Add(new Programme("Rendez-vous en terres inconnues", TypeP.Emission, RestrictionAge.dix, "", "", "", ChargeActeurs1()));

            return prog;
        }

        /// <summary>
        /// Méthode permétant la création de quelques programmes
        /// </summary>
        /// <returns>La liste des programmes de la Chaine n°3(France3)</returns>
        private ObservableCollection<Programme> ChargeProgrammes3()
        {
            ObservableCollection<Programme> prog = new ObservableCollection<Programme>();

            prog.Add(new Programme("Plus belle la vie", TypeP.Série, RestrictionAge.dix, "", "", "", ChargeActeurs1()));
            prog.Add(new Programme("19/20", TypeP.JT, RestrictionAge.Toutpublic, "", "", "", ChargeActeurs1()));
            prog.Add(new Programme("Des chiffres & des lettres", TypeP.Divertissement, RestrictionAge.Toutpublic, "", "", "", ChargeActeurs1()));
            prog.Add(new Programme("Des racines et des ailes", TypeP.Emission, RestrictionAge.dix, "", "", "", ChargeActeurs1()));

            return prog;
        }

        /// <summary>
        /// Méthode permétant la création de quelques programmes
        /// </summary>
        /// <returns>La liste des programmes de la Chaine n°4(Canal+)</returns>
        private ObservableCollection<Programme> ChargeProgrammes4()
        {
            ObservableCollection<Programme> prog = new ObservableCollection<Programme>();

            prog.Add(new Programme("The new Pope", TypeP.Série, RestrictionAge.douze, "", "", "", ChargeActeurs1()));
            prog.Add(new Programme("WorkinGirls", TypeP.Série, RestrictionAge.douze, "", "", "", ChargeActeurs1()));
            prog.Add(new Programme("il était une fois... la Vie", TypeP.Jeunesse, RestrictionAge.Toutpublic, "", "", "", ChargeActeurs1()));

            return prog;
        }

        /// <summary>
        /// Méthode permétant la création de quelques utilisateurs
        /// </summary>
        /// <returns>La liste des utilisateurs avec deux admin et un non admin</returns>
        private List<Utilisateur> ChargeUtilisateur1()
        {
            List<Utilisateur> utilisateur = new List<Utilisateur>();
            utilisateur.AddRange(new Utilisateur[]
            {
                new Utilisateur("Petit","Jean","Jean.Petit@gmail.com","63Jp1990",new System.DateTime(1990,10,23),new ObservableCollection<Programme>(),false,"Jeanot"),
                new Utilisateur("Test","Admin","admin","admin",new System.DateTime(2000,10,10),new ObservableCollection<Programme>(),true,"Admin"),
                new Utilisateur("Tut","Max","maxtut","max", new System.DateTime(2001,6,28), new ObservableCollection<Programme>(), true, "QuechuaK")
            });
            return utilisateur;
        }
    }
}
