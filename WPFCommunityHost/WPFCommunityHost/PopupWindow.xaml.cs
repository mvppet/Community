using CommunityClassLibraryInterfaces.UI;
using CommunityViewModels;
using GeneralWPFControlLibraryInterfaces;
using GeneralWPFControlLibraryViewModels;
using System;
using System.Windows;

namespace WPFCommunityHost
{
	/// <summary>
	/// Interaction logic for PopupWindow.xaml
	/// </summary>
	public partial class PopupWindow : Window
	{
		IViewModelList vm;

		public PopupWindow()
		{
			InitializeComponent();
			vm = DataContext as IViewModelList;
		}

		private PopupWindow(IViewModelList model, string windowTitle=null, Func<object> onClosing = null)
		{
			InitializeComponent();
			DataContext = vm = model;
			vm.Title = windowTitle ?? string.Empty;

			Closed += (s, e) => { onClosing?.Invoke(); };
		}

		public static void ShowViewModel(IViewModelBase vm, string windowTitle=null, Func<object> onClosing=null)
		{
			new PopupWindow(new ItemHostPanelViewModel(vm), windowTitle, onClosing).Show();
		}

	}
}
