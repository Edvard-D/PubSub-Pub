using System.Collections.Generic;
using PubSubPub.Game.Core.Model;
using PubSubPub.Game.Core.Messages;
using SuperMaxim.Messaging;
using UnityEngine;
using UnityEngine.UIElements;

namespace PubSubPub.Game.UI
{
	public class InGameUIManager : MonoBehaviour
	{
		[SerializeField]
		private string _drinkSettingsListFolderPath;
		[SerializeField]
		private Texture2D _customerPassedOutTexture;
		[SerializeField]
		private VisualTreeAsset _customerElementTemplate;
		[SerializeField]
		private VisualTreeAsset _drinkSelectorElementTemplate;

		private VisualElement _customerContainer;
		private Dictionary<Customer, VisualElement> _customerElements = new Dictionary<Customer, VisualElement>();
		private DrinkSelectorContainer _drinkSelectorContainer;
		private VisualElement _root;


		private void Awake()
		{
			_root = GetComponent<UIDocument>().rootVisualElement;
			
			_customerContainer = _root.Q<VisualElement>("customer-container");
			_drinkSelectorContainer = _root.Q<DrinkSelectorContainer>();
		}

		private void Start()
		{
			_drinkSelectorContainer.Setup(_drinkSettingsListFolderPath, _drinkSelectorElementTemplate);
		}

		private void OnEnable()
		{
			Messenger.Default.Subscribe<CustomerInstantiatedMessage>(OnCustomerInstantiatedMessage);
			Messenger.Default.Subscribe<CustomerRemovedMessage>(OnCustomerRemovedMessage);
		}

		private void OnDisable()
		{
			Messenger.Default.Unsubscribe<CustomerInstantiatedMessage>(OnCustomerInstantiatedMessage);
			Messenger.Default.Unsubscribe<CustomerRemovedMessage>(OnCustomerRemovedMessage);
		}

		private void OnCustomerInstantiatedMessage(CustomerInstantiatedMessage message)
		{
			var customerElementContainer = _customerElementTemplate.Instantiate();
			var customerElement = customerElementContainer.Q<CustomerElement>();
			customerElement.Setup(message.Customer, _customerPassedOutTexture);
			_customerContainer.Add(customerElementContainer);
		}

		private void OnCustomerRemovedMessage(CustomerRemovedMessage message)
		{
			if(_customerElements.ContainsKey(message.Customer) == false)
			{
				return;
			}

			_customerContainer.Remove(_customerElements[message.Customer]);
			_customerElements.Remove(message.Customer);
		}
	}
}
