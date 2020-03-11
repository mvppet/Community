using CommunityClassLibrary.IoC;
using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.UI;
using CommunityViewModels.Commands;
using GeneralWPFControlLibraryViewModels;
using System.Collections.Generic;

namespace CommunityViewModels
{
	public class DwellerStatisticsViewModel: ViewModelBase
	{
		private ICommunityViewModel communityViewModel { get; } = IoCContainer.Resolve<ICommunityViewModel>();
		//public static DwellerStatisticsViewModel Instance { get; } = new DwellerStatisticsViewModel();

		public IDwellerCommandProcessor NewDwellerCommand => communityViewModel.DwellerCommandProcessor;
		public IList<IDwellerViewModel> DwellerViewModels => communityViewModel.DwellerViewModels;

	}
}
