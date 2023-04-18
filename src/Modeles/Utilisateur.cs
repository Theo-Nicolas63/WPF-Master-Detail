using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;

namespace Modeles
{
    [DataContract]
    public class Utilisateur : IDataErrorInfo, IEquatable<Utilisateur>
    {
        /// <summary>
        /// Nom de cet utilisateur
        /// </summary>
        [DataMember(Order = 2)]
        [Required]
        public string NomU { get; private set; }

        /// <summary>
        /// Prenom de cet utilisateur
        /// </summary>
        [DataMember(Order = 1)]
        [Required]
        public string Prenom { get; private set; }

        /// <summary>
        /// Surnom de cet utilisateur
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public string Surnom { get; private set; }

        /// <summary>
        /// Adresse mail de cet utilisateur
        /// </summary>
        [DataMember(Order = 5)]
        [Required]
        public string Mail { get; private set; }

        /// <summary>
        /// Mot de passe de cet utilisateur
        /// </summary>
        [DataMember(Order = 6)]
        [Required]
        [MinLength(8)]
        public string Mdp { get; private set; }

        /// <summary>
        /// Date de naissance de cet utilisateur
        /// </summary>
        [DataMember(Order = 4)]
        [Required]
        public DateTime DateDeNaissance { get; private set; }

        /// <summary>
        /// Liste des Favoris de cet utilisateur
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 7)]
        public ObservableCollection<Programme> Favoris { get; private set; } = new ObservableCollection<Programme>();

        /// <summary>
        /// Définis si un utilisateur est un administrateur ou non
        /// </summary>
        [DataMember(Order = 0)]
        public bool IsAdmin { get; private set; } = false;


        public string this[string columnName]
        {
            get
            {

                var validationResults = new List<ValidationResult>();

                if (Validator.TryValidateProperty(
                    GetType().GetProperty(columnName).GetValue(this)
                    , new ValidationContext(this)
                    {
                        MemberName = columnName
                    }
                    , validationResults))
                    return null;

                return validationResults.First().ErrorMessage;
            }
        }
        public string Error { get; }

        /// <summary>
        /// Constructeur d'un utilisateur
        /// </summary>
        /// <param name="nom">Nom de cet utilisateur</param>
        /// <param name="prenom">Prenom de cet utilisateur</param>
        /// <param name="mail">Adresse Mail de cet utilisateur</param>
        /// <param name="mdp">Mot de passe de cet utilisateur</param>
        /// <param name="ddn">Date de naissance de cet utilisateur</param>
        /// <param name="LesFavoris">Liste de favoris de cet utilisateur</param>
        /// <param name="admin">Définis si un utilisateur est un administrateur ou non</param>
        /// <param name="surnom">Surnom de cet utilisateur (peut être null)</param>
        public Utilisateur(string nom, string prenom, string mail, string mdp, DateTime ddn, ObservableCollection<Programme> LesFavoris, bool admin, string surnom = null)
        {
            if (string.IsNullOrWhiteSpace(nom) && string.IsNullOrWhiteSpace(prenom) && string.IsNullOrWhiteSpace(surnom) && string.IsNullOrWhiteSpace(mail) && string.IsNullOrWhiteSpace(mdp) && ddn.Equals(null))
            {
                throw new ArgumentException("Tous les champs ne sont pas correctement remplis !");
            }
            NomU = nom;
            Prenom = prenom;
            Surnom = surnom;
            Mail = mail;
            Mdp = mdp;
            DateDeNaissance = ddn;
            Favoris = LesFavoris;
            IsAdmin = admin;
        }

        /// <summary>
        /// Permet de calculer l'âge d'un utilisateur
        /// </summary>
        /// <param name="ddn">Date de naissance de cet utilisateur (format : dd,mm,yyyy)</param>
        /// <returns>L'âge de cet utilisateur</returns>
        public int AgeUtilisateur(DateTime ddn)
        {
            double ageU = (DateTime.Now - ddn).Days / 364.25;
            return (int)ageU;
        }


        /// <summary>
        /// Permet d'afficher l'âge d'un utilisateur
        /// </summary>
        /// <param name="ddn">Date de naissance de cet utilisateur (format : dd,mm,yyyy)</param>
        /// <returns>Retourne l'âge de cet utilisateur sous un autre format : string</returns>
        public string AfficherAge(DateTime ddn)
        {
            int age = AgeUtilisateur(ddn);
            return $"{age} ans";
        }

        /// <summary>
        /// Méthode ToString d'un Utilisateur, permet un affichage sous le format DD/MM/YYYY, si le mois est <10 et/ou le jour <10 permet d'afficher un 0
        /// exemple : 9 Mai 2020 --> 09/05/2020
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string surnom = string.IsNullOrWhiteSpace(Surnom) ? "" : $"\"{Surnom}\"";
            string prenom = string.IsNullOrWhiteSpace(Prenom) ? "" : $"{Prenom}";
            string nom = string.IsNullOrWhiteSpace(NomU) ? "" : $"{NomU}";
            if (string.IsNullOrWhiteSpace(nom) && string.IsNullOrWhiteSpace(prenom))
            {
                surnom = $"{Surnom}";
            }
            if (DateDeNaissance.Month < 10)
                if (DateDeNaissance.Day < 10)
                    return $"{prenom} {surnom} {nom} \nNé le : 0{DateDeNaissance.Day}/0{DateDeNaissance.Month}/{DateDeNaissance.Year}";
                else
                    return $"{prenom} {surnom} {nom} \nNé le : {DateDeNaissance.Day}/0{DateDeNaissance.Month}/{DateDeNaissance.Year}";

            else
                if (DateDeNaissance.Day < 10)
                return $"{prenom} {surnom} {nom} \nNé le : 0{DateDeNaissance.Day}/{DateDeNaissance.Month}/{DateDeNaissance.Year}";
            else
                return $"{prenom} {surnom} {nom} \nNé le : {DateDeNaissance.Day}/{DateDeNaissance.Month}/{DateDeNaissance.Year}";
        }

        /// <summary>
        /// Permet de comparer l'égalité de 2 utilisateurs
        /// </summary>
        /// <param name="other">Second utilisateur testé</param>
        /// <returns></returns>
        public bool Equals([AllowNull] Utilisateur other)
        {
            return NomU.Equals(other.NomU) && Prenom.Equals(other.Prenom) && Surnom.Equals(other.Surnom) && Mail.Equals(other.Mail) && Mdp.Equals(other.Mdp) && DateDeNaissance == other.DateDeNaissance;
        }

        /// <summary>
        /// Permet de comparer l'égalité de 2 utilisateurs
        /// </summary>
        /// <param name="obj">Second utilisateur testé</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Utilisateur);
        }

        /// <summary>
        /// Permet de réécrire le HashCode d'un utilisateur
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(NomU, Prenom, Surnom, Mail, Mdp, DateDeNaissance);
        }
    }
}
