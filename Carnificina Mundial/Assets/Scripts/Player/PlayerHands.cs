using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    [SerializeField] private GameObject hands;

    private Rigidbody2D rb;
    private Vector2 mousePos;
    private SpriteRenderer sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update() => mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    private void FixedUpdate() => GunRotating();

    private void GunRotating()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;    //Faz os calculos necessarios para descobrir a rotação
        hands.transform.rotation = Quaternion.Euler(0, 0, angle);           //Aplica a rotação de acordo com a posição do mouse
      
        if (angle > 90 || angle < -90)
        {
            sprite.flipX = true;
            hands.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            sprite.flipX = false;
            hands.GetComponent<SpriteRenderer>().flipY = false;
        }
    }
}
