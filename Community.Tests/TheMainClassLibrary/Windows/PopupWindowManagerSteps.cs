using GeneralWPFControlLibrary;
using GeneralWPFControlLibraryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TechTalk.SpecFlow;

namespace Community.Tests.TheMainClassLibrary.Windows
{
	[Binding]
    public class PopupWindowManagerSteps
    {
		IPopupWindowManager windowManager;
		IPopupWindow popupWindow;
		IViewModelBase viewModel;

		[Given(@"I have a ViewModel for the Popup Window Manager with ID (.*)")]
		public void GivenIHaveAViewModelForThePopupWindowManagerWithID(int id)
		{
			Mock<IViewModelBase> mockVm = new Mock<IViewModelBase>(MockBehavior.Strict);
			mockVm.SetupGet(vm => vm.Id).Returns(id);
			mockVm.SetupGet(vm => vm.Name).Returns(null as string);
			viewModel = mockVm.Object;
		}

		[When(@"I create the Popup Window from the View Model")]
		public void WhenICreateThePopupWindowFromTheViewModel()
		{
			popupWindow = new PopupWindow(viewModel);

			//var winThread = new Thread(() =>
			//{
			//	popupWindow = new PopupWindow(viewModel);
			//	popupWindow.OnPopupWindowClosed += (s, e) => popupWindow.Dispatcher.InvokeShutdown();

			//	System.Windows.Threading.Dispatcher.Run();
			//});

			//winThread.SetApartmentState(ApartmentState.STA);
			//winThread.Start();


		}

		//[Then(@"the Window should be formed using the View Model with id (.*)")]
		//public void ThenTheWindowShouldBeFormedUsingTheViewModelWithId(int id)
		//{
		//	Assert.AreEqual(id, window.ViewModel.Id);
		//}

		[Given(@"I have a Popup Window Manager")]
		public void GivenIHaveAPopupWindowManager()
		{
			StartSTATask(() =>
			{
				windowManager = new PopupWindowManager();
			}).Wait();

		}

		[When(@"I add the ViewModel to the Popup Window Manager")]
		public void WhenIAddTheViewModelToThePopupWindowManager()
		{
			var win = windowManager.AddViewModel(viewModel);
			Assert.IsNotNull(win);
		}

		[Then(@"the Popup Window count should be (.*)")]
		public void ThenThePopupWindowCountShouldBe(int count)
		{
			Assert.AreEqual(count, windowManager.Count);
		}


		[When(@"the Popup Window should have ID (.*)")]
		public void WhenThePopupWindowShouldHaveID(int id)
		{
			Assert.AreEqual(id, popupWindow.Id);
		}


		[Then(@"Popup Window Manager at index (.*) should have ID (.*)")]
		public void ThenPopupWindowManagerAtIndexShouldHaveID(int index, int id)
		{
			Assert.AreEqual(id, windowManager[index].Id);
		}







		public static Task StartSTATask(Action action)
		{
			var tcs = new TaskCompletionSource<object>();
			var thread = new Thread(() =>
			{
				try
				{
					action();
					tcs.SetResult(new object());
				}
				catch (Exception e)
				{
					tcs.SetException(e);
				}
			});
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			return tcs.Task;
		}

	}
}
