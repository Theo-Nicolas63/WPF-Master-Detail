using Modeles;
using System.Collections.Generic;

namespace Managements
{
    public interface IPersistanceManager
    {
        /// <summary>
        /// Méthode de l'interface pour charger les données de l'app
        /// </summary>
        /// <returns>Liste des chaines et des utilisateurs</returns>
        (IEnumerable<Chaine> chaines, IEnumerable<Utilisateur> utilisateurs) ChargeDonnées();

        /// <summary>
        /// Méthode de l'interface pour sauvergarder les données de l'app
        /// </summary>
        /// <param name="chaines">Liste de chaines de l'app</param>
        /// <param name="utilisateurs">Liste d'utilisateurs de l'app</param>
        void SauvegardeDonnées(IEnumerable<Chaine> chaines, IEnumerable<Utilisateur> utilisateurs);
    }
}
