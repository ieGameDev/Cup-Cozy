using Logic;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Customers
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class CustomersMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _customerAgent;

        [SerializeField] private GameObject _orderPoint;
        [SerializeField] private Transform _returnPoint;

        private OrderTrigger _orderTrigger;

        private void Start() =>
            _orderTrigger = _orderPoint.GetComponent<OrderTrigger>();


        private void Update()
        {
            _customerAgent.SetDestination(_orderPoint.transform.position);
        }
    }
}