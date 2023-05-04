using PubSubPub.Game.Core.Messages;
using SuperMaxim.Messaging;

namespace PubSubPub.Tests.Stubs
{
	public class DrinkFillAmountChangedMessageSubscriberStub
	{
		public DrinkFillAmountChangedMessageSubscriberStub(IMessenger messenger)
		{
			messenger.Subscribe<DrinkFillAmountChangedMessage>(OnMessageReceived);
		}


		public DrinkFillAmountChangedMessage Message { get; set; }


		private void OnMessageReceived(DrinkFillAmountChangedMessage message)
		{
			Message = message;
		}
	}
}
