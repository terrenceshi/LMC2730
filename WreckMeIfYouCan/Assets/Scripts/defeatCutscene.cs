using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class defeatCutscene : MonoBehaviour
{
	public GameObject Cam1;
	public GameObject Cam2;

    public GameObject blackPanel;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence() {

        Cam2.SetActive(false);
        Cam1.SetActive(true);
    	yield return new WaitForSeconds(6.5f);
    	Cam2.SetActive(true);
    	Cam1.SetActive(false);
        yield return new WaitForSeconds(6f);
        anim.SetBool("Fade", true);
        //yield return new WaitUntil(()=>blackPanel.color.a==1);
    }
}
