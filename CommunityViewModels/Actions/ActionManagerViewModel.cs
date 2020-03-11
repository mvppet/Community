using CommunityClassLibrary.Actions;
using CommunityClassLibrary.Locations;
using CommunityClassLibraryInterfaces.Actions;
using GeneralWPFControlLibraryViewModels;
using System;
using System.Collections.Generic;

namespace CommunityViewModels.Actions
{
	public class ActionManagerViewModel: ViewModelBase, IActionManager
	{
		public IActionManager ActionManager { get; private set; }

		#region IActionManager wrapper
		public int Count => ActionManager.Count;
		public IList<IAction> Actions => ActionManager.Actions;
		public void Clear() => ActionManager.Clear();
		public bool ContainsActionType(ActionType actionType) => ActionManager.ContainsActionType(actionType);
		public IAction FindOne(ActionType actionType) => ActionManager.FindOne(actionType);
		public IAction GetAction(int index) => ActionManager.GetAction(index);
		public IAction Pop() => ActionManager.Pop();
		public void Push(IAction action) => ActionManager.Push(action);
		public void Remove(ActionType actionType) => ActionManager.Remove(actionType);
		public event EventHandler<IActionManager> Updated
		{
			add
			{
				ActionManager.Updated += value;
			}

			remove
			{
				ActionManager.Updated -= value;
			}
		}
		#endregion

		public ActionManagerViewModel()
		{
			if(InDesignMode)
			{
				CreateViewtimeModel();
			}
		}

		public ActionManagerViewModel(IActionManager model) : base(model)
		{
			ActionManager = model;
			model.Updated += ActionManager_Updated;
		}

		private void CreateViewtimeModel()
		{
			ActionManager = new BasicActionManager();
			ActionManager.Updated += ActionManager_Updated;
			ActionManager.Push(new BasicMovementAction(null, new BasicPosition(1, 2)));
			ActionManager.Push(new BasicMovementAction(null, new BasicPosition(2, 3)));
			ActionManager.Push(new BasicMovementAction(null, new BasicPosition(3, 4)));
		}

		private void ActionManager_Updated(object sender, IActionManager e)
		{
			NotifyPropertyChanged(() => ActionManager.Actions);
		}
	}
}
