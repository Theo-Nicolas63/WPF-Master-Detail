using Managements;
using Modeles;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ChaineTV_NICOLAS_TURECK
{
    /// <summary>
    /// Logique d'interaction pour UC_Creation_Chaine.xaml
    /// </summary>
    public partial class UC_Creation_Chaine : UserControl
    {
        /// <summary>
        /// Manager actif depuis App.xaml
        /// </summary>
        public Manager Mgr => (App.Current as App).LeManager;
        
        /// <summary>
        /// Navigator pour changer d'UC
        /// </summary>
        public static Navigator Navigator => Navigator.GetInstance();


        public UC_Creation_Chaine()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Boutton permettant de créer une chaine en validant les champs rentrés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Creer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                Mgr.AjouterChaine(new Chaine(Nom.Text, Img.Text, Direct.Text, Description.Text, new ObservableCollection<Programme>()));
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Création Chaine");
            }
            Navigator.NavigateTo("Accueil");
        }

        /// <summary>
        /// Permet de remettre à 0 les valeurs dans les champs lorsque l'on quitte cet UC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Creation_Chaine_Loaded(object sender, RoutedEventArgs e)
        {
            Nom.Text = null;
            Img.Text = null;
            Direct.Text = null;
            Description.Text = null;
        }
    }
}
