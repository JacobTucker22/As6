using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : Command
{
     public Vector3 offsetPos;
     public Entity381 followedEntity;
     public Follow(Entity381 ent, Entity381 followedEnt, Vector3 offset) : base(ent)
     {
          offsetPos = offset;
          followedEntity = followedEnt;
     }
     public override void Init()
     {
          Debug.Log("Following Entity" + followedEntity.index);

          isExecuting = true;
     }


     public Vector3 diff = Vector3.positiveInfinity;
     public float doneDistanceSqr = 1000;
     public override void Tick()
     {
          diff = (followedEntity.position + offsetPos) - entity.position ;
          entity.desiredHeading = Utils.Degree360(Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg);

          //If reached the offset position, try to match speed
          diff = (followedEntity.position + offsetPos) - entity.position;
          if(diff.sqrMagnitude < doneDistanceSqr)
          {
               entity.desiredSpeed = followedEntity.speed;
          }
          else
          {
               entity.desiredSpeed = entity.maxSpeed;
          }

          Debug.DrawLine(entity.position, followedEntity.position + offsetPos, Color.green);
          Debug.DrawLine(followedEntity.position + offsetPos, followedEntity.position, Color.green);
     }


     public override bool isDone()
     {
          //Never stop following
          return false;
     }
     public override void Stop()
     {

     }


     public override void Drawline(Vector3 startPos, Vector3 endPos)
     {
          endPos = followedEntity.position + offsetPos;
          Debug.DrawLine(startPos, endPos, Color.green);
          Debug.DrawLine(endPos, followedEntity.position, Color.green);
     }
}
