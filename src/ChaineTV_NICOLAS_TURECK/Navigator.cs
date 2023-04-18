using ChaineTV_NICOLAS_TURECK;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using System.Runtime.CompilerServices;

public class Navigator : INotifyPropertyChanged
{
    /// <summary>
    /// Dictionnary contenant tous les UserControls de l'application afin de pouvoir naviger dans l'app
    /// </summary>
    Dictionary<string, UserControl> UserControls = new Dictionary<string, UserControl>()
    {

        ["ChaineUC1"] = new ChaineUC1(),
        ["Inscription"] = new Inscription(),
        ["Emission"] = new Emission(),
        ["ProgramList2"] = new ProgramList2(),
        ["UC-AjoutProg"] = new UC_AjoutProg(),
        ["UC-Creation_Chaine"] = new UC_Creation_Chaine(),
        ["Connexion"] = new Connexion(),
        ["Accueil"] = new Accueil(),
        ["Favoris"] = new Favoris(),
        ["Recherche"] = new Recherche(),
        ["AjoutActeur"] = new AjoutActeur()

    };

    /// <summary>
    /// Permet de Changer l'UC sélectionné et ainsi changer d'UC affiché
    /// </summary>
    /// <param name="userControl">Usercontrol où l'on souhaite se diriger</param>
    public void NavigateTo(string userControl)
    {
        SelectedUserControl = UserControls.GetValueOrDefault(userControl);
    }

    private static Navigator instanceUnique;

    public static Navigator GetInstance() // singleton
    {
        if (instanceUnique == null)
        {
            instanceUnique = new Navigator();
        }
        return instanceUnique;
    }

    /// <summary>
    /// Constructeur d'un Navigator, défini la page de démarage avec l'UC "Accueil"
    /// </summary>
    private Navigator()
    {
        SelectedUserControl = UserControls["Accueil"];
    }

    /// <summary>
    /// Permet d'avoir l'UC sélectionné
    /// </summary>
    private UserControl selectedUserControl;
    public UserControl SelectedUserControl
    {
        get => selectedUserControl;
        set
        {
            selectedUserControl = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedUserControl)));
}