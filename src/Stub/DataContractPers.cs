using Managements;
using Modeles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Stub
{
    public class DataContractPers : IPersistanceManager
    {

        /// <summary>
        /// Chemin vers le dossier de la persistance
        /// </summary>
        public string FilePath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "XML");

        /// <summary>
        /// Nom du fichier de la persistance
        /// </summary>
        public string FileName { get; set; } = "donneeApp.xml";

        /// <summary>
        /// Fichier de persistance, propriété calculé du chemin vers le fichier
        /// </summary>
        public string PersFile => Path.Combine(FilePath, FileName);

        /// <summary>
        /// Ecriture de la méthode permettant le chargement des données dans l'app via le fichier XML
        /// </summary>
        /// <returns>Renvoie la IEnumerable des chaines et des utilisateurs</returns>
        public (IEnumerable<Chaine> chaines, IEnumerable<Utilisateur> utilisateurs) ChargeDonnées()
        {
            if (!File.Exists(PersFile))
            {
                throw new FileNotFoundException("Le fichier de persistance est manquant");
            }
            var serializer = new DataContractSerializer(typeof(IEnumerable<Chaine>));

            IEnumerable<Chaine> chaines;
            using (Stream s = File.OpenRead(PersFile))
            {
                chaines = serializer.ReadObject(s) as IEnumerable<Chaine>;
            }
            return (chaines, new List<Utilisateur>());
        }

        /// <summary>
        /// Méthode permettant la sauvegarde des données de l'app dans le fichier XML
        /// </summary>
        /// <param name="chaines">Liste des chaines de l'app</param>
        /// <param name="utilisateurs">Liste des Utilisateurs de l'app</param>
        public void SauvegardeDonnées(IEnumerable<Chaine> chaines, IEnumerable<Utilisateur> utilisateurs)
        {
            var serializer = new DataContractSerializer(typeof(IEnumerable<Chaine>));

            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);

            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(PersFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    serializer.WriteObject(writer, chaines);
                }
            }
        }
    }
}
