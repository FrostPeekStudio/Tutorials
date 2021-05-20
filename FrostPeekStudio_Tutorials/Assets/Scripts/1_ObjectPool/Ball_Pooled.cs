using UnityEngine;

public class Ball_Pooled : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    private const float lifeTime = 3f;
    private float timer;

    private void OnEnable()
    {
        timer = 0f;
        rb.AddForce(new Vector3(Random.Range(-5f, 5f), Random.Range(6f, 11f), Random.Range(-5f, 5f)), ForceMode.Impulse);
    }
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer >= lifeTime)
        GameObjectPool.instance.ReturnGameObject(1, gameObject);
    }
}
