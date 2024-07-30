using AppGestorInk.MVVM.Models;
namespace AppGestorInk.MVVM.Popups;

public partial class EditarProduto : ContentPage
{
	public EditarProduto(Produto produto)
	{
		InitializeComponent();
        CarregaProduto(produto);
	}
    private void CarregaProduto(Produto produto)
    {
        TXTNome.Text = produto.Name;
        TXTDescricao.Text = produto.Descricao;

    }
}