using Managements;
using Modeles;
using System.Windows;
using System.Windows.Controls;

namespace ChaineTV_NICOLAS_TURECK
{
    /// <summary>
    /// Logique d'interaction pour AjoutActeur.xaml
    /// </summary>
    public partial class AjoutActeur : UserControl
    {
        /// <summary>
        /// Manager actif depuis App.xaml
        /// </summary>
        public Manager Mgr => (App.Current as App).LeManager;

        /// <summary>
        /// Navigator pour changer d'UC
        /// </summary>
        public static Navigator Navigator => Navigator.GetInstance();

        public AjoutActeur()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Boutton permettant d'ajouter un acteur, valide les champs remplis demande si l'on veut en ajouter un autre si insertion correcte
        /// si ll'insertion est mauvaise messagebox d'erreur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjoutActeur_Click(object sender, RoutedEventArgs e)
        {
            Mgr.ProgrammeSélectionné.LesActeurs.Add(new Acteur(NomActeur.Text, Chemin.Text));
            MessageBoxResult resultat = MessageBox.Show("Voulez-vous ajouter d'autres acteurs ?", "Confirmation", MessageBoxButton.YesNo);
            switch (resultat)
            {
                case MessageBoxResult.Yes:
                    UserControl_Loaded(sender, e);
                    break;
                case MessageBoxResult.No:
                    Mgr.ProgrammeSélectionné = null;
                    Navigator.NavigateTo("Accueil");
                    break;
            }
        }

        /// <summary>
        /// Permete de remettre à 0 l'UC quand on le quitte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            NomActeur.Text = null;
            Chemin.Text = null;
        }
    }
}
