using UnityEngine;
using UnityEngine.AI;

namespace Characters.Customers
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CustomerMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _customerAgent;

        private GameObject _orderPoint;
        private Transform _returnPoint;

        public void Construct(GameObject orderPoint, Transform returnPoint)
        {
            _orderPoint = orderPoint;
            _returnPoint = returnPoint;
        }

        private void Update()
        {
            if (IsCustomerOutOfReached())
                _customerAgent.SetDestination(_orderPoint.transform.position);
        }

        private bool IsCustomerOutOfReached() =>
            Vector3.Distance(_customerAgent.transform.position, _orderPoint.transform.position) > 0f;
    }
}