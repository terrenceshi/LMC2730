using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCutsceneStart : MonoBehaviour
{
    [SerializeField] private GameObject Cam1;
    [SerializeField] private GameObject blackPanel;
    [SerializeField] private Animator anim;

    public GameObject wreck;
    public Animator wreckAnim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        Cam1.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        anim.SetBool("Fade", true);
        wreckAnim.SetBool("soundFade", true);
        yield return new WaitForSeconds(2.25f);
        SceneManager.LoadScene("winScreen");
    }
}
