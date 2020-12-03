using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float health;

    private GameObject target;
    private SpriteRenderer sprite;
    private float currentSpeed = 0;

    private void Update() => transform.position = Vector2.MoveTowards(transform.position, target.transform.position, currentSpeed * Time.deltaTime);

    private void Start()
    {
        target = GameObject.Find("Player");
        StartCoroutine(StartMoving());
    }

    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(1);
        currentSpeed = speed;
    }
}
