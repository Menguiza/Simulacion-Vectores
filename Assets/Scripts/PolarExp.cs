using UnityEngine;

public class PolarExp : MonoBehaviour
{
    [SerializeField] private float angle, speed;
    private float radio = 1;

    void Update()
    {
        AngularVelocity();
        Polar2Cartesian(angle, radio).Draw(Color.red);
    }

    #region Metodos
    
    void AngularVelocity()
    {
        angle -= speed * Time.deltaTime;
    }
    
    MyVector Polar2Cartesian(float angle, float radio)
    {
        float x = Mathf.Cos(angle * Mathf.Deg2Rad), y = Mathf.Sin(angle * Mathf.Deg2Rad);
        
        MyVector dir = new MyVector(x * radio, y * radio);
        
        return dir;
    }

    #endregion
}
