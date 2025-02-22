using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

    void OCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10f;
            Debug.Log("Health: " + health);
        }
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void Update()
    {
        if(health > maxHealth)
        {
            health = 100f;
        }
    }
    

}
