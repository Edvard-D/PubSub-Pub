using PubSubPub.Core;

namespace PubSubPub.Messages
{
	public class CustomerInstantiatedMessage
	{
		public CustomerInstantiatedMessage(Customer customer)
		{
			Customer = customer;
		}


		public Customer Customer { get; private set; }
	}
}
