using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public float horMove;
    public float vertMove;
    public Rigidbody2D rigbody;
    public GameObject dcFab; // DreamCirclePrefab
    public GameObject dcObj; // DreamCircleObject
    public Transform dct; // DreamCircleTransform
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horMove = Input.GetAxis("Horizontal");
        //vertMove = Input.GetAxis("Vertical");

        rigbody.AddForce(new Vector2(horMove, vertMove));

        if (Input.GetKeyDown(KeyCode.Mouse0) && dcObj == null)
        {
            dcObj = Instantiate(dcFab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            dcObj.transform.position = new Vector3(dcObj.transform.position.x, dcObj.transform.position.y, 0);
            dct = dcObj.transform;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rigbody.AddForce(Vector2.MoveTowards(transform.position, dct.position, 3));
        }

        if (Input.GetKey(KeyCode.S))
        {
            dct.position = Vector2.MoveTowards(dct.position, transform.position, 0.1f);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DreamCircle")
        {
            Destroy(collision.gameObject);
        }
    }
}
