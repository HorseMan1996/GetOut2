using System.Collections.Generic;
using Systems.PoolSystem.Data.UnityObject;
using Systems.PoolSystem.Enum;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public CD_Pool database;

    private Dictionary<ObjectType, Queue<GameObject>> poolDictionary;

    void Awake()
    {
        poolDictionary = new Dictionary<ObjectType, Queue<GameObject>>();

        foreach (var pool in database.pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.key, objectPool);
        }
    }

    public GameObject Spawn(ObjectType key, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(key))
        {
            Debug.LogError("Pool bulunamadý: " + key);
            return null;
        }

        GameObject obj = poolDictionary[key].Dequeue();

        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

        poolDictionary[key].Enqueue(obj);

        return obj;
    }
}