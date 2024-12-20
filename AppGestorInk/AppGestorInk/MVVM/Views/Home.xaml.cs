using AppGestorInk.MVVM.ViewModels;
using Syncfusion.Maui.Popup;

namespace AppGestorInk.MVVM.Views
{
    public partial class Home : ContentPage
    {
        public Home(HomeViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            try
            {
                if (sender is Image image && BindingContext is HomeViewModel viewModel)
                {
                    string imageSource = image.Source.ToString();
                    viewModel.OpenPopup(); // Chama o m�todo no ViewModel com o caminho da imagem
                }
            }
            catch (Exception ex)
            {
                // Trate qualquer exce��o aqui (como log de erro)
            }
        }
    }
}
