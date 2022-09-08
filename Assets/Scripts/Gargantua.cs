using UnityEngine;

public class Gargantua : MonoBehaviour
{
    [SerializeField] Transform target;
    private MyVector position, displacement, velocity, acceleration;
    
    private readonly MyVector[] accelerations = new MyVector[4]
    {
        new MyVector(0,-9.8f),
        new MyVector(9.8f,0f),
        new MyVector(0,9.8f),
        new MyVector(-9.8f,0f),
    };
    private void Start()
    {
        position = transform.position; 
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        position.Draw(Color.red);
        displacement.Draw(position, Color.green);
        velocity.Draw(position, Color.blue);
        acceleration = target.position - transform.position;
    }
    
    void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
        transform.position = position;
    }
}
