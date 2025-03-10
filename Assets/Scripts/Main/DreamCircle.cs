using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DreamCircle : MonoBehaviour
{
    private Enemy enemyRef;
    private SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public AudioSource crack;

    [SerializeField] private bool canHit = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SmallEnemy") && canHit)
        {
            enemyRef = collision.GetComponent<Enemy>();
            print("Hit Enemy");
            enemyRef.health -= 1;
            crack.Play();
            if(enemyRef.health <= 0 )
            {
                Destroy(enemyRef.gameObject);
                print("Destroying Small Enemy");
            }
            canHit = false;
            StartCoroutine(Delay());

        }
        else if(collision.CompareTag("BigEnemy") && canHit)
        {
            enemyRef = collision.GetComponent<Enemy>();
            enemyRef.health -= 1;
            crack.Play();
            spriteRenderer = collision.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            if(enemyRef.health <= 0 )
            {
                Destroy(enemyRef.gameObject);
            }
            canHit= false;
            StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(.5f);
        canHit = true;
    }
}
