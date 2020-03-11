using System;
using TechTalk.SpecFlow;

namespace Community.Tests.TheCommunityClassLibrary.Locations
{
    [Binding]
    public class GeneralBuildingsSteps
    {
        [Given(@"I have a dweller who wants to enter a building")]
        public void GivenIHaveADwellerWhoWantsToEnterABuilding()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the dweller has an action to enter a building")]
        public void GivenTheDwellerHasAnActionToEnterABuilding()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the action affects the dweller")]
        public void WhenTheActionAffectsTheDweller()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the dweller should be inside the building")]
        public void ThenTheDwellerShouldBeInsideTheBuilding()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
