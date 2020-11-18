using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    public int health;
    public bool invulnerable = false;

    private float currentSpeed;

    private Rigidbody2D rb;
    private Animator anim;
    private Animator lifeBar;
    private SpriteRenderer sprite;

    private Vector2 axis;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        lifeBar = GameObject.Find("LifeBar").GetComponent<Animator>();
    }

    private void Update()
    {
        Animations();
        lifeBar.SetInteger("Health", health);

        axis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift)) currentSpeed = runSpeed;
        else currentSpeed = walkSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = axis * currentSpeed;   
    }

    private void Animations()
    {
        bool canAnimWalk;

        if (axis.x != 0) canAnimWalk = true;

        else if (axis.y != 0) canAnimWalk = true;
        else if (axis.x != 0 || axis.y != 0) canAnimWalk = true;
        else canAnimWalk = false;

        anim.SetBool("Moving", canAnimWalk);
    }

    IEnumerator Damage()
    {
        for(float i = 0; i < 1; i += 0.1f)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        invulnerable = false;
    }

    IEnumerator Die()
    {
        currentSpeed = 0;
        walkSpeed = 0;
        runSpeed = 0;
        for (float i = 0; i < 1; i += 0.1f)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene("Menu");
    }

    public void DamagePlayer()
    {
        invulnerable = true;
        health--;
        StartCoroutine(Damage());

        if(health <= 0) StartCoroutine(Die());
    }
}
