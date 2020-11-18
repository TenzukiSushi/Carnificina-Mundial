using UnityEngine;
using System.Collections;

public class Inimigo1 : MonoBehaviour
{
    public float health;
    public float speed;

    [HideInInspector] public float currentSpeed;     

    private GameObject target;
    private SpriteRenderer sprite;


    private void Start()
    {
        target = GameObject.Find("Player");
        sprite = GetComponent<SpriteRenderer>();

        StartCoroutine(StartMoving());
    }

    private void Update() => transform.position = Vector2.MoveTowards(transform.position, target.transform.position, currentSpeed * Time.deltaTime);

    public void DamageEnemy(int damageBullet)
    {
        health -= damageBullet;
        StartCoroutine(Damage());

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Damage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

    IEnumerator StartMoving()
    {
        currentSpeed = 0;
        yield return new WaitForSeconds(0.3f);
        currentSpeed = speed;
    }
}
