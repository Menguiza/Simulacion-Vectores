using UnityEngine;

public class LookAt : MonoBehaviour
{
    //Variables de Utilidad
    private new Camera camera;
    private byte zero = 0, two = 2;

    void Awake()
    {
        camera = Camera.main;
    }

    void Update()
    {      
        Vector4 mousePos = GetMousePos();
        LookAtFunction(mousePos);
    }

    #region Metodos

    void LookAtFunction(Vector2 targetPosition)
    {
        Vector2 forward = targetPosition - (Vector2)transform.position;
        
        float rad = Mathf.Atan2(forward.y, forward.x) - Mathf.PI / two;
        
        Rotate(rad);
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
