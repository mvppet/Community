using CommunityClassLibraryInterfaces.Actions;
using CommunityClassLibraryInterfaces.Priorities;
using CommunityClassLibraryInterfaces.Thoughts;
using GeneralWPFControlLibraryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityClassLibrary.Actions
{
	public abstract class ActionBase: BasicThingWithId, IAction
	{
		public ActionType ActionType { get; }
		public IThought InitiatingThought { get; }
		public IPercent Priority { get; }
		public IPositionalObject Subject => throw new System.NotImplementedException();

		public abstract void AffectObject(IPositionalObject obj);

		public ActionBase(IThought initiatingThought, ActionType actionType, IPercent priority) : base(actionType.ToString())
		{
			InitiatingThought = initiatingThought;
			ActionType = actionType;
			Priority = priority;
		}

	}
}
