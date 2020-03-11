using CommunityViewModels.Actions;
using System.Windows.Controls;

namespace CommunityControlLibrary.Actions
{
	/// <summary>
	/// Interaction logic for ActionManagerControl.xaml
	/// </summary>
	public partial class ActionManagerControl : UserControl
	{
		public ActionManagerControl()
		{
			InitializeComponent();

			if(DataContext is ActionManagerViewModel vm)
			{
				// we have the right viewmodel. Hook into it
			}
		}
	}
}
