using PubSubPub.Game.Core.Model;

namespace PubSubPub.Game.Core.Messages
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
