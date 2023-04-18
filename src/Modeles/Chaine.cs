using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Modeles
{

    [DataContract]
    public class Chaine : INotifyPropertyChanged
    {
        /// <summary>
        /// Nom de cette chaine
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 0)]
        public string NomC
        {
            get => nom;
            set
            {
                if (nom == value) return;
                nom = value;
                OnPropertyChanged();
            }
        }
        private string nom;

        /// <summary>
        /// Chemin vers l'image de cette chaine
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string ImgPath
        {
            get => img;
            set
            {
                if (img == value) return;
                img = value;
                OnPropertyChanged();
            }
        }
        private string img;

        /// <summary>
        /// Lien vers le direct de cette chaine
        /// </summary>
        [DataMember(Order = 2)]
        public string DirectPath { get; private set; }

        /// <summary>
        /// Description de cette chaine
        /// </summary>
        [DataMember(Order = 3)]
        [Required]
        public string Description { get; private set; }

        /// <summary>
        /// Liste de programme de cette chaine
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public ObservableCollection<Programme> Lesprogrammes { get; private set; } = new ObservableCollection<Programme>();


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Constructeur de chaine
        /// </summary>
        /// <param name="nom">Nom de la chaine</param>
        /// <param name="img">chemin de l'image</param>
        /// <param name="directpath">lien qui mène au direct de la chaine</param>
        /// <param name="description">Description de la chaine</param>
        /// <param name="programmes">Liste de programme que comporte la chaine</param>
        public Chaine(string nom, string img,string directpath, string description, ObservableCollection<Programme> programmes)
        {
            NomC = nom;
            ImgPath = img;
            Lesprogrammes = programmes;
            DirectPath = directpath;
            Description = description;
        }

        /// <summary>
        /// Permet de comparer l'égalité de 2 chaines
        /// </summary>
        /// <param name="obj">Seconde chaine testée</param>
        /// <returns></returns>
        public bool Equals(Chaine obj)
        {
            if (obj.NomC == this.NomC || obj.ImgPath == this.ImgPath || obj.DirectPath == this.DirectPath || obj.Description == this.Description || obj.Lesprogrammes == this.Lesprogrammes)
                return true;
            else
                return false;
        }
    }
}
