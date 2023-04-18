using Managements;
using System.Windows.Controls;

namespace ChaineTV_NICOLAS_TURECK
{
    /// <summary>
    /// Logique d'interaction pour ProgramList2.xaml
    /// </summary>
    public partial class ProgramList2 : UserControl
    {
        /// <summary>
        /// Manager actif depuis App.xaml
        /// </summary>
        public Manager Mgr => (App.Current as App).LeManager;

        public ProgramList2()
        {
            InitializeComponent();
        }
    }
}
