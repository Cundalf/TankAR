using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public GameObject bulletPrefab;

    public void Fire(float force)
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = Instantiate(
            bulletPrefab,
            transform.position,
            transform.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * force;
        
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
