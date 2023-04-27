using PubSubPub.Core;

namespace PubSubPub.Messages
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
