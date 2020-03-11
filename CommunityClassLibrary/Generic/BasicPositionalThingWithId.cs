using CommunityClassLibraryInterfaces.Locations;
using CommunityClassLibrary;
using GeneralWPFControlLibraryInterfaces;
using System;

namespace CommunityClassLibrary
{
	public abstract class BasicPositionalThingWithId : BasicThingWithId, IPositionalObjectWithInterpolation
	{
		private readonly IPosition _position; // = new MutablePosition();

		public IPosition Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position.Value = value.Value;
				Changed?.Invoke(this, this);
			}
		}

		public virtual void MoveTo(IPosition position)
		{
			Position.Value = position.Value;
		}

		public event EventHandler<IPositionalObject> Changed;

		public BasicPositionalThingWithId(string name, IPosition position) : base(name)
		{
			_position = position;
		}

	}
}
