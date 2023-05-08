using SuperMaxim.Messaging;

namespace PubSubPub.Tests.Stubs
{
	public class MessagePublisherStub
	{
		private IMessenger _messenger;


		public MessagePublisherStub(IMessenger messenger)
		{
			_messenger = messenger;
		}


		public void Publish<T>(T message)
		{
			_messenger.Publish(message);
		}
	}
}
