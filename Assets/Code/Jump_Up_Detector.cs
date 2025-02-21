using Unity.VisualScripting;
using UnityEngine;

public class Jump_Up_Detector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Jumper jumper = other.GetComponent<Jumper>();
            if (jumper != null)
            {
                jumper.isJumpUpPower = true;
            }
            Destroy(gameObject);
        }
    }

}
