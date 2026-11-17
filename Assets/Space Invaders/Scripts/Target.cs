using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] float moveDirection = 1, moveSpeed = 3.0f, moveDelay = 0.5f, dropDistance = 0.5f, timeStamp;
    [SerializeField] public List<GameObject> bullets, aliens, bottomRow;

    void Update()
    {
        // Move the Fleet
        transform.Translate(Vector2.right * moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ShipBullet")
        {
            collision.otherCollider.gameObject.SetActive(false);
        }

        // Bounce off Borders
        if (collision.transform.tag == "Boundry" && Time.time > timeStamp + moveDelay)
        {
            timeStamp = Time.time;
            moveDirection = -moveDirection;
            transform.position += Vector3.down * dropDistance;
        }
    }
}