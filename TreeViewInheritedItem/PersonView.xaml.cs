using System.Windows;
using System.Windows.Controls;
using ReactiveUI;

namespace TreeViewInheritedItem
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl, IViewFor<Person>
    {
        public PersonView()
        {
            InitializeComponent();
            this.OneWayBind(ViewModel, vm => vm.Name, v => v.PersonName.Text);
        }
        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (Person)value; }
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof(Person), typeof(PersonView), new PropertyMetadata(default(Person)));

        public Person ViewModel
        {
            get { return (Person)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
    }
}
