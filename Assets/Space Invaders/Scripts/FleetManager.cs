using System.Collections.Generic;
using UnityEngine;

public class FleetManager : MonoBehaviour
{
    [SerializeField] List<GameObject> fleets, activeFleets;

    void Start()
    {
        SpawnFleet();
    }

    void Update()
    {
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

        if (!alienAlive)
            SpawnFleet();
    }

    void SpawnFleet()
    {
        int rand = Random.Range(0, fleets.Count);
        activeFleets.Add(Instantiate(fleets[rand], transform.position, Quaternion.identity));
    }
}
