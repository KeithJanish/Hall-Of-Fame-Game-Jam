using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public float horMove;
    public Rigidbody2D rigbody;
    public GameObject dcFab; // DreamCirclePrefab
    public GameObject dcObj; // DreamCircleObject
    public Vector2 moveToHere;
    public Vector2 dcObjThrowPoint;
    public int spawnDelayTimer;
    public float speed;
    public SpriteRenderer sprRendStand;
    //public SpriteRenderer sprRendRunLeft;
    //public SpriteRenderer sprRendRunRight;
    //public SpriteRenderer sprRendDeath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigbody = GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horMove = Input.GetAxis("Horizontal");

        rigbody.AddForce(new Vector2(horMove * speed, 0));
        if (Input.GetKey(KeyCode.A))
        {
            sprRendStand.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            sprRendStand.flipX = false;
        }

        if (rigbody.linearVelocity.x < -1)
        {
            //sprRendRunLeft.enabled = true;
        }
        else if (rigbody.linearVelocity.x > 1)
        {
            //sprRendRunLeft.enabled = true;
        }
        else
        {
            //sprRendRunLeft.enabled = false;
        }

        Debug.Log("AAAAA");
        if (Input.GetKeyDown(KeyCode.Mouse0) && dcObj == null)
        {
            spawnDelayTimer = 100;
            dcObj = Instantiate(dcFab, transform.position, Quaternion.identity);
            dcObjThrowPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveToHere = (dcObj.transform.position - transform.position) * 2;

                rigbody.AddForce(moveToHere);
            }

            if (Input.GetKey(KeyCode.S))
            {
                dcObj.transform.position = Vector2.MoveTowards(dcObj.transform.position, transform.position, 0.1f);
            }
            else
            {
                dcObj.transform.position = Vector2.MoveTowards(dcObj.transform.position, dcObjThrowPoint, 0.1f);
            }
            spawnDelayTimer -= 1;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if (other.CompareTag("DreamCircle") && spawnDelayTimer <= 0)
        {
            Destroy(other.gameObject);
            Debug.Log("DreamCircle Destroyed");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }
}
