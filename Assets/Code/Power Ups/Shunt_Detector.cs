using Unity.VisualScripting;
using UnityEngine;

public class Shunt_Detector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Shunt shunt = other.GetComponent<Shunt>();

            if (shunt != null)
            {
                shunt.isShunt = true;
            }

            Destroy(gameObject);
        }
    }

}
