using UnityEngine;

public class Barrier : MonoBehaviour
{
    private GameController gameController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = GameController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            Debug.Log("GameOver");
            gameController.isGameOver = true;
            gameController.playerObject.speed = 0;
            gameController.playerObject.dieParticle.Play();
            gameController.playerObject.die();
            //Time.timeScale = 0;
        }
    }
}
