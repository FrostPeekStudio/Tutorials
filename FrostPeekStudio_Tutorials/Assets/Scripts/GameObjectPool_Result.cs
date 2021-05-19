using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool_Result : MonoBehaviour
{
    private readonly Dictionary<int, Queue<GameObject>> objectPool = new Dictionary<int, Queue<GameObject>>();

    public static GameObjectPool_Result instance;
    private void Awake() => instance = this;

    private GameObject bufferObject;
    public GameObject GetObject(int id, Vector3 position, Vector3 rotation)
    {
        if (objectPool.TryGetValue(id, out Queue<GameObject> objectList))
        {
            if (objectList.Count == 0)
            {
                return CreateObject(gameObject, position, rotation);
            }
            else
            {
                bufferObject = objectList.Dequeue();

                bufferObject.transform.SetPositionAndRotation(position, Quaternion.Euler(rotation));
                bufferObject.SetActive(true);
                return bufferObject;
            }
        }
        else return CreateObject(gameObject, position, rotation);
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
    private GameObject CreateObject(GameObject gameObject, Vector3 position, Vector3 rotation)
    {
        bufferObject = Instantiate(gameObject, position, Quaternion.Euler(rotation), transform);
        bufferObject.name = gameObject.name;
        return bufferObject;
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
