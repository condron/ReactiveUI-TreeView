using System;
using ReactiveUI;

namespace TreeViewInheritedItem
{
    public class MainVM : ReactiveObject
    {
        private readonly ReactiveCommand<object> _addPerson;
        private readonly ReactiveCommand<object> _addPet;
        private readonly ReactiveCommand<object> _collapse;

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
                if (SelectedItem == null) return;
                var p = new Person(NewName);
                SelectedItem.AddChild(p);
                p.IsSelected = true;
                p.ExpandPath();
            });
            _addPet = ReactiveCommand.Create();
            _addPet.Subscribe(_ =>
            {
                if (SelectedItem == null) return;
                var p = new Pet(PetName);
                SelectedItem.AddChild(p);
                p.IsSelected = true;
                p.ExpandPath();
            });
            _collapse = ReactiveCommand.Create();
            _collapse.Subscribe(_ =>
            {
                SelectedItem?.CollapsePath();
            });
        }

        public ReactiveList<TreeItem> Family { get; }
        public ReactiveCommand<object> AddPerson => this._addPerson;
        public ReactiveCommand<object> AddPet => this._addPet;
        public ReactiveCommand<object> Collapse => this._collapse;

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
