using UnityEngine;
using UnityEngine.UI;

namespace Characters.Customers
{
    public class CustomerUI : MonoBehaviour
    {
        [SerializeField] private CustomerMove _customerMove;
        [SerializeField] private GameObject _attentionSymbol;
        [SerializeField] private Button _orderButton;
        
        public Button OrderButton => _orderButton;

        private void Start()
        {
            HideAttention();
            HideOrderButton();
        }

        public void ShowAttention()
        {
            _attentionSymbol.SetActive(true);
        }

        public void HideAttention()
        {
            _attentionSymbol.SetActive(false);
        }

        public void ShowOrderButton()
        {
            _orderButton.gameObject.SetActive(true);
        }
        
        public void HideOrderButton()
        {
            _orderButton.gameObject.SetActive(false);
        }
    }
}