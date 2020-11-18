using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private float currentSpeed;

    private Vector2 axis;
    private Animator anim;
    private Rigidbody2D rb;

    private void FixedUpdate() => rb.velocity = axis * currentSpeed;

    //Pega o componente dos tipos
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Animations();
        axis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Input.GetKey(KeyCode.LeftShift)) currentSpeed = runSpeed;    //Dá ao currentSpeed a velocidade de correr
        else currentSpeed = walkSpeed;                                  //Dá ao currentSpeed a velocidade de andar
    }   

    private void Animations()
    {
        if (axis != new Vector2(0, 0)) anim.SetBool("Moving", true);    //Ativa animação de corrida
        else anim.SetBool("Moving", false);                             //Desativa a animação de corrida
    }
}
