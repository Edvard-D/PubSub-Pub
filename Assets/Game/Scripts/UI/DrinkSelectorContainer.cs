using PubSubPub.Core;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

namespace PubSubPub.UI
{
	public class DrinkSelectorContainer : VisualElement
	{
		private const string ClassName = "drink-selector-container";


		public void Setup(
				string drinkSettingsListFolderPath,
				VisualTreeAsset drinkSelectorElementContainerTemplate)
		{
			var drinkSettingsList = Resources.LoadAll<DrinkSettings>(drinkSettingsListFolderPath);

			foreach(var drinkSettings in drinkSettingsList)
			{
				var drinkSelectorElementContainer = drinkSelectorElementContainerTemplate.Instantiate();
				var drinkSelectorElement = drinkSelectorElementContainer.Q<DrinkSelectorElement>();
				drinkSelectorElement.Setup(drinkSettings);
				this.Add(drinkSelectorElementContainer);
			}
		}


		[Preserve]
		public new class UxmlFactory : UxmlFactory<DrinkSelectorContainer, UxmlTraits> {}
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
