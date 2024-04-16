using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Interactable interactableObject;
    public GameObject bullet;
    public Animator anim;
    private Transform actualGun;
    public Shoot Shoot;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (interactableObject != null && Input.GetKeyDown(KeyCode.E))
        {
            interactableObject.Interact();
            Debug.Log("interact");
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            actualGun = transform.GetChild(0).GetChild(0);
            Shoot.shoot(HandsDirection.angle, actualGun.position);
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        //движение
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        transform.Translate(movement * Speed * Time.fixedDeltaTime);

        //Flip 
        if (moveHorizontal == -1)
        {
            transform.localScale = new Vector3(-6.683525f, transform.localScale.y, transform.localScale.z);
            HandsDirection.Fliped = true;
        }

        if (moveHorizontal == 1)
        {
            transform.localScale = new Vector3(6.683525f, transform.localScale.y, transform.localScale.z);
            HandsDirection.Fliped = false;
        }

        //Анимация
        anim.SetFloat("horizontalmove", Mathf.Abs(moveHorizontal));
        anim.SetFloat("verticalmove", Mathf.Abs(moveVertical));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "interactable")
        {
            interactableObject = collision.gameObject.GetComponent<Interactable>();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "interactable")
        {
            interactableObject = null;
        }
    }
}
