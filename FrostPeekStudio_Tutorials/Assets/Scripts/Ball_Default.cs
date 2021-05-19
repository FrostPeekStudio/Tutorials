using UnityEngine;

public class Ball_Default : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private void Start()
    {
        rb.AddForce(new Vector3(Random.Range(2f, 5f), Random.Range(4f, 10f), Random.Range(2f, 5f)), ForceMode.Impulse);
        Destroy(gameObject, 3f);
    }
}
