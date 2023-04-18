using System.Collections.ObjectModel;
using System.Windows;
using Managements;
using Modeles;

namespace ChaineTV_NICOLAS_TURECK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Manager actif depuis App.xaml
        /// </summary>
        public Manager Mgr => (App.Current as App).LeManager;

        /// <summary>
        /// Navigator pour changer d'UC
        /// </summary>
        public static Navigator Navigator { get; set; } = Navigator.GetInstance();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

        }

        /// <summary>
        /// Boutton permettant d'accéder à l'UC de création d'une chaîne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterChaine_Click(object sender, RoutedEventArgs e)
        {

            Navigator.NavigateTo("UC-Creation_Chaine");
            Mgr.ChaineSélectionné = null;
        }

        /// <summary>
        /// Boutton permettant d'accéder à l'UC de création d'un programme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterProgramme_Click(object sender, RoutedEventArgs e)
        {

            Navigator.NavigateTo("UC-AjoutProg");
            Mgr.ChaineSélectionné = null;
        }

        /// <summary>
        /// Boutton permettant d'accéder à l'UC de cronnexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Connexion_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo("Connexion");
            Mgr.ChaineSélectionné = null;
        }

        /// <summary>
        /// Boutton permettant d'accéder à l'UC de la liste de Favoris (uniquement si connecté)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Favoris_Click(object sender, RoutedEventArgs e)
        {
            if(Mgr.UtilisateurCourant == null)
                MessageBox.Show("Vous devez vous connecter pour accéder à vos programmes favoris !", "Confirmation");
            else
            {
                Navigator.NavigateTo("Favoris");
                Mgr.ChaineSélectionné = null;
            }
        }

        /// <summary>
        /// Boutton permettant d'accéder à la page d'accueil (UC Accueil)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo("Accueil");
            Mgr.ChaineSélectionné = null;
        }

        /// <summary>
        /// Boutton permettant d'accéder à l'UC de recherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Recherche_Click(object sender, RoutedEventArgs e)
        {
            Mgr.ListprogrammesVoulus = new ObservableCollection<Programme>();
            Mgr.ProgrammeVoulu = MaRecherche.Text;
            Mgr.FiltreVoulu = Filtre.SelectedIndex;
            Navigator.NavigateTo("Recherche");
            Mgr.ChaineSélectionné = null;
            Mgr.Recherche(Mgr.ProgrammeVoulu, Mgr.FiltreVoulu);
            MaRecherche.Text = null;
            Mgr.ProgrammeVoulu = null;
            Filtre.SelectedIndex = -1;
            Mgr.FiltreVoulu = -1;
        }

        /// <summary>
        /// Boutton permettant de se déconnecter, remplace le boutton connecté que on l'est
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Deconnexion_Click(object sender, RoutedEventArgs e)
        {
            Mgr.UtilisateurCourant = null;
            Mgr.ChaineSélectionné = null;
            Navigator.NavigateTo("Accueil");
        }

        /// <summary>
        /// Gestion de la fermeture de l'application, message box confirmation vraiment quitter et sauvegarde oui ou non
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult resultat = MessageBox.Show("Voulez-vous vraiment fermer l'application ?", "Confirmation", MessageBoxButton.YesNo);
            switch (resultat)
            {
                case MessageBoxResult.Yes:
                    MessageBoxResult result = MessageBox.Show("Voulez-vous Sauvegarder ?", "Confirmation", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            Mgr.SauvergardeDonnées();
                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                    break;
                case MessageBoxResult.No:
                    e.Cancel = true;
                    break;
            }
        }
    }
}
