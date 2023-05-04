using PubSubPub.Game.Core.Messages;
using SuperMaxim.Messaging;

namespace PubSubPub.Tests.Stubs
{
	public class CustomerNewDrinkRequestedMessageSubscriberStub
	{
		public CustomerNewDrinkRequestedMessageSubscriberStub(IMessenger messenger)
		{
			messenger.Subscribe<CustomerNewDrinkRequestedMessage>(OnMessageReceived);
		}


		public CustomerNewDrinkRequestedMessage Message { get; set; }


		private void OnMessageReceived(CustomerNewDrinkRequestedMessage message)
		{
			Message = message;
		}
	}
}
