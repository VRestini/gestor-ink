using AppGestorInk.MVVM.Popups;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AppGestorInk.MVVM.ViewModels
{
    public partial class MenuPopupModel: ObservableObject
    {
        [RelayCommand]
        private async Task AddProduto()
        {
            var uri = $"{nameof(AddProdutoPop)}?id=0";
            await Shell.Current.GoToAsync(uri);
        }
    }
}
