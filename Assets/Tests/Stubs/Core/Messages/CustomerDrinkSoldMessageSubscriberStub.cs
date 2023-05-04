using PubSubPub.Game.Core.Messages;
using SuperMaxim.Messaging;

namespace PubSubPub.Tests.Stubs
{
	public class CustomerDrinkSoldMessageSubscriberStub
	{
		public CustomerDrinkSoldMessageSubscriberStub(IMessenger messenger)
		{
			messenger.Subscribe<CustomerDrinkSoldMessage>(OnMessageReceived);
		}


		public CustomerDrinkSoldMessage Message { get; set; }


		private void OnMessageReceived(CustomerDrinkSoldMessage message)
		{
			Message = message;
		}
	}
}
