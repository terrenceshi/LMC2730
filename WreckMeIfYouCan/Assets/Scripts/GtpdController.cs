using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class GtpdController : MonoBehaviour
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

    //[SerializeField] private WheelCollider frontLeftWheelCollider;
    //[SerializeField] private WheelCollider frontRightWheelCollider;
    //[SerializeField] private WheelCollider rearLeftWheelCollider;
    //[SerializeField] private WheelCollider rearRightWheelCollider;


    public Transform player;
    int MoveSpeed = 6;
    int MaxDist = 20;
    int MinDist = 10;
 
 
 
 
    void Start()
    {
 
    }
 
    void Update()
    {
        transform.LookAt(player);
        Debug.Log(Vector3.Distance(transform.position, player.position));
 
        if (Vector3.Distance(transform.position, player.position) >= MinDist)
        {
 
            transform.position += transform.forward * (MoveSpeed * Time.deltaTime);
 
 
            if (Vector3.Distance(transform.position, player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }
 
        }
    }
    
}