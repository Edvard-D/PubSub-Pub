using PubSubPub.Messages;
using SuperMaxim.Messaging;
using UnityEngine;

namespace PubSubPub.Core
{
	public class Drink
	{
		[SerializeField]
		[HideInInspector]
		private Customer _customer;
		[SerializeField]
		[HideInInspector]
		private float _fillAmount;
		[SerializeField]
		[HideInInspector]
		private DrinkSettings _settings;


		public Drink(
				Customer customer,
				DrinkSettings settings)
		{
			_customer = customer;
			_fillAmount = 1f;
			_settings = settings;
		}


		public float FillAmount
		{
			get { return _fillAmount; }
			private set
			{
				value = Mathf.Clamp01(value);
				if(_fillAmount == value)
				{
					return;
				}

				_fillAmount = value;

				Messenger.Default.Publish(new DrinkFillAmountChangedMessage(_customer, this, _fillAmount));
			}
		}
		public DrinkSettings Settings { get { return _settings; } }


		public void DrinkDrink(float amount)
		{
			FillAmount -= amount;
		}
	}
}
