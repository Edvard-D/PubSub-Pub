using PubSubPub.Core;
using PubSubPub.Messages;
using SuperMaxim.Messaging;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

namespace PubSubPub
{
	public class DrinkSelectorElement : VisualElement
	{
		private const string ClassName = "drink-selector-element";

		
		private DrinkSettings _drinkSettings;
		private VisualElement _icon;
		private Label _nameLabel;


		public void Setup(DrinkSettings drinkSettings)
		{
			_drinkSettings = drinkSettings;
			_icon = this.Q<VisualElement>("icon");
			_nameLabel = this.Q<Label>("name-label");

			_icon.style.backgroundImage = drinkSettings.Icon;
			_nameLabel.text = drinkSettings.Name;

			RegisterCallback<ClickEvent>(OnClickEvent);
		}

		private void OnClickEvent(ClickEvent clickEvent)
		{
			Messenger.Default.Publish(new DrinkSelectionChangedMessage(_drinkSettings));
		}


		[Preserve]
		public new class UxmlFactory : UxmlFactory<DrinkSelectorElement, UxmlTraits> {}
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
