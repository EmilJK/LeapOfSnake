using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAi : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float fireCd = 2;
    public float cdSet = 2;
    bool canShoot;

    // Update is called once per frame
    void Update()
    {
        CooldownnTimer();

        if(canShoot)
            Shoot();
    }

    private void CooldownnTimer()
    {
        if (fireCd <= 0)
            canShoot = true;
        else
            fireCd -= Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        fireCd = cdSet;
        canShoot = false;
    }
}
