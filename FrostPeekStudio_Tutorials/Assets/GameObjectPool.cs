using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    private readonly Dictionary<int, Queue<GameObject>> objectPool = new Dictionary<int, Queue<GameObject>>();

    public static GameObjectPool instance;
    private void Awake()
    {
        instance = this;
    }
    public GameObject GetObject(int id, GameObject gameObject, Vector3 position, Vector3 rotation) 
    {
        if (objectPool.TryGetValue(id, out Queue<GameObject> objectList))
        {
            if (objectList.Count == 0)
            {
                return CreateObject(gameObject, position, rotation);
            }
            else
            {
                GameObject obj = objectList.Dequeue();
                obj.transform.SetPositionAndRotation(position, Quaternion.Euler(rotation));
                obj.SetActive(true);
                return obj;
            }
        }
        else return CreateObject(gameObject, position, rotation);
    }
    private GameObject CreateObject(GameObject gameObject, Vector3 position, Vector3 rotation) 
    {
        GameObject obj = Instantiate(gameObject, position, Quaternion.Euler(rotation), transform);
        return obj;
    }
    public void ReturnGameObject(int id, GameObject gameObject) 
    {
        gameObject.SetActive(false);
        if (objectPool.TryGetValue(id, out Queue<GameObject> objectList))
        {
            objectList.Enqueue(gameObject);
        }
        else 
        {
            Queue<GameObject> newObjectQueue = new Queue<GameObject>();
            newObjectQueue.Enqueue(gameObject);
            objectPool.Add(id, newObjectQueue);
        }
    }
    public void PreloadObject(int amount, int id, GameObject gameObject) 
    {
        for (int i = 0; i < amount; i++) 
        {
            GameObject obj = CreateObject(gameObject, Vector3.zero, Vector3.zero);
            ReturnGameObject(id, obj);
        }
    }
}
