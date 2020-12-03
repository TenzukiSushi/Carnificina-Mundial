using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Variaveis numericas")]
    [SerializeField] private float speed;
    [SerializeField] private float timeDestroy;

    //Pega o componente das variaveis
    private void Start() => Destroy(gameObject, timeDestroy);
    private void Update() => transform.Translate(Vector2.right * speed * Time.deltaTime);
}