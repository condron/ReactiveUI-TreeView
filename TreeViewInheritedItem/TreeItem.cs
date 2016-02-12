using System;
using System.Collections.Generic;
using ReactiveUI;

namespace TreeViewInheritedItem
{

    public abstract class TreeItem : ReactiveObject
    {
        private readonly Type _viewModelType;

        bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { this.RaiseAndSetIfChanged(ref _isExpanded, value); }
        }

        bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { this.RaiseAndSetIfChanged(ref _isSelected, value); }
        }
     

        protected TreeItem( IEnumerable<TreeItem> children = null)
        {

            Children = new ReactiveList<TreeItem>(children ?? new ReactiveList<TreeItem>());
        }

        public abstract object ViewModel { get; }
        public ReactiveList<TreeItem> Children { get; }
    }
}
