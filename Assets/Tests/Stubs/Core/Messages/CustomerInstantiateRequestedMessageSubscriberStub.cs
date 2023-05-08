using PubSubPub.Game.Core.Messages;
using SuperMaxim.Messaging;

namespace PubSubPub.Tests.Stubs.Messages
{
	public class CustomerInstantiateRequestedMessageSubscriberStub
	{
		public CustomerInstantiateRequestedMessageSubscriberStub(IMessenger messenger)
		{
			messenger.Subscribe<CustomerInstantiateRequestedMessage>(OnMessageReceived);
		}


		public CustomerInstantiateRequestedMessage Message { get; set; }


		private void OnMessageReceived(CustomerInstantiateRequestedMessage message)
		{
			Message = message;
		}
	}
}
