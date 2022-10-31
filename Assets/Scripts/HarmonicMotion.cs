using UnityEngine;

public class HarmonicMotion : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] private float amplitude = 2, period = 1;

    void Update()
    {
        float factor = Time.time / period;
        float x = amplitude * Mathf.Sin(2 * Mathf.PI * factor);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
