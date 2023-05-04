using PubSubPub.Game.Core.Messages;
using SuperMaxim.Messaging;

namespace PubSubPub.Tests.Stubs
{
	public class CustomerDrinkSaleInitiatedMessagePublisherStub
	{
		private IMessenger _messenger;


		public CustomerDrinkSaleInitiatedMessagePublisherStub(IMessenger messenger)
		{
			_messenger = messenger;
		}


		public void Publish(CustomerDrinkSaleInitiatedMessage message)
		{
			_messenger.Publish(message);
		}
	}
}
