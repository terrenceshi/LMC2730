using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MikrosClient;
using MikrosClient.Analytics;

public class cube1 : MonoBehaviour
{

    [SerializeField] private GameObject Object;

    [SerializeField] private Material Material1;
    [SerializeField] private Material Material2;

    [SerializeField] private int cubeN;

    private bool color = false;
    public static bool CanBeUsed = true;

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
        if (cube1.CanBeUsed == true){
            cube1.CanBeUsed = false;

            if (color == true){
                Object.GetComponent<MeshRenderer> ().material = Material1;
            } else {
                Object.GetComponent<MeshRenderer> ().material = Material2;
            }
            color = !color;

            if (cubeN == 1){
                MikrosManager.Instance.AnalyticsController.LogEvent("Cube1", (Hashtable customEventWholeData) =>
                {
                    Debug.Log("Mikros succesful log (1)");
                },
                onFailure =>
                {
                    Debug.Log("Mikros did not log (1)");
                });
            } else {
                MikrosManager.Instance.AnalyticsController.LogEvent("Cube2", (Hashtable customEventWholeData) =>
                {
                    Debug.Log("Mikros succesful log (2)");
                },
                onFailure =>
                {
                    Debug.Log("Mikros did not log (2)");
                });
            }

            MikrosManager.Instance.AnalyticsController.FlushEvents();

            
            StartCoroutine(Example());
        }
        IEnumerator Example()
        {
            yield return new WaitForSeconds(2);
            cube1.CanBeUsed = true;
        }
        

        
    }
}
