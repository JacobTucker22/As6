using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Command
{
     public Vector3 movePosition;
     public Move(Entity381 ent, Vector3 pos) : base(ent)
     {
          movePosition = pos;
     }
     public override void Init()
     {
          Debug.Log("Moving to " + movePosition);
          entity.desiredSpeed = entity.maxSpeed;
          
          isExecuting = true;
     }

     public override void Tick()
     {
          diff = movePosition - entity.position;
          entity.desiredHeading = Utils.Degree360(Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg);
          Debug.DrawLine(entity.position, movePosition, Color.blue);
     }

     public Vector3 diff = Vector3.positiveInfinity;
     public float doneDistanceSqr = 1000;
     public override bool isDone()
     {
          diff = movePosition - entity.position;
          return (diff.sqrMagnitude < doneDistanceSqr);
     }
     public override void Stop()
     {
          entity.desiredSpeed = 0;
          Debug.Log("Done moving");
     }

     
     public override void Drawline(Vector3 startPos, Vector3 endPos)
     {
          Debug.DrawLine(startPos, endPos, Color.blue);
     }
}
