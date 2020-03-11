using CommunityClassLibrary.Dwellers;
using CommunityClassLibrary.IoC;
using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Actions;
using CommunityClassLibraryInterfaces.Dwellers;
using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibraryInterfaces.Thoughts;
using CommunityClassLibraryInterfaces.UI;
using GeneralWPFControlLibraryInterfaces;
using GeneralWPFControlLibraryViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media;
using Unity;

namespace CommunityViewModels
{
	public class BasicDwellerViewModel : ViewModelBase, IDwellerViewModel
	{
		private static Brush HealthColour_Amazing	= new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
		private static Brush HealthColour_Fine		= new SolidColorBrush(Color.FromArgb(100, 200, 255, 200));
		private static Brush HealthColour_OK		= new SolidColorBrush(Color.FromArgb(100, 200, 255, 150));
		private static Brush HealthColour_NotGood	= new SolidColorBrush(Color.FromArgb(100, 200, 100, 0));
		private static Brush HealthColour_Bad		= new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
		private static Brush HealthColour_Dead		= new SolidColorBrush(Color.FromArgb(100, 0, 0, 0));


		public IRoamingDweller Dweller { get; }
		public double HealthOvalWidth => Dweller.Food.RoundedValue + 10;
		public double HealthOvalHeight => Dweller.Money.RoundedValue + 10;
		public Brush HealthColor
		{
			get
			{
				if (Health.IntegerValue > 95)		return HealthColour_Amazing;
				else if (Health.IntegerValue > 75)	return HealthColour_Fine;
				else if (Health.IntegerValue > 50)	return HealthColour_OK;
				else if (Health.IntegerValue > 25)	return HealthColour_NotGood;
				else if (Health.IntegerValue > 0)	return HealthColour_Bad;
				else								return HealthColour_Dead;
			}
		}

		#region Dweller wrapper
		public long Id => Dweller?.Id ?? 0;
		//public int Iteration => Dweller?.Iteration ?? 0;
		//public ICommunity Community => CommunityClassLibrary.Community.Instance;
		private readonly ICommunity _community = IoCContainer.Resolve<ICommunity>();
		public ICommunity Community { get => _community; }

		public new string Name => Dweller?.Name;
		public IBirthday Birthday => Dweller?.Birthday;
		public IPercent Health => Dweller?.Health;
		public IPercent Food => Dweller?.Food;
		public IMutableVariable<double> Money => Dweller?.Money;
		//public IPriorityFactory Priorities => Dweller?.Priorities;
		public ICollection<IThought> Thoughts => Dweller?.Thoughts;
		public IActionManager ActionManager => Dweller?.ActionManager;
		public void HaveThoughts() => Dweller?.HaveThoughts();
		public void PerformActions() => Dweller?.PerformActions();
		public void MoveTo(IPosition pos) => Dweller?.MoveTo(pos);
		public void MoveTo(IThought initiatingThought, IPosition position) => Dweller?.MoveTo(initiatingThought, position);
		public void MoveTo(IThought initiatingThought, IBuilding building) => Dweller?.MoveTo(initiatingThought, building);
		public void ActuallyMoveTo(IPosition pos) => Dweller?.ActuallyMoveTo(pos);
		public void UseFood(double foodNeeded) => Dweller?.UseFood(foodNeeded);
		public IPosition Destination => Dweller?.Destination;
		public bool IsMoving => Dweller?.IsMoving ?? false;
		public IPosition Position => Dweller.Position;
		public Mood Mood => Dweller.Mood;
		//public TimeSpan PauseForThoughts
		//{
		//	get => Dweller.PauseForThoughts;
		//	set => Dweller.PauseForThoughts = value;
		//}

		public void EnterBuilding(IBuilding building) => Dweller?.EnterBuilding(building);
		public void ExitBuilding() => Dweller?.ExitBuilding();
		public void LiveLifeFrame(ICommunity c) => Dweller?.LiveLifeFrame(c);
		public IBuilding InsideBuilding => Dweller?.InsideBuilding;
		#endregion


		[InjectionConstructor] // needed if multiple constructors
		public BasicDwellerViewModel(IRoamingDweller dweller)
		{
			Debug.Assert(dweller!=null);
			Dweller = dweller;
			Dweller.Updated += Dweller_Updated;
//			Dweller.Position.Changed += Position_Changed;
		}

		//private void Position_Changed(object sender, IMutableVariable<System.Windows.Point> e)
		//{
		//	Position.Value = e.Value;
		//}

		public event EventHandler<IHasThoughts> Updated;
		public event EventHandler<IHasThoughts> Death;

		private void Dweller_Updated(object sender, IHasThoughts e)
		{
			Refresh();
			Updated?.Invoke(this, Dweller);
		}

		// this is for design time
		public BasicDwellerViewModel()
		{
			if (InDesignMode)
			{
				Dweller = new RoamingDweller();
			}
		}


		public void Refresh()
		{
			NotifyPropertyChanged(() => Dweller);
			NotifyPropertyChanged(() => HealthColor);
			NotifyPropertyChanged(() => HealthOvalHeight);
			NotifyPropertyChanged(() => HealthOvalWidth);
		}

	}
}
