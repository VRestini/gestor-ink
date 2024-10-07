
using AppGestorInk.MVVM.ViewModels;
using Syncfusion.Maui.Calendar;

using System.Runtime.CompilerServices;

namespace AppGestorInk.MVVM.Views;

public partial class Agenda : ContentPage
{

    public CalendarTextStyle TextStyle { get; set; }
    public Agenda(AgendaViewModel agendaViewModel)
    {

        InitializeComponent();
        BindingContext = agendaViewModel;
        
        CalendarTextStyle textStyle = new CalendarTextStyle()
        {
            TextColor = Colors.White,
        };
        this.MyCalendar.MonthView.TextStyle = textStyle;
        this.MyCalendar.YearView.TextStyle = textStyle;
        this.MyCalendar.HeaderView.TextStyle = textStyle;
        this.MyCalendar.SelectionChanged += OnCalendarSelectionChanged;
    }

    private async void OnCalendarSelectionChanged(object sender, Syncfusion.Maui.Calendar.CalendarSelectionChangedEventArgs e)
    {
        if (e.NewValue != null)
        {
            DateTime selectedDate = (DateTime)e.NewValue;

            var viewModel = (AgendaViewModel)BindingContext;
            viewModel.SelectedDate = selectedDate; // Atualiza a data selecionada

            // Executa o comando para buscar as sessões pela data
            await viewModel.GetSessaoByDateCommand.ExecuteAsync(null);
        }
    }


}