﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityClassLibraryInterfaces
{
	public interface IBirthday
	{
		DateTime Born { get; }
		double Age { get; }
		double AgeRounded { get; }
	}
}
