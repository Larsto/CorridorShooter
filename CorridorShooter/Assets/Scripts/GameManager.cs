using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float waitAfterDying = 2f;

    public PlayerController activePlayer;
    public CameraController activeCamera;
    public List<PlayerController> allPlayers = new List<PlayerController>();
    public List<CameraController> allCameras = new List<CameraController>();


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SwitchPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            SwitchPlayer(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SwitchPlayer(1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            SwitchPlayer(2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            SwitchPlayer(3);
        }
    }

    public void PlayerDied()
    {
        StartCoroutine(PlayerDiedCo());
    }

    public IEnumerator PlayerDiedCo()
    {
        yield return new WaitForSeconds(waitAfterDying);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SwitchPlayer(int active)
    {

        activePlayer.gameObject.GetComponent<PlayerOverwatch>().enabled = true;
        activePlayer.gameObject.GetComponent<PlayerController>().enabled = false;
        activeCamera.gameObject.SetActive(false);


        activePlayer = allPlayers[active];
        activeCamera = allCameras[active];
        activePlayer.gameObject.GetComponent<PlayerOverwatch>().enabled = false;
        activePlayer.gameObject.GetComponent<PlayerController>().enabled = true;
        activeCamera.gameObject.SetActive(true);
    }
}
