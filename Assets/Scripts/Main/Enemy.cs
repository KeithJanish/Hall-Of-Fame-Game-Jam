using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 1f;

    
    public float speed = 5f;
    public float desiredSeparation = 1f;
    public float separationForce = 2f;
    public float smoothTime = 0.1f;
    private Transform targetTransform;
    private string targetTag = "Player";
    private string enemyTag = "Enemy";
    private List<Transform> neighbors = new List<Transform>();
    private Vector2 velocity;
    private Vector2 currentVelocity;

    private void Start()
    {
        GameObject t = GameObject.FindGameObjectWithTag(targetTag);
        if (t) targetTransform = t.transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(enemyTag) && other.gameObject != gameObject)
            neighbors.Add(other.transform);

        if (other.gameObject.tag == targetTag)
        {
            print("Player has Died!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(enemyTag))
            neighbors.Remove(other.transform);
    }

    private void Update()
    {



        Vector2 pos = transform.position;
        Vector2 chase = Vector2.zero;
        if (targetTransform)
            chase = ((Vector2)targetTransform.position - pos).normalized * speed;
        Vector2 sep = Vector2.zero;
        foreach (Transform n in neighbors)
        {
            Vector2 diff = pos - (Vector2)n.position;
            float dist = diff.magnitude;
            if (dist < desiredSeparation && dist > 0)
            {
                float ratio = (desiredSeparation - dist) / dist;
                sep += diff.normalized * ratio;
            }
        }
        if (neighbors.Count > 0)
            sep = sep.normalized * separationForce;
        Vector2 desiredVelocity = chase + sep;
        velocity = Vector2.SmoothDamp(velocity, desiredVelocity, ref currentVelocity, smoothTime);
        transform.position += (Vector3)(velocity * Time.deltaTime);
    }
}
