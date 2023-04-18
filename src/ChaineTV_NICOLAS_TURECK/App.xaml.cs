using Managements;
using System.Windows;
using Modeles.Persistance;

namespace ChaineTV_NICOLAS_TURECK
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Instentiation du manager principal de l'application, tout les UC et MainWindow ne font re rappeler cette instance du manager
        /// </summary>
        public Manager LeManager { get; private set; } = new Manager(new DataContractPers());

        public App() : base()
        {
            LeManager.ChargeDonnées();
        }

    }
}
