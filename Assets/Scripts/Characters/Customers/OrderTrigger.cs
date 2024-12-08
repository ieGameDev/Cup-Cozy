using System;
using UnityEngine;

namespace Characters.Customers
{
    public class OrderTrigger : MonoBehaviour
    {
        public event Action<GameObject> OnPlaceAvailable;

        private void Start() =>
            OnPlaceAvailable?.Invoke(gameObject);

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Customer")) return;
            CustomerUI customerUi = other.GetComponentInChildren<CustomerUI>();
            customerUi.ShowAttention();
        }
    }
}