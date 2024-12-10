using UnityEngine;

namespace Characters.Customers
{
    public class Order : MonoBehaviour
    {
        [SerializeField] private CustomerUI _customerUI;
        [SerializeField] private Collider _triggerCollider;
        [SerializeField] private CustomerMove _customerMove;

        private void Start()
        {
            TurnOffOrderCollider();
            _customerUI.OrderButton.onClick.AddListener(OrderLogic);
        }

        private void OnDestroy()
        {
            _customerUI.OrderButton.onClick.RemoveListener(OrderLogic);
        }

        public void TurnOnOrderCollider() => 
            _triggerCollider.enabled = true;

        public void TurnOffOrderCollider() => 
            _triggerCollider.enabled = false;

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

        private void OrderLogic()
        {
            _customerMove.ChangeDestination();
            _customerUI.HideAttention();
            _customerUI.HideOrderButton();
            TurnOffOrderCollider();
        }
    }
}