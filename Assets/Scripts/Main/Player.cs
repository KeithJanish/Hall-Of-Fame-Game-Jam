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
    public SpriteRenderer dcSprRend;
    public Sprite dcSprA;
    public Sprite dcSprB;
    public bool dcSecEnter;
    public Vector2 moveToHere;
    public Vector2 dcObjThrowPoint;
    public int spriteTimer;
    public float speed;
    public SpriteRenderer sprRend;
    public Animator ani;
    public bool sPressedWhenDcExist;
    public AudioSource walk;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigbody = GetComponent <Rigidbody2D>();
        ani.Play("D0_Nothing");
    }

    // Update is called once per frame
    void Update()
    {
        horMove = Input.GetAxis("Horizontal");

        rigbody.AddForce(new Vector2(horMove * speed, 0));

        if (horMove < 0)
        {
            sprRend.flipX = false;
            ani.Play("A_Player_Run_Left");
            if (walk.isPlaying == false)
            {
                walk.Play();
            }
        }
        else if (horMove > 0)
        {
            sprRend.flipX = false;
            ani.Play("A_Player_Run_Right");
            if (walk.isPlaying == false)
            {
                walk.Play();
            }
        }
        else
        {
            ani.Play("D0_Nothing");
            walk.Stop();
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
            {
                sprRend.flipX = true;
            }
            else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
            {
                sprRend.flipX = false;
            }
        }

        Debug.Log("AAAAA");
        if (Input.GetKeyDown(KeyCode.Mouse0) && dcObj == null)
        {
            dcSecEnter = false;
            sPressedWhenDcExist = false;
            spriteTimer = 0;
            dcObj = Instantiate(dcFab, transform.position, Quaternion.identity);
            dcObjThrowPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dcSprRend = dcObj.GetComponent<SpriteRenderer>();
        }
        else
        {
            spriteTimer += 1;
            if(spriteTimer >= 7)
            {
                if (dcSprRend.sprite == dcSprA)
                {
                    dcSprRend.sprite = dcSprB;
                }
                else
                {
                    dcSprRend.sprite = dcSprA;
                }
                spriteTimer = 0;
            }

            if (Input.GetKey(KeyCode.W))
            {
                moveToHere = (dcObj.transform.position - transform.position) * 20;

                rigbody.AddForce(moveToHere);
            }

            if (sPressedWhenDcExist == false)
            {
                dcObj.transform.position = Vector2.MoveTowards(dcObj.transform.position, dcObjThrowPoint, 0.1f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                dcObj.transform.position = Vector2.MoveTowards(dcObj.transform.position, transform.position, 0.1f);
                sPressedWhenDcExist = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if (other.CompareTag("DreamCircle"))
        {
            if (dcSecEnter == true)
            {
                Destroy(other.gameObject);
                Debug.Log("DreamCircle Destroyed");
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if (other.CompareTag("DreamCircle"))
        {
            dcSecEnter = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }
}
