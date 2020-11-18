using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeDestroy;
    [SerializeField] private int damage;

    private void Start() => Destroy(gameObject, timeDestroy);
    private void Update() => transform.Translate(Vector2.right * speed * Time.deltaTime);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Inimigo1 enemy = other.GetComponent<Inimigo1>();
            if (enemy != null) enemy.DamageEnemy(damage);

            Destroy(gameObject);
        }       
    }
}
