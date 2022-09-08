using UnityEngine;

public class VelocityandAceleration : MonoBehaviour
{
    private MyVector acceleration, velocity, position;
    
    [SerializeField] [Range(0f, 1f)] private float dampingFactor = 0.9f;
    
    private Camera _camera;
    private int currentAcceleration = 0;
    
    //Utilidad
    float fix = 0.5f;
    
    private readonly MyVector[] directions = new MyVector[4]
    {
        new MyVector(0,-9.8f),
        new MyVector(9.8f,0),
        new MyVector(0,9.8f),
        new MyVector(-9.8f,0)
    };

    void Start()
    {
        position = new MyVector(transform.position.x, transform.position.y);
        _camera = Camera.main;
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        velocity.Draw(position, Color.red);
        position.Draw(Color.blue);
        acceleration.Draw(position, Color.green);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            acceleration = directions[(currentAcceleration++) % directions.Length];
            velocity *= 0;
        }

    }
    void Move()
    {
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;


        if (position.x > _camera.orthographicSize-fix)
        {
            velocity.x *= -1;
            position.x = _camera.orthographicSize-fix;
            velocity *= dampingFactor;
        }
        else if (position.x < -_camera.orthographicSize+fix)
        {
            velocity.x *= -1;
            position.x = -_camera.orthographicSize+fix;
            velocity *= dampingFactor;
        }

        if (position.y > _camera.orthographicSize-fix)
        {
            velocity.y *= -1;
            position.y = _camera.orthographicSize-fix;
            velocity *= dampingFactor;
        }
        else if (position.y < -_camera.orthographicSize+fix)
        {
            velocity.y *= -1;
            position.y = -_camera.orthographicSize+fix;
            velocity *= dampingFactor;
        }
        
        transform.position = new Vector3(position.x, position.y, 0);
    }
}
