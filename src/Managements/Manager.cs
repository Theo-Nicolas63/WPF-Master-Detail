using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Modeles;

namespace Managements
{
    public partial class Manager : INotifyPropertyChanged
    {
        /// <summary>
        /// Dépendance vers le gestionnaire de la persistance de l'application
        /// </summary>
        public IPersistanceManager Persistance { get; set; }

        /// <summary>
        /// Liste de Chaines
        /// </summary>
        public List<Chaine> ChainesList { get; set; } = new List<Chaine>();

        /// <summary>
        /// ObservableCollection de chaine utilisée dans la vue
        /// </summary>
        private ObservableCollection<Chaine> chaines;
        public ObservableCollection<Chaine> Chaines
        {
            get { return chaines; }
            set
            {
                chaines = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Liste d'utilisateurs
        /// </summary>
        public List<Utilisateur> UtilisateursList { get; private set; } = new List<Utilisateur>();

        /// <summary>
        /// ObservableCollection d'utilisateur utilisée dans la vue
        /// </summary>
        private ObservableCollection<Utilisateur> utilisateurs;
        public ObservableCollection<Utilisateur> Utilisateurs
        {
            get { return utilisateurs; }
            set
            {
                utilisateurs = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Constructeur du manager permet de lier les données des listes dans la vue (ObservableCollection)
        /// </summary>
        /// <param name="persistance">Type de persistance choisi</param>
        public Manager(IPersistanceManager persistance)
        {
            Persistance = persistance;
            ChargeDonnées();
            Chaines = new ObservableCollection<Chaine>(ChainesList);
            Utilisateurs = new ObservableCollection<Utilisateur>(UtilisateursList);

        }

        /// <summary>
        /// Permet de charger les données dans l'application
        /// </summary>
        public void ChargeDonnées()
        {
            var données = Persistance.ChargeDonnées();
            foreach(var c in données.chaines)
            {
                ChainesList.Add(c);
            }
            foreach(var u in données.utilisateurs)
            {
                UtilisateursList.Add(u);
            }
        }

        /// <summary>
        /// Permet de sauvergarder les données dans l'application
        /// </summary>
        public void SauvergardeDonnées()
        {
            Persistance.SauvegardeDonnées(chaines, utilisateurs);
        }

        /// <summary>
        /// Permet de Rechercher un programme dans l'application en tappant siplement une partie ou tout le nom du programme
        /// ou/et en choisissant un filtre (Type du programme)
        /// </summary>
        /// <param name="recherche">Ce que l'utilisateur tape dans la barre de recherche</param>
        /// <param name="type">Type de programme selectionné si il est sélectionné</param>
        public void Recherche(string recherche, int type)
        {
            if(type == -1) {
                foreach (Chaine chaine in chaines)
                {
                    foreach (Programme prog in chaine.Lesprogrammes)
                    {
                            if (recherche.ToLower() == prog.NomP.ToLower()) // Ajouter : ToLower + ToUpper
                            {
                                if (listprogrammesVoulus.Contains(prog))
                                    continue;
                                listprogrammesVoulus.Insert(0, prog);
                            }
                            else if (prog.NomP.ToLower().Contains(recherche.ToLower()))
                            {
                                if (listprogrammesVoulus.Contains(prog))
                                    continue;
                                listprogrammesVoulus.Add(prog);
                            }
                    }
                }
            }
            TypeP Type = StringToTypeP(type);

            foreach (Chaine chaine in chaines)
            {
                foreach (Programme prog in chaine.Lesprogrammes)
                {
                    if (Type == prog.Type)
                    {
                        if (recherche.ToLower() == prog.NomP.ToLower()) // Ajouter : ToLower + ToUpper
                        {
                            if (listprogrammesVoulus.Contains(prog))
                                continue;
                            listprogrammesVoulus.Insert(0, prog);
                        }
                        else if (prog.NomP.ToLower().Contains(recherche.ToLower()))
                        {
                            if (listprogrammesVoulus.Contains(prog))
                                continue;
                            listprogrammesVoulus.Add(prog);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Programme voulu lors d'une recherche
        /// </summary>
        private string programmeVoulu;
        public string ProgrammeVoulu
        {
            get => programmeVoulu;
            set
            {
                if (programmeVoulu != value)
                {
                    programmeVoulu = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Filtre voulu lors d'une recherche
        /// </summary>
        private int filtreVoulu;
        public int FiltreVoulu
        {
            get => filtreVoulu;
            set
            {
                if (filtreVoulu != value)
                {
                    filtreVoulu = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Propriété utilisé pour créer la liste de programmes qui correspondent à la rechcherche effectuée.
        /// </summary>
        private ObservableCollection<Programme> listprogrammesVoulus = new ObservableCollection<Programme>();
        public ObservableCollection<Programme> ListprogrammesVoulus
        {
            get => listprogrammesVoulus;
            set
            {
                if (listprogrammesVoulus != value)
                {
                    listprogrammesVoulus = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Permet de passer faire "visible" les UC correspondant à l'élément sélectionné dans la list box "recherche"
        /// </summary>
        private Programme rechercheSélectionné;
        public Programme RechercheSélectionné
        {
            get => rechercheSélectionné;
            set
            {
                if (rechercheSélectionné != value)
                {
                    rechercheSélectionné = value;
                    ProgrammeSélectionné = rechercheSélectionné;
                    ChaineSélectionné = RechercherProginChaines(rechercheSélectionné);

                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Permet de trouver à quel chaine appartient un programme donné
        /// </summary>
        /// <param name="prog">Le programme pour lequel on cherche sa chaine parente</param>
        /// <returns> Retourne la chaine qui contient le programme donné</returns>
        public Chaine RechercherProginChaines(Programme prog)
        {
            foreach (Chaine c in Chaines)
            {
                if (c.Lesprogrammes.Contains(prog))
                {
                    return c;
                }
            }
            return null;
        }
    }
}
