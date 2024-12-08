using UnityEngine;

namespace Characters.Customers
{
    public class Order : MonoBehaviour
    {
        [SerializeField] private CustomerUI _customerUI;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            _customerUI.ShowOrderButton();
            _customerUI.HideAttention();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            _customerUI.HideOrderButton();
            _customerUI.ShowAttention();
        }
    }
}