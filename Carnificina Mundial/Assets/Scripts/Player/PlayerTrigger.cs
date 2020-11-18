using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private PlayerMovement player;
    private Inimigo1 enemy;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            if (!player.invulnerable) player.DamagePlayer();
            enemy = other.GetComponent<Inimigo1>();
            StartCoroutine(EnemyStopMove());
        }
            
    }

    IEnumerator EnemyStopMove()
    {
        enemy.currentSpeed = 0;
        yield return new WaitForSeconds(1);
        enemy.currentSpeed = enemy.speed;
    }
}
