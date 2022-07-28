using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

using MikrosClient;
using MikrosClient.Analytics;


public class GtpdController : MonoBehaviour
{
 
    //private const string HORIZONTAL = "Horizontal";
    //private const string VERTICAL = "Vertical";

    //private float horizontalInput;
    //private float verticalInput;
    //private float currentSteerAngle;
    //private float currentBrakeForce;
    //private bool isBraking;

    //[SerializeField] private float motorForce;
    //[SerializeField] private float brakeForce;
    //[SerializeField] private float maxSteerAngle;

    //[SerializeField] private WheelCollider frontLeftWheelCollider;
    //[SerializeField] private WheelCollider frontRightWheelCollider;
    //[SerializeField] private WheelCollider rearLeftWheelCollider;
    //[SerializeField] private WheelCollider rearRightWheelCollider;


    public Transform player;
    public int MoveSpeed = 6;
    public int MaxDist = 20;
    public int MinDist = 10;
 
    [SerializeField] private GameObject blackPanel;
    [SerializeField] private Animator anim;

    void Start()
    {
 
    }
 
    void Update()
    {
        transform.LookAt(player);
        //Debug.Log(Vector3.Distance(transform.position, player.position));
 
        if (Vector3.Distance(transform.position, player.position) >= MinDist)
        {
 
            transform.position += transform.forward * (MoveSpeed * Time.deltaTime);
 
            if (Vector3.Distance(transform.position, player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
                
                StartCoroutine(TheSequence());
            }
 
        }
    }

    IEnumerator TheSequence() {
        
        
        
        anim.SetBool("Fade", true);
        yield return new WaitForSeconds(1f);
        //yield return new WaitUntil(()=>blackPanel.color.a==1);
        SceneManager.LoadScene("defeatCutscene");

        MikrosManager.Instance.AnalyticsController.LogEvent("Player Caught by Police", (Hashtable customEventWholeData) =>
        {
            Debug.Log("You lose hoe (Mikros succesful log)");
        },
        onFailure =>
        {
            Debug.Log("You lost but Mikros did not log it.");
        });
        MikrosManager.Instance.AnalyticsController.FlushEvents();

        //SceneManager.UnloadSceneAsync("test");
    }
    
}