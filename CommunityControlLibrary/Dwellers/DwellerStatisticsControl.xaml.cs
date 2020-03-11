using CommunityClassLibrary.IoC;
using CommunityClassLibraryInterfaces.UI;
using CommunityViewModels;
using GeneralWPFControlLibrary;
using GeneralWPFControlLibraryInterfaces;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CommunityControlLibrary.Dwellers
{
	/// <summary>
	/// Interaction logic for DwellerStatisticsControl.xaml
	/// </summary>
	public partial class DwellerStatisticsControl : UserControl
	{
		PopupWindowManager popupManager = new PopupWindowManager();
		public IList<IViewModelBase> Items { get; set; } = new List<IViewModelBase>();
		public string Title { get; set; }
		public IDictionary<IDwellerViewModel, DwellerInfoBlockViewModel> DwellerInfoBlockViewModels { get; } = new Dictionary<IDwellerViewModel, DwellerInfoBlockViewModel>();
		private IDwellerViewModel current;

		DwellerStatisticsViewModel Model;
		public DwellerStatisticsControl()
		{
			InitializeComponent();
			DataContext = Model = IoCContainer.Resolve<DwellerStatisticsViewModel>();
		}

		/// <summary>
		/// This function handles popup windows for dweller info controls
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems.Count > 0 && e.AddedItems[0] is IDwellerViewModel vm)
			{
				current = vm;
				PossiblyShowCurrent();
				//popupManager.PossiblyShow(vm.ToString(), vm, () => new DwellerInfoBlockViewModel { Dweller=vm });
			}
		}

		private void PossiblyShowCurrent()
		{
			popupManager.AddViewModel(current)?.Show();



			// do we already have this
			//if (!DwellerInfoBlockViewModels.ContainsKey(vm))
			//{
			//	// we don't already have this window open
			//	var dibvm = new DwellerInfoBlockViewModel { Dweller = vm };
			//	DwellerInfoBlockViewModels.Add(vm, dibvm);
			//	Items.Add(dibvm);




			//	//PopupWindow.ShowViewModel(dibvm, null, () =>
			//	//{
			//	//	// Remove from the list
			//	//	dibvm.Unhook();
			//	//	DwellerInfoBlockViewModels.Remove(vm);
			//	//	return null;
			//	//});
			//}
		}

		private void DataGrid_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			PossiblyShowCurrent();
		}
	}
}
