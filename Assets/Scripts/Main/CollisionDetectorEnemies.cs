using UnityEngine;

public class CollisionDetectorEnemies : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            print("Player Triggered the Trigger");
            for(int i = 0; i < enemies.Length; i++)
            {
                enemies[i].enabled = true;
            }
        }
    }

}
