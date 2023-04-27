using PubSubPub.Core;

namespace PubSubPub.Messages
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
