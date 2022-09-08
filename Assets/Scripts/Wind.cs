using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] float mass = 1;
    [SerializeField] MyVector wind;
    [SerializeField][Range(0, 1)] float damping = 1;
    private MyVector position, velocity, acceleration, gravity = new MyVector(0,-9.8f);

    //Utilidad
    private byte five = 5, one = 1;
    private Camera _camera;
    
    private void Start()
    {
        position = transform.position;
        _camera =  Camera.main;
    }
    
    private void FixedUpdate()
    {
        acceleration *= 0f;
        ApplyForce(wind);
        ApplyForce(gravity);
        Move();
    }
    
    private void Update()
    {
        position.Draw(Color.red);
        velocity.Draw(position, Color.green);
        acceleration.Draw(position, Color.blue);
    }
    
    void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
        
        if (Mathf.Abs(position.y) >= five)
        {
            position.y = Mathf.Sign(position.y) * five;
            velocity.y *= -one;
            velocity *= damping;
        }

        transform.position = position;
        
        if (Mathf.Abs(position.x) >= five)
        {
            position.x = Mathf.Sign(position.x) * five;
            velocity.x *= -one;
            velocity *= damping;
        }
    }
    
    void ApplyForce(MyVector force)
    {
        acceleration += force * (one / mass);
    }
}
