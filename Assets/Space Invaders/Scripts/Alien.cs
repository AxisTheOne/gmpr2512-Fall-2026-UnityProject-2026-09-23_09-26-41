using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] float fireStamp, bulletSpeed = 5.0f, ammo = 1.0f, minFire = 0.5f, maxFire = 3.0f;
    [SerializeField] List<GameObject> bullets;
    [SerializeField] GameObject bullet;

    public bool bottomRow = false;

    Vector2 weaponLocation;
    float fireTime = 0f;

    void Start()
    {
        fireTime = Random.Range(minFire, maxFire);
        for (int i = 0; i < ammo; i++)
        {
            bullets.Add(Instantiate(bullet, Vector3.zero, Quaternion.identity));
            bullets[i].SetActive(false);
        }
    }

    void Update()
    {
        bottomRow = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, 3.0f);
        if (hit.collider == null)
        {
            bottomRow = true;
        }

        if (Time.time > fireStamp + fireTime)
        {
            fireStamp = Time.time;
            fireTime = Random.Range(minFire, maxFire);

            bool found = !bottomRow;
            weaponLocation = transform.position + Vector3.down;

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
}
