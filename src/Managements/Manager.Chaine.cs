using Modeles;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Managements
{
    public partial class Manager
    {
        /// <summary>
        /// Permet de mettre à jour la chaine sélectionné dans la listbox du master
        /// </summary>
        private Chaine chaineSélectionné = null;
        public Chaine ChaineSélectionné
        {
            get => chaineSélectionné;
            set
            {
                if (chaineSélectionné != value)
                {
                    chaineSélectionné = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Permet d'ajouter une nouvelle chaine à la liste de chaine
        /// </summary>
        /// <param name="chaine">Chaine à ajouter</param>
        /// <returns>true si ajout correct, false si non</returns>
        public bool AjouterChaine(Chaine chaine)
        {
            if (ChainesList.Contains(chaine))
            {
                return false;
            }
            if (chaine.NomC == null || string.IsNullOrWhiteSpace(chaine.NomC) || chaine.ImgPath == null || string.IsNullOrWhiteSpace(chaine.ImgPath) || chaine.Description == null || string.IsNullOrWhiteSpace(chaine.Description) || chaine.DirectPath == null || string.IsNullOrWhiteSpace(chaine.DirectPath) || chaine.Lesprogrammes == null)
            {
                throw new ArgumentException($"La chaîne {chaine?.NomC} n'est pas valide");
            }
            ChainesList.Add(chaine);
            Chaines.Add(chaine);
            return true;
        }

        /// <summary>
        /// Permet de Supprimer une chaine en la retirant de la liste de chaine
        /// </summary>
        /// <param name="chaine"></param>
        /// <returns></returns>
        //public bool SupprimerChaine(Chaine chaine)
        //{
        //    if (!chaines.Contains(chaine))
        //    {
        //        return false;
        //    }
        //    chaines.Remove(chaine);
        //    return true;
        //}

        /// <summary>
        /// Permet de trouver une chaîne
        /// </summary>
        /// <param name="chaine">Chaine à retrouver</param>
        /// <returns>Renvoie la chaîne correspondante</returns>
        public Chaine GetChaine(Chaine chaine)
        {
            return chaines.SingleOrDefault(c => c.Equals(chaine));
        }

        /// <summary>
        /// Permet de trouver une chaîne
        /// </summary>
        /// <param name="nom">Nom de cette chaîne</param>
        /// <param name="imgpath">Chemin vers l'image de cette chaîne</param>
        /// <param name="directpath">Lien vers le direct de cette chaîne</param>
        /// <param name="description">Description de cette chaîne</param>
        /// <param name="programmes">Liste de programme de cette chaîne</param>
        /// <returns>Renvoie la chaîne correspondante</returns>
        public Chaine GetChaine(string nom, string imgpath, string directpath, string description, ObservableCollection<Programme> programmes)
        {
            return GetChaine(new Chaine(nom, imgpath, directpath, description, programmes));
        }

        //public Chaine ModifieChaine(Chaine oldC, Chaine newC)
        //{
        //    if (!oldC.Equals(newC))
        //        return null;
        //    Type typeChaine = typeof(Chaine);
        //    var chaineProperties = typeChaine.GetProperties();

        //    foreach(var property in chaineProperties.Where(ppty => ppty.CanWrite))
        //    {
        //        property.SetValue(oldC, property.GetValue(newC));
        //    }
        //    return oldC;
        //}
    }
}
