using UnityEngine;

namespace Characters.Customers
{
    public class ReturnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Customer")) 
                return;
            
            Destroy(other.gameObject);
        }
    }
}