using Managements;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Modeles.Persistance
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
        public string FileName { get; set; } = "donneeapp.xml";

        /// <summary>
        /// Fichier de persistance, propriété calculé du chemin vers le fichier
        /// </summary>
        public string PersFile => Path.Combine(FilePath, FileName);

        private DataContractSerializer Serializer { get; set; } = new DataContractSerializer(typeof(DataToPersist),
                                                new DataContractSerializerSettings()
                                                {
                                                    PreserveObjectReferences = true
                                                });

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

            DataToPersist data;
            using (Stream s = File.OpenRead(PersFile))
            {
                data = Serializer.ReadObject(s) as DataToPersist;
            }
            return (data.Chaines, data.Utilisateurs);
        }

        /// <summary>
        /// Méthode permettant la sauvegarde des données de l'app dans le fichier XML
        /// </summary>
        /// <param name="chaines">Liste des chaines de l'app</param>
        /// <param name="utilisateurs">Liste des Utilisateurs de l'app</param>
        public void SauvegardeDonnées(IEnumerable<Chaine> chaines, IEnumerable<Utilisateur> utilisateurs)
        {
            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);

            DataToPersist data = new DataToPersist();
            data.Chaines.AddRange(chaines);
            data.Utilisateurs.AddRange(utilisateurs);

            var settings = new XmlWriterSettings() { Indent = true };
            using (TextWriter tw = File.CreateText(PersFile))
            {
                using (XmlWriter writer = XmlWriter.Create(tw, settings))
                {
                    Serializer.WriteObject(writer, data);
                }
            }
        }
    }
}
