using System.Collections.Generic;

namespace TreeViewInheritedItem
{
    public class Person : TreeItem
    {
        public string Name { get; set; }
        public Person(string name, IEnumerable<TreeItem> children = null)
            : base(children)
        {
            Name = name;
        }
        public override object ViewModel => this;
    }
}
