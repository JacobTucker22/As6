using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingOrientedPhysics : MonoBehaviour
{
     public FlyingEntity381 entity;
     public Vector3 eulerRotation = Vector3.zero;

     // Start is called before the first frame update
     void Start()
    {
          entity.position = transform.localPosition;
     }

    // Update is called once per frame
    void Update()
    {
          //speed
          if (Utils.ApproximatelyEqual(entity.speed, entity.desiredSpeed))
          {
               ;
          }
          else if (entity.speed < entity.desiredSpeed)
          {
               entity.speed = entity.speed + entity.acceleration * Time.deltaTime;
          }
          else if (entity.speed > entity.desiredSpeed)
          {
               entity.speed = entity.speed - entity.acceleration * Time.deltaTime;
          }
          entity.speed = Utils.Clamp(entity.speed, entity.minSpeed, entity.maxSpeed);


          //Pitch
          if (Utils.ApproximatelyEqual(entity.pitch, entity.desiredPitch))
          {
               ;
          }
          else if (Utils.AngleDiffPosNeg(entity.desiredPitch, entity.pitch) > 0)
          {
               entity.pitch += entity.turnRate * Time.deltaTime;
          }
          else if (Utils.AngleDiffPosNeg(entity.desiredPitch, entity.pitch) < 0)
          {
               entity.pitch -= entity.turnRate * Time.deltaTime;
          }
          entity.pitch = Utils.Degree360(entity.pitch);

          eulerRotation.x = entity.pitch;
          transform.localEulerAngles = eulerRotation;

          //heading
          if (Utils.ApproximatelyEqual(entity.heading, entity.desiredHeading))
          {
               ;
          }
          else if (Utils.AngleDiffPosNeg(entity.desiredHeading, entity.heading) > 0)
          {
               entity.heading += entity.turnRate * Time.deltaTime;
               
          }
          else if (Utils.AngleDiffPosNeg(entity.desiredHeading, entity.heading) < 0)
          {
               entity.heading -= entity.turnRate * Time.deltaTime;

          }
          entity.heading = Utils.Degree360(entity.heading);

          eulerRotation.y = entity.heading;
          transform.localEulerAngles = eulerRotation;

          //velocity
          entity.velocity.x =  Mathf.Sin(entity.heading * Mathf.Deg2Rad) * entity.speed; ;
          entity.velocity.y = -Mathf.Sin(entity.pitch * Mathf.Deg2Rad) * entity.speed;
          entity.velocity.z = Mathf.Cos(entity.heading * Mathf.Deg2Rad) * entity.speed;

          //position
          entity.position = entity.position + entity.velocity * Time.deltaTime;
          transform.localPosition = entity.position;

     }
}
