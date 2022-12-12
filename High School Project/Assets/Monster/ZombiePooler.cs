using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XANFSM.zombie
{
    [System.Serializable]
    public class PoolItem
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public class ZombiePooler : MonoBehaviour
    {
        public GameObject inGamePool;

        public List<PoolItem> pools;
        Dictionary<string, Queue<GameObject>> poolDictionary;

        public static ZombiePooler Instance;
        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();
            foreach (PoolItem pool in pools)
            {
                Queue<GameObject> zombiePool = new Queue<GameObject>();
                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.transform.SetParent(inGamePool.transform);
                    obj.SetActive(false);
                    zombiePool.Enqueue(obj);
                }
                poolDictionary.Add(pool.tag, zombiePool);
            }
        }
        public GameObject SpawnFromPool(string tag, Vector3 positon, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.Log("Does not exist.");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();
            objectToSpawn.transform.position = positon;
            objectToSpawn.transform.rotation = rotation;
            objectToSpawn.SetActive(true);
            objectToSpawn.GetComponent<Zombie>().InitFSM();

            return objectToSpawn;
        }
        public void ZombieDead(string tag, GameObject zombie)
        {
            poolDictionary[tag].Enqueue(zombie);
            zombie.SetActive(false);
            GameObject.Find("ZombiePool").GetComponent<ZombieSpawner>().zombieAmount -= 1;
        }
    }
}