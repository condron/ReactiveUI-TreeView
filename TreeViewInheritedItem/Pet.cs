namespace TreeViewInheritedItem
{
    public class Pet : TreeItem
    {
        public string Name { get; }

        public Pet(string name)
        {
            Name = name;
        }
        public override object ViewModel => this;
    }
}
