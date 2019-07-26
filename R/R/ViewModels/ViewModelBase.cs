using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace R.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService)
        {
        }
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }
        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }
        public virtual void Destroy()
        {
        }
        //public async virtual Task<bool> DisplayAlertAsync(string title, string message, string acceptButton, string cancelButton)
        //{
        //    return await DisplayAlertAsync(title, message, acceptButton, cancelButton);
        //}
        //public virtual async Task DisplayAlertAsync(string title, string message, string cancelButton)
        //{
        //    await DisplayAlertAsync(title, message, cancelButton);
        //}
        //public virtual Task<string> DisplayActionSheetAsync(string title, string cancelButton, string destroyButton, params string[] otherButtons)
        //{
        //    return DisplayActionSheetAsync(title, cancelButton, destroyButton, otherButtons);
        //}
        //public virtual async Task DisplayActionSheetAsync(string title, params IActionSheetButton[] buttons)
        //{
        //    await DisplayActionSheetAsync(title, buttons);
        //}
    }
}
