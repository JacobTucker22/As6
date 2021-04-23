using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity381 : MonoBehaviour
{
     //---------------------------------------------------------
     //values that change while running
     //---------------------------------------------------------
     public bool isSelected = false;
     public int index;
     public bool isFlyingEntity = false;
     public GameObject selectionCircle;
     public Vector3 position = Vector3.zero;
     public Vector3 velocity = Vector3.zero;

     public float speed;
     public float desiredSpeed;
     public float heading;
     public float desiredHeading;
     //---------------------------------------------------------
     //values that do not change
     //---------------------------------------------------------
     public float acceleration;
     public float turnRate;
     public float maxSpeed;
     public float minSpeed;

     public GameObject cameraRig;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          selectionCircle.SetActive(isSelected);
    }
}
