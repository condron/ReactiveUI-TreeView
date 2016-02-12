using System;
using System.Collections.Generic;
using ReactiveUI;

namespace TreeViewInheritedItem
{

    public abstract class TreeItem : ReactiveObject
    {
        private readonly Type _viewModelType;

        protected TreeItem( IEnumerable<TreeItem> children = null)
        {

            Children = new ReactiveList<TreeItem>(children ?? new ReactiveList<TreeItem>());
        }

        public abstract object ViewModel { get; }
        public ReactiveList<TreeItem> Children { get; }
    }
}
