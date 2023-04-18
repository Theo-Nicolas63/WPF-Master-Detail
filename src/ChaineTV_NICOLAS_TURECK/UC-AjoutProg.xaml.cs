using Managements;
using System.Windows.Controls;
using Modeles;
using System.Collections.Generic;
using System;
using System.Windows;

namespace ChaineTV_NICOLAS_TURECK
{
    /// <summary>
    /// Logique d'interaction pour UC_AjoutProg.xaml
    /// </summary>
    public partial class UC_AjoutProg : UserControl
    {
        /// <summary>
        /// Manager actif depuis App.xaml
        /// </summary>
        public Manager Mgr => (App.Current as App).LeManager;

        /// <summary>
        /// Navigator pour changer d'UC
        /// </summary>
        public static Navigator Navigator => Navigator.GetInstance();

        public UC_AjoutProg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Permet de Charger les Chaines présentes dans l'app dans la combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chaines_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = Mgr.Chaines;
        }

        /// <summary>
        /// Boutton permettant de valider l'ajout d'un programme, propose via une messagebox si l'on veut ajouter des acteurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterProg_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TypeP type = Mgr.StringToTypeP(Type.SelectedIndex);
            RestrictionAge age = Mgr.StringToRestrictionAge(LimAge.SelectedIndex);
            Chaine chaineCombobox = (Chaine)Chaine.SelectedItem;
            Programme programmeAjoute = new Programme(Nom.Text, type, age, Image.Text, D_Debut.SelectedDate.GetValueOrDefault(), H_Debut.SelectedTime.GetValueOrDefault(), D_Fin.SelectedDate.GetValueOrDefault(), H_Fin.SelectedTime.GetValueOrDefault(), Replay.Text, Description.Text, new List<Acteur>());

            try
            {
                Mgr.AjouterProgramme(programmeAjoute, chaineCombobox);
                Mgr.ProgrammeSélectionné = programmeAjoute;
                MessageBoxResult resultat = MessageBox.Show("Programme Ajouté\nVoulez-vous ajouter des acteurs à ce programme ?", "Confirmation", MessageBoxButton.YesNo);
                switch (resultat)
                {
                    case MessageBoxResult.Yes:
                        Navigator.NavigateTo("AjoutActeur");
                        break;
                    case MessageBoxResult.No:

                        Navigator.NavigateTo("Accueil");
                        break;
                }
            }catch(ArgumentException aex)
            {
                MessageBox.Show(aex.Message, "Ajout programme");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ajout programme");
            }
        }

        /// <summary>
        /// Permet de remettre à 0 les valeurs dans les champs lorsque l'on quitte cet UC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>    
        private void AjoutProg_Loaded(object sender, RoutedEventArgs e)
        {
            Nom.Text = null;
            Type.SelectedIndex = -1;
            LimAge.SelectedIndex = -1;
            Image.Text = null;
            D_Debut.SelectedDate = null;
            D_Fin.SelectedDate = null;
            H_Debut.SelectedTime = null;
            H_Fin.SelectedTime = null;
            Replay.Text = null;
            Description.Text = null;
        }
    }
}
