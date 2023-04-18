using Managements;
using System.Windows.Controls;

namespace ChaineTV_NICOLAS_TURECK
{
    /// <summary>
    /// Logique d'interaction pour ChaineUC1.xaml
    /// </summary>
    public partial class ChaineUC1 : UserControl
    {
        /// <summary>
        /// Manager actif depuis App.xaml
        /// </summary>
        public Manager Mgr => (App.Current as App).LeManager;

        public ChaineUC1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Boutton permettant d'accéder au direct de cette chaîne (si disponnible ouvre un navigateur internet)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Direct_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var info = new System.Diagnostics.ProcessStartInfo { FileName = Mgr.ChaineSélectionné.DirectPath, UseShellExecute = true };
            System.Diagnostics.Process.Start(info);
        }
    }
}
