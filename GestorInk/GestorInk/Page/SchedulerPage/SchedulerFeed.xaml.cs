using GestorInk.ViewModel.ViewModelScheduler;

namespace GestorInk.Page.SchedulerPage;

public partial class SchedulerFeed : ContentPage
{
	public SchedulerFeed(SchedulerFeedVM schedulerFeedVM)
	{
		InitializeComponent();
		BindingContext = schedulerFeedVM;
	}
}