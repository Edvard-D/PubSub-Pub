using PubSubPub.Game.Core.Model;

namespace PubSubPub.Game.Core.Messages
{
	public class CustomerRemovedMessage
	{
		public CustomerRemovedMessage(Customer customer)
		{
			Customer = customer;
		}


		public Customer Customer { get; private set; }
	}
}
