using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
    [Header("Variaveis numericas")]
    [SerializeField] private int maxAmmo;
    [SerializeField] private float fireRate;

    [Header("Variaveis de objeto")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn;

    [Header("Variaveis de texto")]
    [SerializeField] private Text ammoText;

    private float nextFire;
    private int currentAmmo;
     
    //Pega o componente das variaveis
    private void Start() => currentAmmo = maxAmmo;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire) Fire();
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo) currentAmmo = maxAmmo;

        ammoText.text = "Ammo: " + currentAmmo.ToString();
    }

    private void Fire()
    {
        currentAmmo--;
        nextFire = Time.time + fireRate;

        if (currentAmmo >= 0) Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        else currentAmmo = 0;
    }
}
