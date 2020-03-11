using CommunityClassLibraryInterfaces;
using CommunityClassLibraryInterfaces.Actions;
using CommunityClassLibrary.Comparers;
using CommunityClassLibrary.VariablesProcessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommunityClassLibrary.Actions
{
	public class BasicActionManager : BasicIdAndNameModel, IActionManager
	{
		private static IComparer<double> comparer = new DuplicateKeyComparer<double>(true);
		private static object lockObject = new object();
		//private IDictionary<ActionType, IAction> actions = new Dictionary<ActionType, IAction>();
		private SortedList<double, IAction> actionList = new SortedList<double, IAction>(comparer);

		public event EventHandler<IActionManager> Updated;

		public IList<IAction> Actions => actionList.Values;
		public int Count => actionList.Count;
		private void NotifyChange() => Updated?.Invoke(this, this);
		//public virtual void RemoveAction(ActionType actionType) => actions.Remove(actionType);

		public bool ContainsActionType(ActionType actionType)
		{
			return Actions.FirstOrDefault(a => a.ActionType == ActionType.Move) != null;
		}

		public virtual IAction GetAction(int index) => Actions[index];

		public void Remove(ActionType actionType)
		{
			lock (lockObject)
			{
				SortedList<double, IAction> newList = new SortedList<double, IAction>(comparer);
				foreach(var action in actionList.Values)
				{
					if(action.ActionType!=actionType)
					{
						newList.Add(action.Priority.Value, action);
					}
				}
				actionList = newList;
				NotifyChange();
			}
		}



		/// <summary>
		/// Add this action, but put it where it needs to be
		/// </summary>
		/// <param name="action"></param>
		public virtual void Push(IAction action)
		{
			if (action != null)
			{
				actionList.Add(action.Priority.Value, action);

				//// if so, does our new action have a higher priority
				//if (action.Priority?.Value < existing?.Priority.Value) return;

				//// seems ok to add
				//actions[action.ActionType] = action;


				NotifyChange();

			}
		}

		/// <summary>
		/// Take the item at the top of the list
		/// </summary>
		/// <returns></returns>
		public virtual IAction Pop()
		{
			IAction retval = null;
			lock(lockObject)
			{
				if(Count>0)
				{
					retval = actionList.Values[0];
					actionList.RemoveAt(0);
				}
				NotifyChange();
			}
			return retval;
		}


		public virtual void Clear()
		{
			lock (lockObject)
			{
				actionList.Clear();
				NotifyChange();
			}
		}

		public override string ToString()
		{
			StringBuilder retval = new StringBuilder(Count);
			retval.Append(" Action");
			switch(Count)
			{
				case 0:
					retval.Append('s');
					break;
				case 1:
					break;
				default:
					retval.Append($"s: Top Priority of {Actions[0].Priority.ToString()} is \"{Actions[0]}\"");
					break;
			}



			return retval.ToString();
		}

		public IAction FindOne(ActionType actionType)
		{
			return Actions.FirstOrDefault(a=>a.ActionType == actionType);
		}
	}
}
