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

    public GameObject grass;
    public Animator grassAnim;

    public GameObject wreck;
    public Animator wreckAnim;

    public GameObject gtpd0;
    public Animator gtpd0Anim;

    public GameObject gtpd1;
    public Animator gtpd1Anim;

    public GameObject gtpd2;
    public Animator gtpd2Anim;

    public GameObject gtpd3;
    public Animator gtpd3Anim;

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
        grassAnim.SetBool("soundFade", true);
        gtpd0Anim.SetBool("soundFade", true);
        gtpd1Anim.SetBool("soundFade", true);
        gtpd2Anim.SetBool("soundFade", true);
        gtpd3Anim.SetBool("soundFade", true);
        wreckAnim.SetBool("soundFade", true);
        //yield return new WaitUntil(()=>blackPanel.color.a==1);
    }
}
