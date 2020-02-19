using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using WpfPrismPractice.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfPrismPractice.ViewModels
{
    public class SandboxViewModel : BindableBase
    {
        private Box _box = null;

        // ViewModel => Model
        // Model => ViewModel
        public ReactiveProperty<string> BoxName { get; }

        public ReactiveCollection<BoxContentViewModel> BoxContents { get; }

        public DelegateCommand RewriteBoxNameFromVMCommand { get; }
        public DelegateCommand RewriteBoxNameFromMCommand { get; }

        public SandboxViewModel()
        {
            _box = new Box
            {
                Name = "SpecialBox",
            };

            BoxName = _box.ToReactivePropertyAsSynchronized(x => x.Name);
            #region ※その他の初期化方法
            //BoxName = _box
            //    .ObserveProperty(x => x.Name)
            //    .ToReactiveProperty();

            //BoxName = ReactiveProperty.FromObject(
            //    _box,
            //    x => x.Name);
            #endregion


            BoxContents = new ReactiveCollection<BoxContentViewModel>();
            foreach (var content in _box.Contents)
            {
                BoxContents.Add(new BoxContentViewModel(content));
            }
            BoxContents
                .ObserveElementObservableProperty(x => x.IsChecked)
                .Subscribe(x =>
                {
                    System.Diagnostics.Debug.Print("sub");
                });

            RewriteBoxNameFromVMCommand = new DelegateCommand(() =>
            {
                BoxName.Value = "Rewrited from vm";
            });

            RewriteBoxNameFromMCommand = new DelegateCommand(() =>
            {
                _box.Name = "Rewrited from model";
            });
        }
    }
}
