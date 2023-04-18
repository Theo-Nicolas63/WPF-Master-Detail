using Modeles;
using System;

namespace Managements
{
    public partial class Manager
    {
        /// <summary>
        /// Permet de sélectionner un programme dans la vue
        /// </summary>
        private Programme programmeSélectionné;
        public Programme ProgrammeSélectionné
        {
            get => programmeSélectionné;
            set
            {
                if (ProgrammeSélectionné != value)
                {
                    programmeSélectionné = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Permet de convertir un string reçu en TypeP
        /// </summary>
        /// <param name="type">Index du type du programme</param>
        /// <returns>Le TypeP correspondant</returns>
        public TypeP StringToTypeP(int type)
        {

            
            if (type == 0)
                return TypeP.Documentaire;
            if (type == 1)
                return TypeP.Film;
            if (type == 2)
                return TypeP.Emission;
            if (type == 3)
                return TypeP.Jeunesse;
            if (type == 4)
                return TypeP.Divertissement;
            if (type == 5)
                return TypeP.Sport;
            if (type == 6)
                return TypeP.JT;
            return TypeP.Série;

        }

        /// <summary>
        /// Permet de convertir in int en RestrictionAge
        /// </summary>
        /// <param name="age">Index du restrictionage du programme</param>
        /// <returns>La RestrictionAge correspondante</returns>
        public RestrictionAge StringToRestrictionAge(int age)
        {
            if (age == 0)
                return RestrictionAge.Toutpublic;
            else if (age == 1)
                return RestrictionAge.dix;
            else if (age == 2)
                return RestrictionAge.douze;
            else if (age == 3)
                return RestrictionAge.seize;
            else
                return RestrictionAge.dix_huit;
        }

        /// <summary>
        /// Permet d'ajouter un programme à un chaîne
        /// </summary>
        /// <param name="programme">Programme à ajouter</param>
        /// <param name="chaine">Chaine dans laquelle le programme sera ajouté</param>
        /// <returns>true si correctement ajoutée, false si non</returns>
        public bool AjouterProgramme(Programme programme, Chaine chaine)
        {
            if (chaine.Lesprogrammes.Contains(programme))
               {
                  return false;
               }
            if (programme.NomP == null || string.IsNullOrWhiteSpace(programme.NomP) || programme.ImgPathP == null || string.IsNullOrWhiteSpace(programme.ImgPathP))
            {
                throw new ArgumentException($"Le programme {programme?.NomP} n'est pas valide");
            }
            if(programme.HorraireD <= DateTime.Now)
            {
                throw new Exception($"Le programme {programme?.NomP} ne peut pas avoir lieu dans le passé !");
            }
            if(programme.HorraireF <= programme.HorraireD)
            {
                throw new Exception($"Le programme {programme?.NomP} ne peut pas se finir avant son début !");
            }
            
            chaine.Lesprogrammes.Add(programme);
            return true;
        }

        /// <summary>
        /// Permet de supprimer un programme d'une chaîne
        /// </summary>
        /// <param name="programme">Programme à supprimer</param>
        /// <param name="chaine">Chaine à laquelle le programme appartient</param>
        /// <returns>true si correctement supprimé, false si non</returns>
        public bool SupprimerProgramme(Programme programme, Chaine chaine)
        {
            if (!chaine.Lesprogrammes.Contains(programme))
            {
                return false;
            }
            if (UtilisateurCourant.Favoris.Contains(programme))
                UtilisateurCourant.Favoris.Remove(programme);
            chaine.Lesprogrammes.Remove(programme);
            return true;
        }
    }
}
