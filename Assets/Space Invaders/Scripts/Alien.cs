using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] float fireStamp, bulletSpeed = 5.0f, ammo = 1.0f, minFire = 0.5f, maxFire = 3.0f;
    [SerializeField] List<GameObject> bullets;
    [SerializeField] GameObject bullet;

    LayerMask layerMask;
    Vector2 weaponLocation;
    float fireTime = 0f;
    bool bottomRow = false;

    void Start()
    {
        // Layermask for Raycasting, and timers
        layerMask = LayerMask.GetMask("Alien");
        fireStamp = Time.time;
        fireTime = Random.Range(minFire, maxFire);

        // Create Bullet Instances
        for (int i = 0; i < ammo; i++)
        {
            bullets.Add(Instantiate(bullet, Vector3.zero, Quaternion.identity));
            bullets[i].SetActive(false);
        }
    }

    void Update()
    {
        // Check if this Alien has anything blocking its fire
        bottomRow = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, 3.0f, layerMask);
        if (hit.collider == null)
        {
            bottomRow = true;
        }

        if (Time.time > fireStamp + fireTime)
        {
            // Set timers
            fireStamp = Time.time;
            fireTime = Random.Range(minFire, maxFire);

            // Shoot Location and Found
            bool found = !bottomRow;
            weaponLocation = transform.position + Vector3.down;

            // Find an Available Bullet and Fire
            for (int i = 0; i < bullets.Count && !found; i++)
            {
                if (bullets[i].activeSelf == false)
                {
                    found = true;
                    bullets[i].transform.position = weaponLocation;
                    bullets[i].transform.rotation = Quaternion.identity;

                    bullets[i].SetActive(true);

                    bullets[i].GetComponent<Rigidbody2D>().linearVelocity = -bullets[i].transform.up * bulletSpeed;
                }
            }
        }
    }

    void OnDestroy()
    {
        // Clean up Projectiles to prevent stackup
        for (int i = 0; i < bullets.Count; i++)
        {
            Destroy(bullets[i]);
        }
    }
}
