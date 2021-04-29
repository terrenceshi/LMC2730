using System;
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

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    public Transform player;
    int MoveSpeed = 4;
    int MaxDist = 40;
    int MinDist = 10;
 
 
 
 
    void Start()
    {
 
    }
 
    void Update()
    {
        transform.LookAt(player);
        Debug.Log(Vector3.Distance(transform.position, player.position));
 
        if (Vector3.Distance(transform.position, player.position) <= MaxDist)
        {
 
            transform.position += transform.forward * (MoveSpeed * Time.deltaTime);
 
 
            if (Vector3.Distance(transform.position, player.position) <= MinDist)
            {
                Debug.Log("arrested");
                //Arrested Cut Scene
            }
 
        }
    }
    
}