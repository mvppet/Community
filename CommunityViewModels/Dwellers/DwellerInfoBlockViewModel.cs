using CommunityClassLibrary.Dwellers;
using CommunityClassLibrary.Thoughts;
using CommunityClassLibraryInterfaces.Thoughts;
using CommunityClassLibraryInterfaces.UI;
using CommunityViewModels.Actions;
using GeneralWPFControlLibraryViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CommunityViewModels
{
	public class DwellerInfoBlockViewModel : ViewModelBase
	{ 
		//public static DwellerInfoBlockViewModel Instance { get; } = new DwellerInfoBlockViewModel();
		private IDwellerViewModel _dweller;
		private IDwellerViewModel _previousDweller;
		public string ActionList { get; private set; }
		public IList<IThoughtViewModel> ThoughtList { get; private set; }
		public ActionManagerViewModel ActionManagerViewModel { get; private set; }

		public IDwellerViewModel Dweller
		{
			get => _dweller;
			set
			{
				if (value == null) throw new ArgumentNullException("Dweller cannot be null");

				//do we have a change?
				if (value.Id != _previousDweller?.Id)
				{
					// we are changing dwellers. Hook up the event handlers
					if (_previousDweller != null)
					{
						_previousDweller.Updated -= Dweller_Updated;
					}
					value.Updated += Dweller_Updated;


					_previousDweller = _dweller;
					_dweller = value;
					ActionManagerViewModel = new ActionManagerViewModel(_dweller.ActionManager);
					NotifyPropertyChanged();
				}
			}
		}

		public DwellerInfoBlockViewModel()
		{
			Application.Current.Dispatcher.Invoke(() => ThoughtList = new ObservableCollection<IThoughtViewModel>());

			//Dweller.Updated += Dweller_Updated;
			if (InDesignMode)
			{
				Dweller = new BasicDwellerViewModel(new RoamingDweller());
				Dweller.Thoughts.Add(new BasicFoodThought(Dweller.Dweller));
			}
		}

		public void Unhook()
		{
			Dweller.Updated -= Dweller_Updated;
		}

		private void Dweller_Updated(object sender, IHasThoughts e)
		{
			if (Application.Current?.Dispatcher == null)
			{
				// Our window has Gone. This happens when the window is closed, so unregister ourself
				Unhook();
				return;
			}
			bool thoughtsChanged = false;
			ActionList = _dweller.ActionManager.ToString();

			Application.Current.Dispatcher.Invoke(() => {
				foreach (var thought in _dweller.Thoughts)
				{
					var item = ThoughtList.FirstOrDefault(t => t.Thought == thought);
					if (item==null)
					{
						// thought not found: Add to list
						NewViewModel(thought);
						thoughtsChanged = true;
					}
				}
			});

			NotifyPropertyChanged(() => ActionList);
			if(thoughtsChanged) NotifyPropertyChanged(() => ThoughtList);

		}

		private void NewViewModel(IThought thought)
		{
			// add a new thought
			switch (thought)
			{
				case BasicFoodThought newThougt:
					ThoughtList.Add(new BasicFoodThoughtViewModel(thought));
					break;

				case BasicSleepThought newThougt:
					ThoughtList.Add(new BasicSleepThoughtViewModel(thought));
					break;

				case BasicMovementThought newThougt:
					ThoughtList.Add(new BasicMovementThoughtViewModel(thought));
					break;

				default:
					ThoughtList.Add(new BasicThoughtViewModel(thought));
					break;
			}
		}
	}
}
