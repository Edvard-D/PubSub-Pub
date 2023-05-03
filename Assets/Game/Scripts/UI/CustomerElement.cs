using PubSubPub.Game.Core.Model;
using PubSubPub.Game.Core.Messages;
using SuperMaxim.Messaging;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

namespace PubSubPub.Game.UI
{
	public class CustomerElement : VisualElement
	{
		private const string ClassName = "customer-element";

		
		private Customer _customer;
		private Texture2D _passedOutTexture;
		private DrinkSettings _selectedDrinkSettings;
		private VisualElement _statusIcon;


		public void Setup(
				Customer customer,
				Texture2D passedOutTexture)
		{
			_customer = customer;
			_passedOutTexture = passedOutTexture;
			_statusIcon = this.Q<VisualElement>("status-icon");

			RegisterCallback<DetachFromPanelEvent>(OnDetachFromPanelEvent);
			RegisterCallback<ClickEvent>(OnClickEvent);
			Messenger.Default.Subscribe<CustomerDrinkSoldMessage>(OnCustomerDrinkSoldMessage,
					(CustomerDrinkSoldMessage message) => message.Customer == _customer);
			Messenger.Default.Subscribe<CustomerNewDrinkRequestedMessage>(OnCustomerNewDrinkRequestedMessage,
					(CustomerNewDrinkRequestedMessage message) => message.Customer == _customer);
			Messenger.Default.Subscribe<CustomerPassedOutMessage>(OnCustomerPassedOutMessage,
					(CustomerPassedOutMessage message) => message.Customer == _customer);
			Messenger.Default.Subscribe<DrinkSelectionChangedMessage>(OnDrinkSelectedMessage);
		}

		private void OnDetachFromPanelEvent(DetachFromPanelEvent detachFromPanelEvent)
		{
			Messenger.Default.Unsubscribe<DrinkSelectionChangedMessage>(OnDrinkSelectedMessage);
		}

		private void OnClickEvent(ClickEvent clickEvent)
		{
			if(_selectedDrinkSettings != null)
			{
				Messenger.Default.Publish(new CustomerDrinkSaleInitiatedMessage(_customer, _selectedDrinkSettings));
				
				return;
			}
			
			Messenger.Default.Publish(new CustomerRemovalInitiatedMessage(_customer));
		}

		private void OnCustomerDrinkSoldMessage(CustomerDrinkSoldMessage customerDrinkSoldMessage)
		{
			_statusIcon.style.display = DisplayStyle.None;
		}

		private void OnCustomerNewDrinkRequestedMessage(
				CustomerNewDrinkRequestedMessage customerNewDrinkRequestedMessage)
		{
			_statusIcon.style.display = DisplayStyle.Flex;
			_statusIcon.style.backgroundImage = customerNewDrinkRequestedMessage.DrinkSettings.Icon;
		}

		private void OnCustomerPassedOutMessage(CustomerPassedOutMessage customerPassedOutMessage)
		{
			_statusIcon.style.display = DisplayStyle.Flex;
			_statusIcon.style.backgroundImage = _passedOutTexture;
		}

		private void OnDrinkSelectedMessage(DrinkSelectionChangedMessage drinkSelectedMessage)
		{
			_selectedDrinkSettings = drinkSelectedMessage.DrinkSettings;
		}


		[Preserve]
		public new class UxmlFactory : UxmlFactory<CustomerElement, UxmlTraits> {}
		[Preserve]
		public new class UxmlTraits : VisualElement.UxmlTraits
		{
			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);

				ve.AddToClassList(ClassName);
			}
		}
	}
}
