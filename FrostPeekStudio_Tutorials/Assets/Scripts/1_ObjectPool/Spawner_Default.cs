using UnityEngine;

public class Spawner_Default : MonoBehaviour
{
    [SerializeField] GameObject spawnedPrefab;
    [SerializeField] int spawnRate;
    void FixedUpdate()
    {
        if (Time.frameCount % spawnRate == 0)
        {
            DefaultSpawn();
        }
    }
    private void DefaultSpawn() => Instantiate(spawnedPrefab, transform.position, Quaternion.identity, transform);
}
