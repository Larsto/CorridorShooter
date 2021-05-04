using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    public GameObject cam1, cam2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            Player1();
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            Player2();
        }
    }

    void Player1()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    void Player2()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}

