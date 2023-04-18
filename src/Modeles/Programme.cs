using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Modeles
{
    [DataContract]
    public class Programme
    {
        /// <summary>
        /// Nom de ce programme
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string NomP { get; private set; }

        /// <summary>
        /// Type de ce programme
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public TypeP Type { get; private set; }
   
        /// <summary>
        /// Horraide de Début de ce programme
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public DateTime HorraireD { get; private set; }

        /// <summary>
        /// Haorraide de fin de ce programme
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 4)]
        public DateTime HorraireF { get; private set; }

        /// <summary>
        /// Age minimal pour regarder ce programme
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public RestrictionAge AgeMinimal { get; private set; }

        /// <summary>
        /// Chemin vers l'image de ce programme
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 5)]
        public string ImgPathP { get; private set; }

        /// <summary>
        /// Lien vers le replay  de ce programme (si existe)
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 6)]
        public string ReplayPath { get; private set; }

        /// <summary>
        /// Description  de ce programme
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 7)]
        public string Description { get; private set; }

        /// <summary>
        /// Liste d'acteur de ce programme
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 8)]
        public List<Acteur> LesActeurs { get; private set; } = new List<Acteur>();

        /// <summary>
        /// Constructeur principal d'un programme
        /// </summary>
        /// <param name="nom">Nom de ce programme</param>
        /// <param name="type">Type de ce programme</param>
        /// <param name="agemin">Age minimal requis pour regarder ce programme</param>
        /// <param name="img">Chemin vers l'image de ce programme</param>
        /// <param name="datedeb">Date de debut de ce programme</param>
        /// <param name="horrairedeb">Horraire de début de ce programme</param>
        /// <param name="datefin">Date de fin de ce programme</param>
        /// <param name="horrairefin">Horraire de fin de ce programme</param>
        /// <param name="replaypath">Lien vers le replay de ce programme (si existe)</param>
        /// <param name="description">Description de ce programme</param>
        /// <param name="Acteurs">iste d'acteur de ce programme</param>
        public Programme(string nom, TypeP type, RestrictionAge agemin, string img, DateTime datedeb, DateTime horrairedeb, DateTime datefin, DateTime horrairefin, string replaypath, string description, List<Acteur> Acteurs)
        {
            NomP = nom;
            Type = type;
            HorraireD = new DateTime(datedeb.Year, datedeb.Month, datedeb.Day, horrairedeb.Hour, horrairedeb.Minute, 0);
            HorraireF = new DateTime(datefin.Year, datefin.Month, datefin.Day, horrairefin.Hour, horrairefin.Minute, 0);
            AgeMinimal = agemin;
            ImgPathP = img;
            LesActeurs = Acteurs;
            Description = description;
            ReplayPath = replaypath;

        }

        /// <summary>
        /// Constructeur d'un programme non diffusé actuellement sans date et heure
        /// </summary>
        /// <param name="nom">Nom de ce programme</param>
        /// <param name="type">Type de ce programme</param>
        /// <param name="agemin">Age minimal requis pour regarder ce programme</param>
        /// <param name="img">Chemin vers l'image de ce programme</param>
        /// <param name="replaypath">Lien vers le replay de ce programme (si existe)</param>
        /// <param name="description">Description de ce programme</param>
        /// <param name="Acteurs">iste d'acteur de ce programme</param>
        public Programme(string nom, TypeP type, RestrictionAge agemin, string img, string replaypath, string description, List<Acteur> Acteurs)
        {
            NomP = nom;
            Type = type;
            AgeMinimal = agemin;
            ImgPathP = img;
            Description = description;
            ReplayPath = replaypath;

        }

        /// <summary>
        /// Permet de Verifier su l'utilisateur est assez âgé pour ce programme
        /// </summary>
        /// <param name="u1">Utilisateur souhaitant regarder le programme</param>
        /// <param name="ageminimal">Age minimal requis pour regarder ce programme</param>
        /// <returns></returns>
        public bool VerifAge(Utilisateur u1, RestrictionAge ageminimal)
        {
            int age = u1.AgeUtilisateur(u1.DateDeNaissance);

            if (ageminimal == RestrictionAge.dix)
                if (age < 10)
                    return false;
            if (ageminimal == RestrictionAge.douze)
                if (age < 12)
                    return false;
            if (ageminimal == RestrictionAge.seize)
                if (age < 16)
                    return false;
            if (ageminimal == RestrictionAge.dix_huit)
                if (age < 18)
                    return false;
            return true;
        }

        /// <summary>
        /// Permet d'afficher les restriction d'âge
        /// </summary>
        /// <param name="ageminimal">Age minimal requis pour regarder ce programme</param>
        /// <returns></returns>
        public string AfficherRestrictionAge(RestrictionAge ageminimal)
        {
            if (ageminimal == RestrictionAge.dix)
                return "-10";
            if (ageminimal == RestrictionAge.douze)
                return "-12";
            if (ageminimal == RestrictionAge.seize)
                return "-16";
            if (ageminimal == RestrictionAge.dix_huit)
                return "-18";
            return "Tout Public";
        }

        /// <summary>
        /// Permet d'afficher un message suivant l'âge de l'utilisateur et la restriction d'âge du programme
        /// </summary>
        /// <param name="u1">Utilisateur souhaitant regarder le programme</param>
        /// <param name="ageminimal">Age minimal requis pour regarder ce programme</param>
        /// <returns></returns>
        public string AfficherMessageVerifAge(Utilisateur u1, RestrictionAge ageminimal)
        {
            bool validateur = VerifAge(u1, AgeMinimal);
            if (validateur == false)
                return "Vous ne remplissez pas les conditions pour regarder ce programme : \n- Restriction d'âge dû au programme";
            return "Vous pouvez regarder ce programme";

        }

        /// <summary>
        /// Calcule la durrée totale d'un programme
        /// </summary>
        /// <param name="horraired">Horraire de début de ce programme</param>
        /// <param name="horrairef">Horraire de fin de ce programme</param>
        /// <returns></returns>
        public string CalculDureeTot(DateTime horraired, DateTime horrairef)
        {
            string dureeTot;
            int dureeMinute;
            int dureeHeure;

            //Vérification si il s'agit du même jour, si non on règle l'heure (+24h)
            if (horrairef.Day != horraired.Day)
                dureeHeure = 24 + (horrairef.Hour - horraired.Hour);
            else
                dureeHeure = horrairef.Hour - horraired.Hour;

            //Vérification si les minutes du début sont >= aux minutes de fin Ex : 12h30 --> 14h15 où 30>15
            if (horrairef.Minute >= horraired.Minute)
            {
                dureeMinute = (horrairef.Minute - horraired.Minute);
                if (dureeMinute < 10)
                    return dureeTot = $"Durée :{dureeHeure}h0{dureeMinute}";
                else
                    return dureeTot = $"Durée :{dureeHeure}h{dureeMinute}";
            }
            //Vérification si les minutes du début sont < aux minutes de fin Ex : 12h15 --> 14h30 où 15<30
            if (horrairef.Minute < horraired.Minute)
            {
                dureeMinute = 60 - (horraired.Minute - horrairef.Minute);
                dureeHeure--;
                if (dureeMinute < 10)
                    return dureeTot = $"Durée :{dureeHeure}h0{dureeMinute}";
                else
                    return dureeTot = $"Durée :{dureeHeure}h{dureeMinute}";
            }
            return string.Empty;
        }

        /// <summary>
        /// Affiche l'heure de diffusion d'un programme
        /// </summary>
        /// <param name="horraired">Horraire de début de ce programme</param>
        /// <returns>String de l'heure de diffusion</returns>
        public string AfficherHeureDiffusion(DateTime horraired)
        {
            string heure;
            if (horraired.Minute < 10)
                heure = $"Diffusé à : {horraired.Hour}h{horraired.Minute}0";
            else
                heure = $"Diffusé à : {horraired.Hour}h{horraired.Minute}";
            return heure;
        }

        /// <summary>
        /// Permet d'afficher la date de diffusion d'un programme
        /// </summary>
        /// <param name="horraired">Horraire de début de ce programme</param>
        /// <returns>string de la date de diffusion</returns>
        public string AfficherDateDiffusion(DateTime horraired)
        {
            string date;
            if (horraired.Month < 10)
                if (horraired.Day < 10)
                    date = $"Le : 0{horraired.Day}/0{horraired.Month}/{horraired.Year}";
                else
                    date = $"Le : {horraired.Day}/0{horraired.Month}/{horraired.Year}";
            else
                if (horraired.Day < 10)
                date = $"Le : 0{horraired.Day}/{horraired.Month}/{horraired.Year}";
            else
                date = $"Le : {horraired.Day}/{horraired.Month}/{horraired.Year}";
            return date;
        }

        /// <summary>
        /// Méthode qui réecrit le ToString pour pouvoir afficher de telle façon la date de diffusion, la durée et l'age minimal d'un programme.
        /// </summary>
        /// <returns>Elle retourne un string pour l'affichage des attributs d'un programme.</returns>
        public override string ToString()
        {
            string heure = AfficherHeureDiffusion(HorraireD);
            string date = AfficherDateDiffusion(HorraireD);
            string duree = CalculDureeTot(HorraireD, HorraireF);
            string agemin = AfficherRestrictionAge(AgeMinimal);
            return $"{NomP} | {Type} | {agemin}\n{heure}\n{date}\n{duree}";
        }
    }
}
