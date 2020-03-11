using Community.Tests.ClassLibrary.BaseClasses;
using CommunityClassLibrary.Locations;
using GeneralWPFControlLibraryInterfaces;
using Moq;
using TechTalk.SpecFlow;

namespace Community.Tests.ClassLibrary.Thoughts
{
	[Binding]
	[Scope(Feature = "Need For Food")]
	public class NeedForFoodSteps: BasicBuildingStepsBase
	{
		BasicCafe cafe;

		[Given(@"I have a new cafe at \((.*), (.*)\)")]
		public void GivenIHaveANewCafeAt(double x, double y)
		{
			var pos = new Mock<IPosition>();
			pos.SetupGet(p => p.Value).Returns(new System.Windows.Point(x, y));
			building = cafe = new BasicCafe(pos.Object);
			Community.Add(cafe);
		}



	}
}
