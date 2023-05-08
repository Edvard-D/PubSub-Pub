using PubSubPub.Game.Core.Messages;
using SuperMaxim.Messaging;

namespace PubSubPub.Tests.Stubs
{
	public class CustomerInstantiatedMessageReceiverStub
	{
		public CustomerInstantiatedMessageReceiverStub(IMessenger messenger)
		{
			messenger.Subscribe<CustomerInstantiatedMessage>(OnMessageReceived);
		}


		public CustomerInstantiatedMessage Message { get; set; }


		private void OnMessageReceived(CustomerInstantiatedMessage message)
		{
			Message = message;
		}
	}
}
