using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibraryInterfaces.UI;
using GeneralWPFControlLibraryInterfaces;
using GeneralWPFControlLibraryViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace CommunityViewModels
{
	public class BasicBuildingViewModel : ViewModelBase, IBuildingViewModel
	{

		public IBuilding Building { get; }

		public void MoveTo(IPosition pos) => Building.MoveTo(pos);

		public void AffectObject(IPositionalObject obj) => Building.AffectObject(obj);
		public IPosition Position => Building.Position;
		public IList<IDweller> Occupants => Building.Occupants;
		public long Id => Building.Id;
		public string Name => Building.Name;
		public Brush BuildingColor { get; protected set; }

		public double ResourceCostPerIteration { get => Building.ResourceCostPerIteration; set => Building.ResourceCostPerIteration = value; }
		public double RewardPerIteration { get => Building.RewardPerIteration; set => Building.RewardPerIteration = value; }

		private byte buildingOpacity = 100;


		public BasicBuildingViewModel(IBuilding building)
		{
			Building = building ?? throw new ArgumentNullException("building cannot be null");

			switch(building)
			{
				case IHome home:
					BuildingColor = new SolidColorBrush(Color.FromArgb(buildingOpacity, 0, 100, 0));
					break;
				case ICafe cafe:
					BuildingColor = new SolidColorBrush(Color.FromArgb(buildingOpacity, 0, 0, 100));
					break;
				case IWorkplace workplace:
					BuildingColor = new SolidColorBrush(Color.FromArgb(buildingOpacity, 100, 100, 0));
					break;

				default:
					BuildingColor = new SolidColorBrush(Color.FromArgb(buildingOpacity, 255, 0, 0));
					break;

			}

		}
		public BasicBuildingViewModel()
		{
		}
	}
}
