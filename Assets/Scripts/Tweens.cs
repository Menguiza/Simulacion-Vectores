using UnityEngine;

public class Tweens : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField, Range(0, 1)] float tParameter = 0;
    [SerializeField] Color initialColor, targetColor;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] Transform target;
    
    //Variables de Utilidad
    float currentTime;
    Vector3 initialPosition, targetPosition;
    new Renderer renderer;
    private bool easeActive, tweenInfo;
    
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (tweenInfo)
        {
            tParameter = currentTime / time;
        
            if (!easeActive)
            {
                transform.position = Vector3.LerpUnclamped(initialPosition, targetPosition, curve.Evaluate(tParameter));
                renderer.material.color = Color.LerpUnclamped(initialColor, targetColor, curve.Evaluate(tParameter));
            }
            else
            {
                transform.position = Vector3.LerpUnclamped(initialPosition, targetPosition, EaseInElastic(tParameter));
                renderer.material.color = Color.LerpUnclamped(initialColor, targetColor, EaseInElastic(tParameter));
            }
        
            currentTime += Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            Tween();
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeEase();
        }
    }

    private void Tween()
    {
        tParameter = 0;
        currentTime = 0;
        initialPosition = transform.position;
        targetPosition = target.position;
        tweenInfo = true;
    }

    private float EaseInElastic(float x)
    {
        float c5 = (2f * Mathf.PI) / 4.5f;
        return x == 0f ? 0f : x == 1f ? 1f : x < 0.5 ? -(Mathf.Pow(2f, 20f * x - 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f : (Mathf.Pow(2f, -20f * x + 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f + 1f;
    }

    private void ChangeEase()
    {
        easeActive = !easeActive;
        Debug.Log("Changed");
    }
}
