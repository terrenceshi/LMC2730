using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class GtpdController2 : MonoBehaviour
{
 
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBrakeForce;
    private bool isBraking;

    [SerializeField] private float motorForce;
    [SerializeField] private float brakeForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    [SerializeField] private Transform player;
    [SerializeField] private int MoveSpeed = 3;
    [SerializeField] private int MaxDist = 20;
    [SerializeField] private int MinDist = 10;

    //[SerializeField] private float loseCondition = 5f;
    [SerializeField] private GameObject blackPanel;
    [SerializeField] private Animator anim;
 
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        
    }

    private void GetInput()
    {

        if (Vector3.Distance(transform.position, player.position) >= MinDist)
        {
 
            //transform.position += transform.forward * (MoveSpeed * Time.deltaTime);
 
            //horizontalInput = Input.GetAxis(HORIZONTAL);
            transform.LookAt(player);
            
            verticalInput = 2 * MoveSpeed;
 
            if (Vector3.Distance(transform.position, player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
                Debug.Log("\nsup");
                //loseCondition -= Time.deltaTime;
                //if(loseCondition <= 0) {
                    //StartCoroutine(TheSequence());
                    
                //}
                StartCoroutine(TheSequence());
            }
            
        }
        else
        {
            ApplyBraking();
        }
    }
    
   IEnumerator TheSequence() {
        anim.SetBool("Fade", true);
        yield return new WaitForSeconds(1f);
        //yield return new WaitUntil(()=>blackPanel.color.a==1);
        SceneManager.LoadScene("defeatCutscene");
   }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentBrakeForce = isBraking ? brakeForce : 0f;
           
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void ApplyBraking()
    {
        frontRightWheelCollider.brakeTorque = currentBrakeForce;
        frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearRightWheelCollider.brakeTorque = currentBrakeForce;
        rearLeftWheelCollider.brakeTorque = currentBrakeForce;

    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;

        wheelTransform.rotation *= Quaternion.Euler(0, 0, 90f);

        //Debug.Log("\nrot: " + rot + ", pos: " + pos);
    }
    
}