using GeneralWPFControlLibraryInterfaces;
using System;
using System.Collections.Generic;

namespace CommunityClassLibraryInterfaces.Actions
{
	public enum ActionType
	{
		Unknown,
		Move,
		Work,
		Sleep,
		Eat,
		EnterBuilding
	}


	public interface IActionManager: IIdAndName
	{
		IAction GetAction(int index);
		void Push(IAction action);
		IAction Pop();
		int Count { get; }
		IList<IAction> Actions { get; }
		void Clear();

		void Remove(ActionType actionType);
		IAction FindOne(ActionType actionType);
		bool ContainsActionType(ActionType actionType);

		event EventHandler<IActionManager> Updated;
	}
}
