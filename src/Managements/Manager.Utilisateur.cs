using Modeles;
using System;

namespace Managements
{
    public partial class Manager
    {
        /// <summary>
        /// Permet de voir quel est l'utilisateur courant
        /// </summary>
        private Utilisateur utilisateurCourant = null;
        public Utilisateur UtilisateurCourant
        {
            get { return utilisateurCourant; }
            set
            {
                    utilisateurCourant = value;
                    OnPropertyChanged();
            }
        }

        /// <summary>
        /// Permet de rechercher un utilisateur en le comparant à la liste d'utilisateurs
        /// </summary>
        /// <param name="mail">Adresse mail de cet utilisateur</param>
        /// <param name="mdp">Mot de passe de cet utilisateur</param>
        /// <returns>Renvoi l'utilisateur si il existe déjà la paire mail/mdp rensaignée</returns>
        public Utilisateur RechercheUtilisateur(string mail, string mdp)
        {
            foreach(Utilisateur u in UtilisateursList)
            {
                if (u.Mail == mail)
                {
                    if (u.Mdp == mdp)
                    {
                        return u;
                    }
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Permet de se connecter sur l'application
        /// </summary>
        /// <param name="mail">Adresse mail de cet utilisateur</param>
        /// <param name="mdp">Mot de passe de cet utilisateur</param>
        /// <returns>true si il s'est connecté, false si non</returns>
        public bool Connexion(string mail, string mdp)
        {
            Utilisateur trouve = RechercheUtilisateur(mail, mdp);

            if (trouve != null)
            {
                UtilisateurCourant = trouve;
                return true;
            }
            else
                return false;
        }
        
        /// <summary>
        /// Permet de creer un utilisateur et de l'ajouter à la liste d'utilisateur.
        /// </summary>
        /// <param name="utilisateur">Utilisateur à ajouter</param>
        /// <returns>bool => False si l'ajout ne sait pas fait correctement => True si tout s'est bien déroulé"</returns>
        public bool AjouterUtilisateur(Utilisateur utilisateur)
        {
            if (UtilisateursList.Contains(utilisateur))
            {
                return false;
            }
            if (utilisateur.NomU == null || string.IsNullOrWhiteSpace(utilisateur.NomU) || utilisateur.Prenom==null || string.IsNullOrWhiteSpace(utilisateur.Prenom) || utilisateur.Mail == null || string.IsNullOrWhiteSpace(utilisateur.Mail) || utilisateur.Mdp == null || string.IsNullOrWhiteSpace(utilisateur.Mdp))
            {
                throw new ArgumentException($"L'utilateur {utilisateur?.NomU} n'est pas valide");
            }
            UtilisateursList.Add(utilisateur);
            Utilisateurs.Add(utilisateur);
            return true;
        }
    }
}
