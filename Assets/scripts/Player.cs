using UnityEngine;

public class Player : MonoBehaviour
{
    public SwitchGun SwitchGun;
    //Система дропа оружия очень напоминает его смену
    //за исключением того что при смене оружие становится неактивным, а при дропе неактивным должен становиться только скрипт стрельбы
    //Мб сделать дроп оружия дочерним классом, либо можно использовать виртуальные класс, на мой взгляд лучше использовать их

    private Interactable interactableObject;

    public GameObject ActualGun;
    public GameObject bullet;
    public Shoot _shoot;

    [SerializeField] private float Speed;
    private float moveHorizontal;
    private float moveVertical;

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            Interaction();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Switching();
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && ActualGun.GetComponent<Shoot>() != null)
        {
            _shoot.shoot();
        }
    }
    private void FixedUpdate()
    {
        MoveManager();
    }
    private void MoveManager()
    {
        Move();

        Flip();

        Anim();
    }

    private void Move()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        transform.Translate(movement * Speed * Time.fixedDeltaTime);
    }
    private void Anim()
    {
        anim.SetFloat("horizontalmove", Mathf.Abs(moveHorizontal));
        anim.SetFloat("verticalmove", Mathf.Abs(moveVertical));
    }
    private void Flip()
    {
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
    }
    private void Interaction()
    {
        if (interactableObject != null)
        {
            interactableObject.Interact();
            Debug.Log("interact");
        }
    }

    private void Switching()
    {
        ActualGun = SwitchGun.SwitchingGun(ActualGun);

        _shoot = ActualGun.GetComponent<Shoot>();
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
