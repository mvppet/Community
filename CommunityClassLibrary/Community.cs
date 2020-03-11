using CommunityClassLibraryInterfaces.Dwellers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Locations;
using System;
using System.Text;
using GeneralWPFControlLibraryInterfaces;
using System.Windows;
using CommunityClassLibrary;

namespace CommunityClassLibrary
{
	public class Community : ICommunity
	{
		// other stuff
		//public DateTime Started { get; } = DateTime.Now;
		//private StringBuilder _sbEcho = new StringBuilder();
		public IList<IRoamingDweller> Dwellers { get; } = new ObservableCollection<IRoamingDweller>();
		public IList<IHome> Homes { get; } = new ObservableCollection<IHome>();
		public IList<ICafe> Cafes { get; } = new ObservableCollection<ICafe>();
		public IList<IWorkplace> Workplaces { get; } = new ObservableCollection<IWorkplace>();
		//public static ICommunity Instance { get; } = new Community();
		public int Iteration { get; private set; }
		private ITimer lifeTimer;

		public Community()
		{
			lifeTimer = new SimpleTimer(100);
			lifeTimer.Elapsed += LifeTimer_Elapsed;
		}

		private void LifeTimer_Elapsed(object sender, EventArgs e)
		{
			++Iteration;
			lock(Dwellers) foreach(var d in Dwellers)
			{
				d.LiveLifeFrame(this);
			}
		}

		public void Add(IRoamingDweller dweller)
		{
			dweller.Position.Changed += (sender, e) => ProcessDwellerMovement(dweller, sender as IMutableVariable<Point>);
			lock (Dwellers) Dwellers.Add(dweller);
		}

		/// <summary>
		/// Process a change in dweller movement
		/// </summary>
		/// <param name="dweller"></param>
		/// <param name="newLocation"></param>
		private void ProcessDwellerMovement(IDweller dweller, IMutableVariable<Point> newLocation)
		{
			// are we already in something? If so, then exit it if our new location is different to the thing
			if(newLocation.Value != dweller.InsideBuilding?.Position?.Value)
			{
				// exit the object we're inside
				dweller.ExitBuilding();
			}

			// are we now entering an object?
			//foreach (var home in Homes) CheckNewLocation(dweller, home);
			//foreach (var workplace in Workplaces) CheckNewLocation(dweller, workplace);
			//foreach (var cafe in Cafes) CheckNewLocation(dweller, cafe);

		}

		//private void CheckNewLocation(IDweller dweller, IBuilding obj)
		//{
		//	if (dweller.Position.Value == obj.Position.Value)
		//	{
		//		// yep
		//		dweller.EnterBuilding(obj);
		//	}
		//}

		public void Add(IBuilding building)
		{
			switch(building)
			{
				case IHome home:				
					Homes.Add(home);
					break;

				case IWorkplace workplace:
					Workplaces.Add(workplace);
					break;

				case ICafe cafe:
					Cafes.Add(cafe);
					break;
			}
		}

		public ICafe FindNearestCafe(Point point) => FindBuilding(Cafes, point);
		public IHome FindNearestHome(Point point) => FindBuilding(Homes, point);
		public IWorkplace FindNearestWorkplace(Point point) => FindBuilding(Workplaces, point);

		private T FindBuilding<T>(IList<T> buildings, Point point) where T : IBuilding
		{
			int buildingCount = buildings?.Count ?? 0;
			switch(buildingCount)
			{
				case 0:
					throw new ArgumentOutOfRangeException("No buildings in the list to choose from");
				case 1:
					return buildings[0];
				default:
					// this will need calculation
					return NearestOfMany(buildings, point, buildingCount);
			}

		}

		private T NearestOfMany<T>(IList<T> buildings, Point point, int buildingCount) where T: IBuilding
		{
			T retval = default(T);
			double shortest = double.MaxValue;

			foreach(T building in buildings)
			{
				double distanceSquared = Math.Pow(building.Position.Value.X - point.X, 2) + Math.Pow(building.Position.Value.Y - point.Y, 2);

				if(distanceSquared < shortest)
				{
					retval = building;
					shortest = distanceSquared;
				}
			}

			return retval;
		}


		public void Clear()
		{
			lock (Dwellers) Dwellers.Clear();
			Homes.Clear();
			Cafes.Clear();
			Workplaces.Clear();
		}
	}
}
