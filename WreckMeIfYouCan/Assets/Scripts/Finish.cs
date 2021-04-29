using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject blackPanel;
    [SerializeField] private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            StartCoroutine(TheSequence());
        }
    }
    IEnumerator TheSequence() {
        anim.SetBool("Fade", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("win");
    }
}