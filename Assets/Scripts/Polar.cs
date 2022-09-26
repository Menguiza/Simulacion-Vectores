using UnityEngine;

public class Polar : MonoBehaviour
{
    [SerializeField] private float speed, speedR, acelerationR;
    
    //Variables de Utilidad
    private MyVector referencePoint;
    private byte zero = 0, one = 1, five = 5;

    void Update()
    {
        AngularVelocity();
        
        transform.position = Polar2Cartesian(referencePoint);

        CheckForLimits();
    }

    #region Metodos

    void AngularVelocity()
    {
        referencePoint.x += Time.deltaTime * speedR;
        referencePoint.y += Time.deltaTime * speed;
    }
    
    MyVector Polar2Cartesian(MyVector point)
    {
        float x = Mathf.Cos(point.y * Mathf.Deg2Rad) * point.x, y = Mathf.Sin(point.y * Mathf.Deg2Rad) * point.x;
        
        MyVector dir = new MyVector(x, y);
        
        return dir;
    }
    void CheckForLimits()
    {
        if (Mathf.Abs(referencePoint.x) >= five)
        {
            referencePoint.x = Mathf.Sign(referencePoint.x) * five;
            
            if (Mathf.Abs(acelerationR) > zero)
            {
                acelerationR = -acelerationR; 
                speedR *= -one;
            }
            else 
            {
                speedR = -speedR; 
            }
        }
    }

    #endregion
}
