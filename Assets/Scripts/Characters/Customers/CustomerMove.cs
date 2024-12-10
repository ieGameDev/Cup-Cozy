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
        private bool _orderCompleted;

        public void Construct(GameObject orderPoint, Transform returnPoint)
        {
            _orderPoint = orderPoint;
            _returnPoint = returnPoint;
            _orderCompleted = false;
        }

        private void Update()
        {
            if (IsOrderTriggerOutOfReached() && !_orderCompleted)
                _customerAgent.SetDestination(_orderPoint.transform.position);
            else
                _customerAgent.SetDestination(_returnPoint.transform.position);
        }

        public void ChangeDestination() => 
            _orderCompleted = true;

        private bool IsOrderTriggerOutOfReached() =>
            Vector3.Distance(_customerAgent.transform.position, _orderPoint.transform.position) > 0f;
    }
}