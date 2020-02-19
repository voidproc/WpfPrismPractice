using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPrismPractice.Models
{
    public class Box : BindableBase
    {
        // VMもしくはMから書き換える可能性がある
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                System.Diagnostics.Debug.Print($"Box.Name.set value='{value}'");
            }
        }

        private ObservableCollection<BoxContent> _contents;
        public ObservableCollection<BoxContent> Contents
        {
            get { return _contents; }
            set
            {
                SetProperty(ref _contents, value);
                System.Diagnostics.Debug.Print($"Box.Contents.set value='{value}'");
            }
        }

        public Box()
        {
            _contents = new ObservableCollection<BoxContent>();

            foreach (var _ in Enumerable.Range(0, 10))
            {
                _contents.Add(new BoxContent(true));
            }

            System.Diagnostics.Debug.Print($"{_contents.Count}");
        }
    }
}
