using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    ZombiePooler zombiePooler;
    public Transform[] Points;
    public int Maxmum, zombieAmount;

    private void Start()
    {
        zombieAmount = 0;
        zombiePooler = ZombiePooler.Instance;
    }
    private void FixedUpdate()
    {
        if (zombieAmount < Maxmum)
        {
            zombiePooler.SpawnFromPool("Zombie", GetPoints(), Quaternion.identity);
            zombieAmount++;
        }
    }
    public Vector3 GetPoints()
    {
        return Points[Random.Range(0, Points.Length)].position;
    }
}
