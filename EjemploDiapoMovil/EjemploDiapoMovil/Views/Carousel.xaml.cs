using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EjemploDiapoMovil.Views
{
    public partial class Carousel : ContentPage
    {

        public class UserInformation
        {
            public ImageSource UserImage { get; set; }

        }
        private ObservableCollection<UserInformation> userCollection;
        public ObservableCollection<UserInformation> UserCollection
        {
            get { return userCollection; }
            set
            {
                userCollection = value;
                OnPropertyChanged();
            }
        }


        public Carousel()
        {
            InitializeComponent();
            BindingContext = this;
            UserCollection = new ObservableCollection<UserInformation>
            {
                new UserInformation{UserImage = "pic1.jpg"},
                new UserInformation{UserImage = "pic2.jpg"},
                new UserInformation{UserImage = "pic1.jpg"},
                new UserInformation{UserImage = "pic2.jpg"},
            };

        }
    }
}
