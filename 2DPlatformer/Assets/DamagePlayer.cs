using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageAmount = 10; // Количество урона
    public float damageInterval = 1f; // Интервал между нанесением урона

    private float lastDamageTime = 0f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Time.time - lastDamageTime >= damageInterval)
        {
            Player playerHealth = other.GetComponent<Player>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                lastDamageTime = Time.time;
            }
        }
    }
}
