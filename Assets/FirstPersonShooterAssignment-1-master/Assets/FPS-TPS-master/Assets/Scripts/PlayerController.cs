using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed;
    public CharacterController character;
    Vector3 moveinput;
    public Transform cameraTransform;
    public float mouseSenstivity;
    Vector2 mouseInput;
    public float gravity;
    public float jumpForce;
    bool canJump;
    public Transform groundCheck;
    public LayerMask groundMask;
    bool canDoubleJump;
    public float runSpeed;
    public Animator anim;
    public Transform firePoint;
    public GameObject currentbullet;
    AudioManager audioManager;
    public GameObject prefab;
    Stack<GameObject> bulletpool = new Stack<GameObject>();
    public static PlayerController bulletInstance;
    private void Awake()
    {
        bulletInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 horiMove = transform.right * Input.GetAxis("Horizontal");
        Vector3 verMove = transform.forward * Input.GetAxis("Vertical");
        moveinput = horiMove + verMove;
        
        if (Input.GetKey(KeyCode.E))
        {
            moveinput = moveinput * runSpeed;
        }
        else
        {
            moveinput *= moveSpeed ;
        }
        moveinput.y += Physics.gravity.y * gravity * Time.deltaTime;
        canJump = Physics.OverlapSphere(groundCheck.position, 0.25f, groundMask).Length > 0;
        //Debug.Log(canJump);
        if (canJump)
        {
            canDoubleJump=false;
        }
        if (Input.GetKeyDown(KeyCode.Q)&&canJump)
        {
            moveinput.y = jumpForce;
            canDoubleJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Q) && canDoubleJump)
        {
            moveinput.y = jumpForce;
            canDoubleJump = false;
        }

        character.Move(moveinput * Time.deltaTime);
        //camera rotation using mouseinput
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"))*mouseSenstivity;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles+new Vector3(mouseInput.y,0,0));
        anim.SetFloat("moveSpeed", moveinput.magnitude);
        anim.SetBool("onGround",canJump);
        
        
        
        if (Input.GetMouseButtonDown(0))
        {
            //raycast
            RaycastHit hit;
            if(Physics.Raycast(cameraTransform.position,cameraTransform.forward,out hit, 70f))
            {
                firePoint.LookAt(hit.point);
            }

            BulletSpawning();
        }
    }
    public void CreatePool()//creating object pool method for bullets
    {
        {
            bulletpool.Push(Instantiate(prefab));
            bulletpool.Peek().SetActive(false);
            bulletpool.Peek().name = "PlayerBullet";
        }

    }
    public void addBullet(GameObject bullettemp)//adding missed bullet
    {
        bulletpool.Push(bullettemp);
        bulletpool.Peek().SetActive(false);

    }
    
    public void BulletSpawning()
    {
        if (bulletpool.Count == 0)
        {
            CreatePool();
        }
        audioManager.PlayAudio("Bullet");
        GameObject temp = bulletpool.Pop();
        temp.SetActive(true);
        temp.transform.position =firePoint.position;
        temp.transform.rotation = firePoint.rotation;
        currentbullet = temp;
    }
    
}
