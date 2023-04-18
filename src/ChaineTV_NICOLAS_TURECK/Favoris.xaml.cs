using Managements;
using System.Windows;
using System.Windows.Controls;

namespace ChaineTV_NICOLAS_TURECK
{
    /// <summary>
    /// Logique d'interaction pour Favoris.xaml
    /// </summary>
    public partial class Favoris : UserControl
    {
        /// <summary>
        /// Manager actif depuis App.xaml
        /// </summary>
        public Manager Mgr => (App.Current as App).LeManager;

        public Favoris()
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
            var info = new System.Diagnostics.ProcessStartInfo { FileName = Mgr.ProgrammeSélectionné.ReplayPath, UseShellExecute = true };
            System.Diagnostics.Process.Start(info);
        }

        /// <summary>
        /// Remet à 0 l'UC quand on le quitte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Favoris_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var list = sender as ListBox;
            list.ItemsSource = Mgr.UtilisateurCourant.Favoris;
        }
    }
}
