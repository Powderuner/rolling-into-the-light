using UnityEngine;

public class Lift : MonoBehaviour
{
    bool lift = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!lift) return;
        transform.parent.Translate(0, 10 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        lift = true;
    }
}
