using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [Header("Assign your Finish Canvas (leave active in Hierarchy or not — script will hide it)")]
    public GameObject finishCanvas; // the canvas to show on finish

    [Tooltip("If true, timeScale will be set to 0 when finishing.")]
    public bool pauseOnFinish = true;

    private bool finished = false;

    void Start()
    {
        // If a canvas was assigned, make sure it's hidden at the start
        if (finishCanvas != null)
            finishCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // only trigger once and only for the Player tag
        if (finished) return;
        if (!other.CompareTag("Player")) return;

        finished = true;
        Debug.Log("Player reached the finish line!");

        if (finishCanvas != null)
            finishCanvas.SetActive(true);

        if (pauseOnFinish)
            Time.timeScale = 0f;
    }

}
