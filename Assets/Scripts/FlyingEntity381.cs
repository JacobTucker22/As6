using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEntity381 : Entity381
{

     public float pitch;
     public float desiredPitch;

     public GameObject pitchNode;
     public GameObject turnNode;

     private void Awake()
     {
          isFlyingEntity = true;
     }
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
