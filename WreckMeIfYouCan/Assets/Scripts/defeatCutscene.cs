using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defeatCutscene : MonoBehaviour
{
	public GameObject Cam1;
	public GameObject Cam2;
    //public GameObject Cam3;
    //public GameObject Cam4;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence() {
        //Cam4.SetActive(false);
        //Cam3.SetActive(false);
        Cam2.SetActive(false);
        Cam1.SetActive(true);
    	yield return new WaitForSeconds(6.5f);
    	Cam2.SetActive(true);
    	Cam1.SetActive(false);
        //yield return new WaitForSeconds(2.15f);
        //Cam3.SetActive(true);
        //Cam2.SetActive(false);
        //yield return new WaitForSeconds(2.1f);
        //Cam4.SetActive(true);
        //Cam3.SetActive(false);
    }
}
