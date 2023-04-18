using System.Collections.Generic;
using System.Runtime.Serialization;


namespace Modeles.Persistance
{
    [DataContract]
    class DataToPersist
    {
        /// <summary>
        /// Liste des chaines enregistrés de l'application
        /// </summary>
        [DataMember]
        public List<Chaine> Chaines { get; set; } = new List<Chaine>();

        /// <summary>
        /// Liste des utilisateurs enregistrés dans l'application
        /// </summary>
        [DataMember]
        public List<Utilisateur> Utilisateurs { get; set; } = new List<Utilisateur>();
    }
}
