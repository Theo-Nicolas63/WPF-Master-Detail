using System.Runtime.Serialization;

namespace Modeles
{
    [DataContract]
    public class Acteur
    {
        /// <summary>
        /// Nom de cet acteur
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string Nom { get; private set; }

        /// <summary>
        /// Chemin vers l'image de cet acteur
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string Img { get; private set; }

        /// <summary>
        /// Constructeur d'un acteur
        /// </summary>
        /// <param name="nom">Nom de cet acteur</param>
        /// <param name="imgPath">Chemin vers l'image de cet acteur</param>
        public Acteur(string nom, string imgPath)
        {
            Nom = nom;
            Img = imgPath;
        }

    }
}
