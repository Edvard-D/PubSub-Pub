using System;
using System.Collections.Generic;
using SuperMaxim.Messaging;
using UnityEngine;

namespace PubSubPub.Tests.Stubs
{
	public class MessengerStub : IMessenger
	{
		private Dictionary<object, object> _predicates = new Dictionary<object, object>();
		private Dictionary<Type, List<object>> _subscriptions = new Dictionary<Type, List<object>>();


		IMessengerPublish IMessengerPublish.Publish<T>(T payload)
		{
			Debug.Log($"Publishing {payload}");

			var type = typeof(T);
			if(_subscriptions.ContainsKey(type) == false)
			{
				return this;
			}

			var subscriptions = _subscriptions[type];
			foreach(var subscription in subscriptions)
			{
				var callback = (Action<T>)subscription;
				if(_predicates.ContainsKey(callback))
				{
					var predicate = (Predicate<T>)_predicates[callback];
					if(predicate(payload) == false)
					{
						continue;
					}
				}
				
				callback(payload);
			}

			return this;
		}

		public IMessengerPublish Publish<T>(T payload)
		{
			return ((IMessengerPublish)this).Publish(payload);
		}

		public IMessengerSubscribe Subscribe<T>(
				Action<T> callback,
				Predicate<T> predicate = null)
		{
			Debug.Log($"Subscriber added for {typeof(T)}");

			var type = typeof(T);
			if(_subscriptions.ContainsKey(type) == false)
			{
				_subscriptions[type] = new List<object>();
			}

			if(predicate != null)
			{
				_predicates[callback] = predicate;
			}
			_subscriptions[type].Add(callback);

			return this;
		}

		public IMessengerUnsubscribe Unsubscribe<T>(Action<T> callback)
		{
			Debug.Log($"Subscriber removed for {typeof(T)}");

			var type = typeof(T);
			if(_subscriptions.ContainsKey(type) == false)
			{
				return this;
			}

			_subscriptions[type].Remove(callback);

			return this;
		}
	}
}
