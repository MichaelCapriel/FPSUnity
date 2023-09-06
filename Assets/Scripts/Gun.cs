using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    public float launchSpeed;
    public Transform spawnPoint;
    public GameObject projectilePrefab;
    public AudioSource shootsound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        print("Shoot");
        GameObject newProjectile = Instantiate(projectilePrefab, spawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * launchSpeed);
        Destroy(newProjectile, 5);
    }
}


