using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TheNewYorkTimes
{
	public class PullToRefreshViewModel : ViewModelBase
	{
		// Long task to handler
		public delegate void LoadWebService ();
		private event LoadWebService longRunningTask;
		public LoadWebService LongRunningTask {
			get {
				return longRunningTask;
			}
			set { 
				longRunningTask = value;
			}
		}

		// Local variables
		private ObservableCollection<NewItem> _items =  new ObservableCollection<NewItem>(); 
		private bool _isBusy;

		// Commands
		private DelegateCommand _loadCommand;

		public ObservableCollection<NewItem> Items
		{
			get { return _items; }
		}

		public PullToRefreshViewModel()
		{
		}

		public bool IsBusy
		{
			get { 
				return _isBusy;
			}

			set
			{
				_isBusy = value;
				RaisePropertyChanged();
			}
		}

		public ICommand LoadCommand
		{
			get {
				return _loadCommand ?? (_loadCommand = new DelegateCommand(LoadCommandExecute));
			}
		}

		private void LoadCommandExecute()
		{
			if (IsBusy) {
				return;
			}

			IsBusy = true;

			if (LongRunningTask != null) {
				LongRunningTask ();
			}

			IsBusy = false;
		}
	}
}
