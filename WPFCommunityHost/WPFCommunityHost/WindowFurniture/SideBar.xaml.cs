using CommunityClassLibraryInterfaces.UI;
using CommunityViewModels;
using GeneralWPFControlLibraryViewModels;
using System.Windows.Controls;

namespace WPFCommunityHost
{
	/// <summary>
	/// Interaction logic for SideBar.xaml
	/// </summary>
	public partial class SideBar : UserControl
	{
		public SideBar()
		{
			InitializeComponent();
			//DataContext = SideBarViewModel.Instance;
		}

		//private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		//{
		//	if(e.AddedItems.Count>0 && e.AddedItems[0] is IDwellerViewModel vm)
		//	{
		//		//DwellerInfoBlockViewModel.Instance.Dweller = vm.Dweller;
		//		DwellerInfoBlockViewModel.Instance.Dweller = vm;

		//		// Open a new Dweller Info Window
		//		//new PopupWindow(new ItemHostPanelViewModel(vm)).Show();
		//		PopupWindow.ShowViewModel(vm, null, () =>
		//		{
		//			//DwellerInfoBlockViewModel.Instance.Unhook();
		//			return null;
		//		});

		//	}
		//}
	}
}
