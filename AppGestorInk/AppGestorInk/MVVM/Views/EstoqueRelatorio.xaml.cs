using AppGestorInk.MVVM.ViewModels;
using AppGestorInk.Services;

namespace AppGestorInk.MVVM.Views;

public partial class EstoqueRelatorio : ContentPage
{
	private readonly IServiceItem _serviceItem;
	public EstoqueRelatorio(RelatorioEstoqueViewModel relatorioEstoqueViewModel, IServiceItem serviceItem)
	{
		InitializeComponent();
		_serviceItem = serviceItem;
		BindingContext = relatorioEstoqueViewModel;

    }

    
}