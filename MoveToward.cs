using UnityEngine;

public class MoveToward : MonoBehaviour
{
    bool move = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (!move) return;
        // Move toward the -Z axis (toward the player)
        transform.parent.Translate(0, 0, -10 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        move = true;
    }
}