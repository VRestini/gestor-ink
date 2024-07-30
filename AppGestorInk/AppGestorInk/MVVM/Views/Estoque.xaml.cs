using AppGestorInk;
using AppGestorInk.MVVM.Models;
using AppGestorInk.MVVM.Popups;
namespace GestorInk.MVVM.Views;

public partial class Estoque : ContentPage
{
    public Estoque()
    {
        InitializeComponent();
    }
    public void ListarProdutos()
    {
        var produto = App.ProdutoServiceBD.ListarProduto().Result;
        ProdutoCV.ItemsSource = produto;
    }
    private async void OnCounterClicked(object sender, EventArgs e)
    {
        try
        {
            var produto = new Produto
            {
                Name = await DisplayPromptAsync("Nome", "Digite o nome:", "Ok", "Cancelar"),
                Descricao = await DisplayPromptAsync("Descrição", "Digite a descrição:", "Ok", "Cancelar"),
            };
            await App.ProdutoServiceBD.CriarProduto(produto);
            await DisplayAlert("Sucesso", "Produto criado", "Ok");
            ListarProdutos();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "Ok");
        }

    }
    private void ProdutoCV_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var produto = e.CurrentSelection.FirstOrDefault() as Produto;
        Navigation.PushAsync(new EditarProduto(produto));
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new Teste());
    }
}