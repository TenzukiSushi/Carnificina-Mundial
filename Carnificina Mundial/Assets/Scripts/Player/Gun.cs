using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private SpriteRenderer playerSprite; 

    private float nextFire;
    private Vector2 mousePos;

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire) Fire();
    }

    private void FixedUpdate()
    {
        GunRotating();
    }  

    private void GunRotating()
    {
        Vector2 lookDir = mousePos - playerRb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (angle > 90 || angle < -90) playerSprite.flipX = true;
        else playerSprite.flipX = false;
    }

    private void Fire()
    {
        nextFire = Time.time + fireRate;
        GameObject cloneBullet = Instantiate(bullet, bulletSpawn.position, transform.rotation);
    }
}
