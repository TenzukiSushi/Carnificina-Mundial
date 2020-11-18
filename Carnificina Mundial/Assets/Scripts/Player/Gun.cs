using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private AudioSource shootAudio;

    private float nextFire;
    private Vector2 mousePos;
    private SpriteRenderer sprite;

    private void FixedUpdate() => GunRotating();
    private void Start() => sprite = GetComponent<SpriteRenderer>();  

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire) Fire();
    }

    private void GunRotating()
    {
        Vector2 lookDir = mousePos - playerRb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (angle > 90 || angle < -90)
        {
            playerSprite.flipX = true;
            sprite.flipY = true;
        }
        else
        {
            playerSprite.flipX = false;
            sprite.flipY = false;
        }
    }

    private void Fire()
    {
        CinemachineShake.Instance.ShakeCamera(5, 0.1f);
        nextFire = Time.time + fireRate;
        shootAudio.Play();
        GameObject cloneBullet = Instantiate(bullet, bulletSpawn.position, transform.rotation);
    }
}
