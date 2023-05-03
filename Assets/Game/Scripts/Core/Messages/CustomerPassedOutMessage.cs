using PubSubPub.Game.Core.Model;

namespace PubSubPub.Game.Core.Messages
{
	public class CustomerPassedOutMessage
	{
		public CustomerPassedOutMessage(Customer customer)
		{
			Customer = customer;
		}


		public Customer Customer { get; private set; }
	}
}
