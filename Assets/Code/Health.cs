using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float health = 90f;
    public float maxHealth = 100f;
    public ShieldManager shieldManager; 

    void Start()
    {
        if (shieldManager == null)
        {
            shieldManager = GetComponent<ShieldManager>();
        }
    }

    void OnTriggerEnter(Collider collider)
    {

        if (!shieldManager.IsShieldActive() && collider.gameObject.CompareTag("Enemy"))
        {
            health -= 10f;
            Debug.Log("Health: " + health);


            if (health <= 0)
            {
                health = 0f; 
                HandleDeath();
            }
        }
    }

    void Update()
    {

        if (health > maxHealth)
        {
            health = maxHealth;
            Debug.Log("Overheal blocked");
            Debug.Log("Health: " + health);
        }
    }

    void HandleDeath()
    {
        // Reload the scene when health reaches zero
        Debug.Log("Player is dead! Loading next scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}