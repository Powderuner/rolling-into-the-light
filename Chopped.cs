using UnityEngine;
using System.Collections;

public class MoveUpDown : MonoBehaviour
{
    public float downDistance = 4f;   // How far it chops down
    public float chopSpeed = 20f;     // How fast it moves
    public float waitTime = 1f;       // Wait time at top before chopping again

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        StartCoroutine(ChopRoutine());
    }

    IEnumerator ChopRoutine()
    {
        while (true)
        {
            // --- Move down ---
            Vector3 targetDown = startPos - new Vector3(0, downDistance, 0);
            while (Vector3.Distance(transform.position, targetDown) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    targetDown,
                    chopSpeed * Time.deltaTime
                );
                yield return null;
            }

            // --- Instantly go back up ---
            while (Vector3.Distance(transform.position, startPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    startPos,
                    chopSpeed * Time.deltaTime
                );
                yield return null;
            }

            // --- Wait at the top before chopping again ---
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Chopped the player!");
            Time.timeScale = 0; // stop the game
        }
    }
}
