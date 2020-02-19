using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace WpfPrismPractice.Models
{
    public class BoxContent
    {
        public bool IsChecked { get; set; }

        public BoxContent(bool isChecked = false)
        {
            IsChecked = isChecked;
        }
    }

    public class BoxContentViewModel : BindableBase, IDisposable
    {
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public ReactiveProperty<bool> IsChecked { get; }

        public BoxContentViewModel(BoxContent content)
        {
            IsChecked = ReactiveProperty.FromObject(content, x => x.IsChecked)
                .AddTo(Disposable);
        }

        public void Dispose() => Disposable.Dispose();
    }
}
