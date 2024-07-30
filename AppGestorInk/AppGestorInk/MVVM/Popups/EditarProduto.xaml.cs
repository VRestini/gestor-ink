using AppGestorInk.MVVM.Models;
using CommunityToolkit.Maui.Views;
namespace AppGestorInk.MVVM.Popups;

public partial class EditarProduto : Popup
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