using CommunityClassLibraryInterfaces.UI;
using System.Windows.Controls;

namespace CommunityControlLibrary.Dwellers
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class BasicDwellerInfoTile2 : UserControl
    {
		public IDwellerViewModel Dweller { get; }

		public BasicDwellerInfoTile2(IDwellerViewModel dweller)
        {
            InitializeComponent();
			Dweller = dweller;
        }
    }
}
