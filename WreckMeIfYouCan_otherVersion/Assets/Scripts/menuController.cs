using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("test");
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("bye!!");
            Application.Quit();
        }
    }
}
