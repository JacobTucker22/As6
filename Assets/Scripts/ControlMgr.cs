using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMgr : MonoBehaviour
{
     public static ControlMgr inst;
     private void Awake()
     {
          inst = this;
     }

     // Start is called before the first frame update
     void Start()
    {
        
    }

     public float deltaSpeed = 1;
     public float deltaHeading = 2;
     public float deltaRotate = 2;


    // Update is called once per frame
    void Update()
    {
          //speed
          if (Input.GetKey(KeyCode.UpArrow))
               SelectionMgr.inst.selectedEntity.desiredSpeed += deltaSpeed;
          if (Input.GetKey(KeyCode.DownArrow))
               SelectionMgr.inst.selectedEntity.desiredSpeed -= deltaSpeed;
          SelectionMgr.inst.selectedEntity.desiredSpeed =
               Utils.Clamp(SelectionMgr.inst.selectedEntity.desiredSpeed, SelectionMgr.inst.selectedEntity.minSpeed, SelectionMgr.inst.selectedEntity.maxSpeed);

          //pitch
          if (SelectionMgr.inst.selectedEntity.isFlyingEntity)
          {

               if (Input.GetKey(KeyCode.PageUp))
                    EntityMgr.inst.flyingEntity.desiredPitch -= deltaRotate;
               if (Input.GetKey(KeyCode.PageDown))
                    EntityMgr.inst.flyingEntity.desiredPitch += deltaRotate;
               EntityMgr.inst.flyingEntity.desiredPitch = Utils.Degree360(EntityMgr.inst.flyingEntity.desiredPitch);

          }

          //heading
          if (Input.GetKey(KeyCode.LeftArrow))
          {
               SelectionMgr.inst.selectedEntity.desiredHeading -= deltaHeading;

          }
          if (Input.GetKey(KeyCode.RightArrow))
               SelectionMgr.inst.selectedEntity.desiredHeading += deltaHeading;
          SelectionMgr.inst.selectedEntity.desiredHeading = Utils.Degree360(SelectionMgr.inst.selectedEntity.desiredHeading);


     }
}
