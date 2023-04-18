using Managements;
using System.Windows;
using System.Windows.Controls;

namespace ChaineTV_NICOLAS_TURECK
{
    /// <summary>
    /// Logique d'interaction pour Emission.xaml
    /// </summary>
    public partial class Emission : UserControl
    {
        /// <summary>
        /// Manager actif depuis App.xaml
        /// </summary>
        public Manager Mgr => (App.Current as App).LeManager;

        /// <summary>
        /// Navigator pour changer d'UC
        /// </summary>
        public static Navigator Navigator => Navigator.GetInstance();

        public Emission()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Boutton permettant d'accéder au replay du programme (ouvre un navigateur internet)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Replay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var info = new System.Diagnostics.ProcessStartInfo { FileName = Mgr.ProgrammeSélectionné.ReplayPath, UseShellExecute = true };
                System.Diagnostics.Process.Start(info);
            }
            catch
            {
                MessageBox.Show("Replay Indisponible pour ce programme !");
            }
        }

        /// <summary>
        /// Boutton permettant d'ajouter le programme à ses favoris (uniquement si connecté)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterFavoris(object sender, RoutedEventArgs e)
        {
            if (Mgr.UtilisateurCourant == null)
            {
                MessageBox.Show("Vous devez vous connecter pour accéder à vos programmes favoris !", "Confirmation");
            }
            else
                if (Mgr.UtilisateurCourant.Favoris.Contains(Mgr.ProgrammeSélectionné))
                {
                    MessageBoxResult result = MessageBox.Show("Ce programme est déjà ajouté aux Favoris\nVoulez-vous le supprimer de vos Favoris ?", "Confirmation", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            Mgr.UtilisateurCourant.Favoris.Remove(Mgr.ProgrammeSélectionné);
                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                }
            else Mgr.UtilisateurCourant.Favoris.Add(Mgr.ProgrammeSélectionné);
        }

        /// <summary>
        /// Boutton permettant de supprimer le programme (uniquement pour les admin sinon le boutton n'apparaît pas)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce programme ?", "Confirmation", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Mgr.UtilisateurCourant.Favoris.Remove(Mgr.ProgrammeSélectionné);
                    break;
                case MessageBoxResult.No:
                    break;
            }
            Mgr.SupprimerProgramme(Mgr.ProgrammeSélectionné, Mgr.RechercherProginChaines(Mgr.ProgrammeSélectionné));
            if (Mgr.UtilisateurCourant.Favoris.Contains(Mgr.ProgrammeSélectionné))
                Mgr.UtilisateurCourant.Favoris.Remove(Mgr.ProgrammeSélectionné);
            Mgr.ProgrammeSélectionné = null;
            MessageBox.Show("Programme supprimé !");
        }
    }
}
