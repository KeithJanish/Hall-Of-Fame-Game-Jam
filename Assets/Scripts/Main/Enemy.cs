using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 1f;

    public float speed = 5f;

    private Transform targetTransform;

    private Vector2 direction;

    private GameObject targetObject;

    private string targetTag = "Player";
    private string grappleTag = "DreamCircle";

    private void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag(targetTag);
        if(targetObject != null)
        {
            targetTransform = targetObject.transform;
        }
    }

    private void Update()
    {
        if(targetTransform != null)
        {
            Vector2 currentPos = transform.position;
            Vector2 targetPos = targetTransform.position;
            float step = speed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(currentPos, targetPos, step);
        }
    }



}
