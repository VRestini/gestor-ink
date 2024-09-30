
using AppGestorInk.MVVM.ViewModels;
using Syncfusion.Maui.Calendar;
using Syncfusion.Maui.Scheduler;

namespace AppGestorInk.MVVM.Views;

public partial class Agenda : ContentPage
{
   
    public Agenda(AgendaViewModel agendaViewModel)
    {
        InitializeComponent();
        BindingContext = agendaViewModel;
    }
    

}