using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Managements;
using Modeles;

namespace ChaineTV_NICOLAS_TURECK
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Inscription : UserControl
    {
        /// <summary>
        /// Manager actif depuis App.xaml
        /// </summary>
        public Manager Mgr => (App.Current as App).LeManager;

        /// <summary>
        /// Navigator pour changer d'UC
        /// </summary>
        public static Navigator Navigator => Navigator.GetInstance();

        public Inscription()
        {            
            InitializeComponent();
        }

        /// <summary>
        /// Boutton permettant de confirmer l'inscription cela crée le compte si les donnée entrées sont correctes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Valider_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                Mgr.AjouterUtilisateur(new Utilisateur(nom.Text, prenom.Text, mail.Text, mdp.Password, DDN.SelectedDate.GetValueOrDefault(), new ObservableCollection<Programme>(), false, pseudo.Text));
                MessageBox.Show("Compte créé ! Vous pouvez desormais vous connecter", "Inscription");
                Navigator.NavigateTo("Connexion");
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Inscription");
            }
                
        }

        /// <summary>
        /// Permet de remettre à zero les valeurs dans les champs quand on quitte cet UC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inscription_Loaded(object sender, RoutedEventArgs e)
        {
            nom.Text = null;
            prenom.Text = null;
            mail.Text = null;
            mdp.Password = null;
            DDN.SelectedDate = null;
            pseudo.Text = null;
        }
    }
}
