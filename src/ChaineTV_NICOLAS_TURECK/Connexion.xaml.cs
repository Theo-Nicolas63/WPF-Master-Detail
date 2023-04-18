using Managements;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChaineTV_NICOLAS_TURECK
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : UserControl
    {
        /// <summary>
        /// Manager actif depuis App.xaml
        /// </summary>
        public Manager Mgr => (App.Current as App).LeManager;

        /// <summary>
        /// Navigator pour changer d'UC
        /// </summary>
        public static Navigator Navigator => Navigator.GetInstance();

        public Connexion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Boutton permettant de valider les champs rempli vérifier la connexion si elle est bonne connecte l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeConnecter_Click(object sender, RoutedEventArgs e)
        {
            bool connexion = Mgr.Connexion(MonEmail.Text, MotDePasse.Password);
            if (connexion)
                Navigator.NavigateTo("Accueil");
            else MessageBox.Show("Adresse mail ou mot de passe invalide !", "Connexion");
        }

        /// <summary>
        /// Hyperlink vers l'UC de création de compte (inscription)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inscription(object sender, MouseButtonEventArgs e)
        {
            Navigator.NavigateTo("Inscription");
        }

        /// <summary>
        /// Permet de remettre à 0 les valeurs des champs quand on quitte l'UC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Connexion_Loaded(object sender, RoutedEventArgs e)
        {
            MonEmail.Text = null;
            MotDePasse.Password = null;
        }
    }
}
