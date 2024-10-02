
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

    private async void OnCalendarSelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
    {
        // Verifica se há uma data selecionada
        if (e.NewValue != null)
        {
            DateTime selectedDate = (DateTime)e.NewValue;
            
            var viewModel = (AgendaViewModel)BindingContext;
            viewModel.SelectedDate = selectedDate;
            await viewModel.GetAllSessaoCommand.ExecuteAsync(selectedDate);

            //await DisplayAlert("Data Selecionada", $"Você selecionou: {viewModel.SelectedDate:dd/MM/yyyy}", "OK");
        }
    }

}