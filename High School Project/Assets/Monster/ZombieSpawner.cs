using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XANFSM.zombie
{
    public class ZombieSpawner : MonoBehaviour
    {
        ZombiePooler zombiePooler;
        public Transform[] Points;
        public int Maxmum, zombieAmount = 0, Maxmum_2, rangerAmount = 0;

        void Start()
        {
            zombiePooler = ZombiePooler.Instance;
        }
        void FixedUpdate()
        {
            if (zombieAmount < Maxmum)
            {
                zombiePooler.SpawnFromPool("Zombie", GetPoints(), Quaternion.identity);
                zombieAmount++;
            }
            if (rangerAmount < Maxmum)
            {
                zombiePooler.SpawnFromPool("Ranger", GetPoints(), Quaternion.identity);
                rangerAmount++;
            }
        }
        public Vector3 GetPoints()
        {
            return Points[Random.Range(0, Points.Length)].position;
        }
    }
}