using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Command
{
     public Entity381 entity;
     public bool isExecuting = false;
     public Vector3 endPos;


     public Command(Entity381 ent)
     {
          entity = ent;
     }

     public virtual void Init()
     {

     }

     public virtual void Tick()
     {

     }

     public virtual bool isDone()
     {
          return false;
     }
     public virtual void Stop()
     {

     }

     public virtual void Drawline(Vector3 startPos, Vector3 endPos)
     {
          
     }
}
