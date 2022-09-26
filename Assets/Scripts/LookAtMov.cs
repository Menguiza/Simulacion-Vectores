using UnityEngine;

public class LookAtMov : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    
    //Variables de Utilidad
    private Vector2 velocity;
    private byte zero = 0, two = 2;
    private new Camera camera;

    void Awake()
    {
        camera = Camera.main;
    }

    void Update()
    {
        Vector2 mousePosition = GetMousePos();
        
        Vector3 direction = (mousePosition - (Vector2)transform.position).normalized;
        
        velocity = direction * speed;
        
        LookAtFuction((Vector2)transform.position + velocity);
        
        ReachDestiny();
    }
    
    #region Metodos
    
    void ReachDestiny()
    {
        Vector3 destiny = new Vector3(velocity.x, velocity.y, zero);
        transform.position += destiny * Time.deltaTime;
    }
    
    void LookAtFuction(Vector2 targetPosition)
    {
        Vector2 forward = targetPosition - (Vector2)transform.position;
        float radians = Mathf.Atan2(forward.y, forward.x) - Mathf.PI / two;
        
        Rotate(radians);
    }

    Vector4 GetMousePos()
    {
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = camera.ScreenToWorldPoint(screenPos);
        
        return worldPos;
    }

    void Rotate(float radians)
    {
        transform.rotation = Quaternion.Euler(zero, zero, radians * Mathf.Rad2Deg);
    }
    
    #endregion
}
