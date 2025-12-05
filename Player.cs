using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public float turnSpeed = 4;
    public float tiltAmount = 15f; // how much to tilt the camera
    public float tiltSmooth = 5f;  // how quickly to tilt

    public GameObject prefabMusic;
    public GameObject playerGeo;

    private Quaternion baseCamRot; // store camera’s neutral rotation
    
    //Effects
    public ParticleSystem dieParticle;

    void Start()
    {
        var music = GameObject.Find("BgMusic");
        if (music == null)
        {
            var m = Instantiate(prefabMusic, null);
            m.name = "BgMusic";
            DontDestroyOnLoad(m);
        }

        // Save the camera's starting rotation as neutral
        if (Camera.main != null)
            baseCamRot = Camera.main.transform.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
            return;
        }

        // Control with Horizontal Direction with A/D
        float x = Input.GetAxis("Horizontal");
        transform.Translate(x * turnSpeed * Time.deltaTime, 0, speed * Time.deltaTime);

        // --- Camera tilt ---
        if (Camera.main != null)
        {
            var targetRot = baseCamRot * Quaternion.Euler(0, 0, -x * tiltAmount);
            Camera.main.transform.rotation = Quaternion.Slerp(
                Camera.main.transform.rotation,
                targetRot,
                tiltSmooth * Time.deltaTime
            );
        }

        // --- Boundary checks ---
        if (transform.position.x < -4 || transform.position.x > 4)
            transform.Translate(0, -speed * Time.deltaTime, 0);

        if (transform.position.y < -20)
            Time.timeScale = 0;
    }

    public void die()
    {
        Debug.Log("Die");
        playerGeo.SetActive(false);
    }
}