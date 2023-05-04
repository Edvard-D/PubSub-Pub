using PubSubPub.Game.Core.Messages;
using SuperMaxim.Messaging;
using UnityEngine;

namespace PubSubPub.Game.Core.Model
{
	public class Drink
	{
		[SerializeField]
		[HideInInspector]
		private float _fillAmount;
		[SerializeField]
		[HideInInspector]
		private IDrinkSettings _settings;

		private IMessenger _messenger;


		public Drink(IDrinkSettings settings)
		{
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

				_messenger.Publish(new DrinkFillAmountChangedMessage(this, _fillAmount));
			}
		}
		public IDrinkSettings Settings { get { return _settings; } }

		
		public void Initialize(IMessenger messenger)
		{
			_messenger = messenger;
		}

		public void DrinkDrink(float amount)
		{
			if(amount <= 0f)
			{
				Debug.LogError("Argument " + nameof(amount) + " cannot be less than or equal to zero.");
			}

			FillAmount -= amount;
		}
	}
}
