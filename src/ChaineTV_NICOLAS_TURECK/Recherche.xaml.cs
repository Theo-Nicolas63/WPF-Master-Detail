using Managements;
using System.Windows.Controls;


namespace ChaineTV_NICOLAS_TURECK
{
    /// <summary>
    /// Logique d'interaction pour Recherche.xaml
    /// </summary>
    public partial class Recherche : UserControl
    {
        /// <summary>
        /// Manager actif depuis App.xaml
        /// </summary>
        public Manager Mgr => (App.Current as App).LeManager;

        /// <summary>
        /// Navigator pour changer d'UC
        /// </summary>
        public static Navigator Navigator => Navigator.GetInstance();

        public Recherche()
        {
            InitializeComponent();
            DataContext = this;
        }

    }
}
