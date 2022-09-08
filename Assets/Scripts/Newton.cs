using UnityEngine;

public class Newton : MonoBehaviour
{
    private MyVector position, acceleration;
    [SerializeField] private MyVector velocity;
    [SerializeField] private float mass = 1;
    [SerializeField] Newton target;

    //Utilidad
    private byte three = 3, one = 1, zero = 0;
    
    private void Start()
    {
        position = transform.position;
    }
    
    private void FixedUpdate()
    {
        MyVector r = target.transform.position - transform.position;
        float magnituder = r.Magnitude;
        MyVector F = r.Normalized * (one / target.mass * mass / magnituder * magnituder);
        
        acceleration *= zero;
        
        ApplyForce(F);
        Move();
        F.Draw(position, Color.red);
    }
    
    private void Update()
    {
        velocity.Draw(position, Color.green);
    }
    
    public void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;

        if (velocity.Magnitude >= three)
        {
            velocity = velocity.Normalized;
            velocity *= three;
        }
        
        transform.position = position;
    }
    
    void ApplyForce(MyVector force)
    {
        acceleration += force * (one / mass);
    }
}
