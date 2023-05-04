using System;
using System.Collections.Generic;
using PubSubPub.Game.Core.Model;
using UnityEngine;

namespace PubSubPub.Tests.Stubs
{
	public class DrinkSettingsStub : IDrinkSettings
	{
		public DrinkSettingsStub()
		{
		}
		public DrinkSettingsStub(
				string name,
				int price,
				float alcoholPercent)
		{
			AlcoholPercent = alcoholPercent;
			Icon = null;
			Name = name;
			Price = price;
		}


		public float AlcoholPercent { get; }
		public Texture2D Icon { get; }
		public string Name { get; }
		public int Price { get; }

		
		// Equals and GetHashCode
		public override bool Equals(object obj)
		{
			return Equals(obj as DrinkSettingsStub);
		}

		public bool Equals(DrinkSettingsStub other)
		{
			return other != null &&
					AlcoholPercent == other.AlcoholPercent &&
					EqualityComparer<Texture2D>.Default.Equals(Icon, other.Icon) &&
					Name == other.Name &&
					Price == other.Price;
		}

		public override int GetHashCode() => HashCode.Combine(AlcoholPercent, Icon, Name, Price);
	}
}
