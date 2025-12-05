using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public float speed = 3f;      // Movement speed
    public float range = 4f;      // Moves from -range to +range relative to start
    private Vector3 startPos;
    private int direction = 1;    // 1 = right, -1 = left

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Move left and right along WORLD X-axis (ignores rotation)
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime, Space.World);

        // Reverse direction when reaching boundaries
        if (transform.position.x > startPos.x + range)
        {
            direction = -1;
        }
        else if (transform.position.x < startPos.x - range)
        {
            direction = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Time.timeScale = 0;
        }
    }
}