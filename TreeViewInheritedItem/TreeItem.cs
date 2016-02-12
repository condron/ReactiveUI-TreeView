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

        private TreeItem _parent;

        protected TreeItem(IEnumerable<TreeItem> children = null)
        {

            Children = new ReactiveList<TreeItem>();
            if (children == null) return;
            foreach (var child in children)
            {
                AddChild(child);
            }
        }

        public abstract object ViewModel { get; }
        public ReactiveList<TreeItem> Children { get; }

        public void AddChild(TreeItem child)
        {
            child._parent = this;
            Children.Add(child);
        }

        public void ExpandPath()
        {
            IsExpanded = true;
            _parent?.ExpandPath();
        }
        public void CollapsePath()
        {
            IsExpanded = false;
            _parent?.CollapsePath();
        }
    }
}
