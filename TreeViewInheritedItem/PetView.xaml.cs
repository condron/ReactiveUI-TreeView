using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ReactiveUI;

namespace TreeViewInheritedItem
{
    /// <summary>
    /// Interaction logic for PetView.xaml
    /// </summary>
    public partial class PetView : UserControl,IViewFor<Pet>
    {
        public PetView()
        {
            InitializeComponent();
            this.OneWayBind(ViewModel, vm => vm.Name, v => v.PetName.Text);
        }
        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (Pet)value; }
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof(Pet), typeof(PetView), new PropertyMetadata(default(Pet)));

        public Pet ViewModel
        {
            get { return (Pet)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
    }
}
