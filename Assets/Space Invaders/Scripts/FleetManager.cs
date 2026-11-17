using System.Collections.Generic;
using UnityEngine;

public class FleetManager : MonoBehaviour
{
    [SerializeField] List<GameObject> fleets, activeFleets;
    [SerializeField] float fleetSpacing = 1.3f;

    void Start()
    {
        // Create Initial Fleets
        SpawnFleet();
    }

    void Update()
    {
        // Determine if there are still Aliens alive
        bool alienAlive = false;
        for (int i = 0; i < activeFleets.Count; i++)
        {
            Target fleetScript = activeFleets[i].GetComponent<Target>();
            for (int i2 = 0; i2 < fleetScript.aliens.Count; i2++)
            {
                if (fleetScript.aliens[i2].activeSelf == true)
                    alienAlive = true;
            }
        }

        // If all the Aliens are dead, spawn a new fleet
        if (!alienAlive)
        {
            // Destroy and Clear the old fleet
            for (int i = 0; i < activeFleets.Count; i++)
            {
                Destroy(activeFleets[i]);
            }
            activeFleets.Clear();

            // Spawn a new
            SpawnFleet();
        }
    }

    void SpawnFleet()
    {
        // Spawn two Alien fleets
        for (int i = 0; i < 2; i ++)
        {
            int rand = Random.Range(0, fleets.Count);
            activeFleets.Add(Instantiate(fleets[rand], transform.position + Vector3.down * (i * fleetSpacing), Quaternion.identity));
        }
    }
}
