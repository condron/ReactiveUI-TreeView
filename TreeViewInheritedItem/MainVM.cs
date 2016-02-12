using System;
using ReactiveUI;

namespace TreeViewInheritedItem
{
    public class MainVM : ReactiveObject
    {
        private readonly ReactiveCommand<object> _addPerson;
        private readonly ReactiveCommand<object> _addPet;

        public MainVM()
        {
            var bobbyJoe = new Person("Bobby Joe", new[] { new Pet("Fluffy") });
            var bob = new Person("Bob", new[] { bobbyJoe });
            var littleJoe = new Person("Little Joe");
            var joe = new Person("Joe", new[] { littleJoe });
            Family = new ReactiveList<TreeItem> { bob, joe };

            _addPerson = ReactiveCommand.Create();
            _addPerson.Subscribe(_ =>
            {
                SelectedItem?.Children.Add(new Person(NewName));
            });
            _addPet = ReactiveCommand.Create();
            _addPet.Subscribe(_ =>
            {
                SelectedItem?.Children.Add(new Pet(PetName));
            });
        }

        public ReactiveList<TreeItem> Family { get; }
        public ReactiveCommand<object> AddPerson => this._addPerson;
        public ReactiveCommand<object> AddPet => this._addPet;

        string _newName;
        public string NewName
        {
            get { return _newName; }
            set { this.RaiseAndSetIfChanged(ref _newName, value); }
        }
        string _petName;
        public string PetName
        {
            get { return _petName; }
            set { this.RaiseAndSetIfChanged(ref _petName, value); }
        }

        TreeItem _selectedItem;
        public TreeItem SelectedItem
        {
            get { return _selectedItem; }
            set { this.RaiseAndSetIfChanged(ref _selectedItem, value); }
        }
    }
}
