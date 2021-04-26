using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class policeLight : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private bool startBright = true;

    Light myLight;

    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startBright == true) {
            myLight.intensity = Mathf.PingPong(Time.time * speed, 8);
        } else {
            myLight.intensity = 8 - Mathf.PingPong(Time.time * speed, 8);
        }
        
    }
}
