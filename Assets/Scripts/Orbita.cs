using UnityEngine;

public class Orbita : MonoBehaviour
{
    [SerializeField] float mass = 1, targetMass = 1;
    [SerializeField] Transform target;
    private MyVector position, acceleration, velocity = new MyVector(0,1);
    
    //Utilidad
    private byte one = 1, zero = 0;
    
    private void Start()
    {
        position = transform.position;
    }
    
    private void FixedUpdate()
    {
        MyVector r = target.position - transform.position;
        float magnituder = r.Magnitude;
        MyVector f = r.Normalized * (one / targetMass * mass / magnituder * magnituder);
        
        acceleration *= zero;

        ApplyForce(f);
        Move();
        
        f.Draw(position, Color.red);
    }
    
    private void Update()
    {
        velocity.Draw(position, Color.green);
    }
    
    void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
        transform.position = position;
    }
    
    void ApplyForce(MyVector force)
    {
        acceleration += force * (one / mass);
    }
}
