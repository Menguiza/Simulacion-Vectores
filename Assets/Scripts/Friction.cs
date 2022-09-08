using UnityEngine;

public class Friction : MonoBehaviour
{
    private MyVector position, acceleration, velocity;
    
    [SerializeField] bool fluidFriction = false;
    [SerializeField] float mass = 1;
    [SerializeField][Range(0, 1)] float frictionCoefficient, damping = 1;

    //Utilidad
    private byte five = 5, one = 1, zero = 0;
    private float gravity = -9.8f, coefficient = 0.5f;
    
    private void Start()
    {
        position = transform.position;
    }
    
    private void FixedUpdate()
    {
        float weightScalar = mass * gravity;
        MyVector weight = new MyVector(zero, weightScalar);
        MyVector friction = velocity.Normalized * frictionCoefficient * -weightScalar * -one;
        
        acceleration *= zero;
        
        ApplyForce(weight);
        ApplyForce(friction);
        
        if (fluidFriction && position.y <= zero)
        {
            float velocityMagnitude = velocity.Magnitude;
            float frontalArea = transform.localScale.x;
            MyVector fFriction = velocity.Normalized * frontalArea * velocityMagnitude * velocityMagnitude * -coefficient;
            ApplyForce(fFriction);
            fFriction.Draw(position, Color.red);
        }
        
        friction.Draw(position, Color.green);
        
        Move();
    }
    
    private void Update()
    {
        velocity.Draw(position, Color.blue);
    } 
    
    void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
        
        if (Mathf.Abs(position.x) >= five)
        {
            position.x = Mathf.Sign(position.x) * five;
            velocity.x *= -one;
            velocity *= damping;
        }
        
        if (Mathf.Abs(position.y) >= five)
        {
            position.y = Mathf.Sign(position.y) * five;
            velocity.y *= -one;
            velocity *= damping;
        }
        
        transform.position = position;
    }
    
    void ApplyForce(MyVector force)
    {
        acceleration += force * (1f / mass);
    }
}
