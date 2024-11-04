using AppGestorInk.MVVM.ViewModels;
using Syncfusion.Maui.Calendar;
using System;

namespace AppGestorInk.MVVM.Views
{
    public partial class Agenda : ContentPage
    {
        public CalendarTextStyle TextStyle { get; set; }

        public Agenda(AgendaViewModel agendaViewModel)
        {
            InitializeComponent();

            if (agendaViewModel != null)
            {
                BindingContext = agendaViewModel;
                InitializeCalendarTextStyle();
            }
        }

        private void InitializeCalendarTextStyle()
        {
            if (MyCalendar != null)
            {
                var textStylePurple = new CalendarTextStyle { TextColor = Color.FromArgb("#4C007D")};
                var textStyle = new CalendarTextStyle { TextColor = Colors.White };
                MyCalendar.MonthView.TextStyle = textStyle;
                MyCalendar.YearView.TextStyle = textStyle;
                MyCalendar.HeaderView.TextStyle = textStyle;
                MyCalendar.TodayHighlightBrush = Color.FromArgb("#4C007D");
                MyCalendar.FooterView.TextStyle = textStyle;
                MyCalendar.MonthView = new CalendarMonthView()
                {
                    WeekendDays = new List<DayOfWeek>
                {
                    DayOfWeek.Sunday,
                    DayOfWeek.Saturday,
                },
                    TextStyle = textStyle,
                    
                    TodayTextStyle = textStyle,
                };
                  MyCalendar.SelectionChanged += OnCalendarSelectionChanged;
            }
        }

        private async void OnCalendarSelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            if (e.NewValue != null && BindingContext is AgendaViewModel viewModel)
            {
                viewModel.SelectedDate = (DateTime)e.NewValue;
                await viewModel.GetSessaoByDateCommand.ExecuteAsync(null);
            }
        }
    }
}
