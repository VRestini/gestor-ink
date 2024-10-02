
using AppGestorInk.MVVM.ViewModels;
using Syncfusion.Maui.Calendar;

using System.Runtime.CompilerServices;

namespace AppGestorInk.MVVM.Views;

public partial class Agenda : ContentPage
{

    public CalendarTextStyle TextStyle { get; set; }
    public Agenda()
    {
        InitializeComponent();
        CalendarTextStyle textStyle = new CalendarTextStyle()
        {
            TextColor = Colors.White,

        };

        this.MyCalendar.MonthView.TextStyle = textStyle;

    }


}