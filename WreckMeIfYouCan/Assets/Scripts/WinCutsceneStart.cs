using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCutsceneStart : MonoBehaviour
{
    [SerializeField]
    private GameObject Cam1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        Cam1.SetActive(true);
        yield return new WaitForSeconds(4.15f);
    }
}
