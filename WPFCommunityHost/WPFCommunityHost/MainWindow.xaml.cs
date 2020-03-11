using CommunityClassLibrary.Dwellers;
using CommunityClassLibrary.IoC;
using CommunityClassLibrary.Locations;
using CommunityClassLibrary.Thoughts;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibraryInterfaces.UI;
using CommunityControlLibrary.Dwellers;
using CommunityControlLibrary.Locations;
using CommunityViewModels;
using CommunityViewModels.Commands;
using GeneralWPFControlLibrary;
using GeneralWPFControlLibraryInterfaces;
using GeneralWPFControlLibraryViewModels;
using System;
using System.Windows;
using WPFCommunityHost.Setup;

namespace WPFCommunityHost
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//IoCSetup ioCSetup = new IoCSetup();

		//		CommunityViewModels.Commands.NewDwellerCommandProcessor cmdProc;
		private const double FoodScale = 100.0;
		private const int SizeOffset = 100;
		private IDwellerCommandProcessor cmdProc;
		private ICommunityViewModel cVm;

		public MainWindow()
		{
			// Setup
			InitializeComponent();

			IoCRegistration.Initialise();
			cVm = IoCRegistration.Resolve<ICommunityViewModel>();

			ShowDefaultwWindows();

			cmdProc = cVm.DwellerCommandProcessor;

			DataContext = cVm;

			// Connect the buttons
			cmdProc.NewDwellerCreated += DwellerCreated;
			cmdProc.NewBuildingCreated += BuildingCreated;

			// Update our bounds
			Grid_SizeChanged(null, null);

			// add some dwellers and stuff
			AddInitialHome();
			AddInitialCafe();
			AddInitialWorkplace();
			AddInitialDwellers();


		}

		private void ShowDefaultwWindows()
		{
			// Console
			cVm.Console = IoCContainer.Resolve<ConsoleWindowViewModel>();
			PopupWindow.ShowViewModel(IoCContainer.Resolve<ConsoleWindowViewModel>(), "Console");

			// Dweller info list
			PopupWindow.ShowViewModel(IoCContainer.Resolve<DwellerStatisticsViewModel>(), "Dwellers");

		}


		/// <summary>
		/// A new dweller has just been created. Set it up
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DwellerCreated(object sender, IRoamingDweller dweller)
		{
			// create a control to display the info
			BasicDwellerInfoTile infoControl = new BasicDwellerInfoTile { DataContext = new BasicDwellerViewModel(dweller) };

			// add to the animation panel
			var tile = new SimpleAnimationHostTile { PositionalObject = dweller as IPositionalObject, Control = infoControl };
			tile.ActualPositionChanged += Tile_ActualPositionChanged;
			Panel.AddControl(tile);
		}


		/// <summary>
		/// A new dweller has just been created. Set it up
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BuildingCreated(object sender, IBuilding building)
		{
			// create a control to display the info
			BasicBuildingInfoControl infoControl = new BasicBuildingInfoControl { DataContext = new BasicBuildingViewModel(building) };

			// add to the animation panel
			var tile = new SimpleAnimationHostTile { PositionalObject = building as IPositionalObject, Control = infoControl };
			tile.ActualPositionChanged += Tile_ActualPositionChanged;
			Panel.AddControl(tile);
		}

		private void Tile_ActualPositionChanged(object sender, IPositionalObject e)
		{
			if (sender is IAnimationHostTile tile)
			{
				var newX = tile.CurrentX;
				var newY = tile.CurrentY;

				var oldX = e.Position.PreviousValue.X;
				var oldY = e.Position.PreviousValue.Y;

				if (e is IDweller d)
				{
					// how much food do we take?
					double foodNeeded = Math.Sqrt(Math.Pow(oldX - newX, 2) + Math.Pow(oldY - newY, 2)) / FoodScale;
					d.UseFood(foodNeeded);


					// update the coords that the object displays

				}
				//else
				//{

				//}
			}
		}

		private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			BasicMovementThought.Bounds.Value = new Point(Panel.ActualWidth - SizeOffset, Panel.ActualHeight - SizeOffset);
		}

		private void AddInitialHome()
		{
			var building = new BasicHome("Home") { ResourceCostPerIteration = 0.1, RewardPerIteration = 1 };
			cmdProc.NewHome(building);
			building.Position.Value = new Point(50, 150);
		}

		private void AddInitialCafe()
		{
			var building = new BasicCafe("Cafe") { ResourceCostPerIteration = 0.1, RewardPerIteration = 1 };
			cmdProc.NewCafe(building);
			building.Position.Value = new Point(300, 300);
		}

		private void AddInitialWorkplace()
		{
			var building = new BasicWorkplace("Office") { ResourceCostPerIteration=0.1, RewardPerIteration=1 };
			cmdProc.NewWorkplace(building);
			building.Position.Value = new Point(650, 200);
		}

		private void AddInitialDwellers()
		{
			cmdProc.NewNormalDweller("Humblipoinds");
			cmdProc.NewNormalDweller("Andleglington");
			cmdProc.NewNormalDweller("Bomblebington");
			cmdProc.NewNormalDweller("Cartululence");
			cmdProc.NewNormalDweller("Diflongton");
			cmdProc.NewNormalDweller("Englinghton");
			cmdProc.NewNormalDweller("Friplioll");
			cmdProc.NewNormalDweller("Gupliocpil");
			cmdProc.NewNormalDweller("Injeplic");
			cmdProc.NewNormalDweller("Jundivial");
			//AddNewRoamingDweller("");

		}

		private void AddNewNormalDweller(string name)
		{
			//cmdProc.NewDweller(new RoamingDweller(CommunityViewModel.Instance, name));
			cmdProc.NewNormalDweller(name);

		}
	}
}
