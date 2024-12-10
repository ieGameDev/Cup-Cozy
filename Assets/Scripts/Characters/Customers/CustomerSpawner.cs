using Services.Factory;
using UnityEngine;

namespace Characters.Customers
{
    public class CustomerSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _returnPoint;

        private IGameFactory _gameFactory;
        private OrderTrigger[] _orderTriggers;

        public void Construct(IGameFactory factory, OrderTrigger[] orderTriggers)
        {
            _gameFactory = factory;
            _orderTriggers = orderTriggers;
        }

        private void Start()
        {
            foreach (OrderTrigger orderTrigger in _orderTriggers)
                orderTrigger.OnPlaceAvailable += CreateCustomer;
        }

        private void OnDestroy()
        {
            foreach (OrderTrigger orderTrigger in _orderTriggers)
                orderTrigger.OnPlaceAvailable -= CreateCustomer;
        }

        private void CreateCustomer(GameObject orderPoint)
        {
            GameObject customer = _gameFactory.CreateCustomer(transform);
            CustomerMove customerMove = customer.GetComponent<CustomerMove>();
            customerMove.Construct(orderPoint, _returnPoint);
        }
    }
}