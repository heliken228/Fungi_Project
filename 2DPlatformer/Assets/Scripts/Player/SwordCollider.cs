using UnityEngine;

public class SwordCollider : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag("Enemy"))
      {
         Enemy enemy = collision.GetComponent<Enemy>();
         if (enemy != null)
         {
            enemy.TakeDamage();
         }
      }
   }
}
