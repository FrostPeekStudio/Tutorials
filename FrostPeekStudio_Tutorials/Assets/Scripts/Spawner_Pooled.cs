using UnityEngine;

public class Spawner_Pooled : MonoBehaviour
{
    [SerializeField] GameObject spawnedPrefab;
    [SerializeField] int spawnRate;

    private void Start()
    {
        GameObjectPool_Result.instance.PreloadObject(200, 1, spawnedPrefab);
    }
    private void FixedUpdate()
    {
        if (Time.frameCount % spawnRate == 0)
        {
            SpawnFromPool();
        }
    }
    private void SpawnFromPool() => GameObjectPool_Result.instance.GetObject(1, spawnedPrefab, transform.position, Vector3.zero);
}
