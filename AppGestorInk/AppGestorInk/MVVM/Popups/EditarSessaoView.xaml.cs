using AppGestorInk.MVVM.Models;
using AppGestorInk.MVVM.ViewModels;
using Syncfusion.Maui.Buttons;

namespace AppGestorInk.MVVM.Popups;

public partial class EditarSessaoView : ContentPage
{
	public EditarSessaoView(EditarSessaoViewModel editarSessaoView)
	{
		InitializeComponent();
        BindingContext = editarSessaoView;
        
    }
    private async void SfSwitch_StateChanged(object sender, SwitchStateChangedEventArgs e)
    {
        if (BindingContext is EditarSessaoViewModel viewModel)
        {
            bool? newValue = e.NewValue;
            if (newValue is true)
            {
                viewModel.Sessao.statusSessao = StatusSessao.Finalizada;
            }
        }

    }
    private void DatePicker_SelectionChanged(object sender, Syncfusion.Maui.Picker.DateTimePickerSelectionChangedEventArgs e)
    {
        if (e.NewValue != null)
        {
            DateTime selectedDate = (DateTime)e.NewValue;

            var viewModel = (EditarSessaoViewModel)BindingContext;
            viewModel.Sessao.Data = selectedDate; // Atualiza a data selecionada
        }
    }
    private void pickerButton_Clicked(object sender, EventArgs e)
    {
        this.DatePicker.IsOpen = true;
    }
    private async void EditorWithoutBorder_Unfocused(object sender, FocusEventArgs e)
    {

        BorderDescricao.Stroke = Colors.LightGray;
        BorderDescricao.BackgroundColor = Colors.LightGray;
    }

    private async void EditorWithoutBorder_Focused(object sender, FocusEventArgs e)
    {
        BorderDescricao.Stroke = Color.FromArgb("#4C007D");
        BorderDescricao.BackgroundColor = Color.FromArgb("#4C007D");
    }

    private async void EntryWithoutBorder_Unfocused(object sender, FocusEventArgs e)
    {
        BorderNome.Stroke = Colors.LightGray;
        BorderNome.BackgroundColor = Colors.LightGray;
    }

    private async void EntryWithoutBorder_Focused(object sender, FocusEventArgs e)
    {
        BorderNome.Stroke = Color.FromArgb("#4C007D");
        BorderNome.BackgroundColor = Color.FromArgb("#4C007D");
    }

    private void Label_Focused(object sender, FocusEventArgs e)
    {
        BorderDate.Stroke = Color.FromArgb("#4C007D");
        BorderDate.BackgroundColor = Color.FromArgb("#4C007D");
    }

    private void Label_Unfocused(object sender, FocusEventArgs e)
    {
        BorderDate.Stroke = Colors.LightGray;
        BorderDate.BackgroundColor = Colors.LightGray;
    }
    private void EntryWithoutBorder_Focused_1(object sender, FocusEventArgs e)
    {
        BorderNomeCliente.Stroke = Color.FromArgb("#4C007D");
        BorderNomeCliente.BackgroundColor = Color.FromArgb("#4C007D");
    }

    private void EntryWithoutBorder_Unfocused_1(object sender, FocusEventArgs e)
    {
        BorderNomeCliente.Stroke = Colors.LightGray;
        BorderNomeCliente.BackgroundColor = Colors.LightGray;
    }

    
}