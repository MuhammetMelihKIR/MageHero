using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    public static ObjectsPool Instance;
    
    public Queue<GameObject> PooledObjects;
    
    [SerializeField] private GameObject objectPrefabs;
    [SerializeField] private GameObject spawnTransform;
    [SerializeField] private int poolSize;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        PooledObjects = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate((objectPrefabs));
            obj.SetActive(false);
            obj.transform.parent = gameObject.transform;
            PooledObjects.Enqueue(obj);
           
        }
    }

    public void DequeueObject()
    {
        GameObject obj = PooledObjects.Dequeue();
        obj.transform.position = spawnTransform.transform.position;
        obj.SetActive(true);
    }

    public void EnqueueObject(GameObject obj)
    {
        PooledObjects.Enqueue(obj);
        obj.transform.position = spawnTransform.transform.position;
        obj.SetActive(false);
    }
}
