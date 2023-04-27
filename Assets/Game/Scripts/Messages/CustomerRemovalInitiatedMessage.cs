using PubSubPub.Core;

namespace PubSubPub.Messages
{
	public class CustomerRemovalInitiatedMessage
	{
		public CustomerRemovalInitiatedMessage(Customer customer)
		{
			Customer = customer;
		}


		public Customer Customer { get; private set; }
	}
}
