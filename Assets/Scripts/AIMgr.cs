using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMgr : MonoBehaviour
{
     public static AIMgr inst;

     private void Awake()
     {
          inst = this;
     }

     // Start is called before the first frame update
     void Start()
    {
          layerMask = 1 << 10; //LayerMask.GetMask("Ocean");
    }

     public RaycastHit hit;
     public int layerMask;
    // Update is called once per frame
    void Update()
    {
          
          if (Input.GetMouseButtonDown(1))
          {
               if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue, layerMask))
               {
                    Debug.DrawLine(Camera.main.transform.position, hit.point, Color.yellow, 2);
                    Vector3 pos = hit.point;
                    pos.y = 0;
                    Entity381 ent = findClosestEntInRadius(pos, clickRadius);
                    if (ent == null)
                    {
                         if(Input.GetKey(KeyCode.LeftAlt))
                         {
                              HandleTeleport(pos);
                         }
                         else
                         {
                              HandleMove(pos);
                         }
                    }
                    else
                    {
                         if(Input.GetKey(KeyCode.LeftControl))
                         {
                              HandleIntercept(ent);
                         }
                         else
                         {
                              HandleFollow(ent);
                         }
                    }
               }
               else
               {
                    Debug.Log("Right mouse button did not collide with anything");
               }
          }          
    }
     
     void HandleTeleport(Vector3 point)
     {
          Teleport teleport = new Teleport(SelectionMgr.inst.selectedEntity, point);
          UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
          if(Input.GetKey(KeyCode.LeftShift))
          {
               teleport.endPos = point;
               uai.AddCommand(teleport);
          }
          else
          {
               teleport.endPos = point;
               uai.SetCommand(teleport);
          }
     }

     void HandleMove(Vector3 point)
     {
          Move m = new Move(SelectionMgr.inst.selectedEntity, point);
          UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
          if (Input.GetKey(KeyCode.LeftShift))
          {
               m.endPos = point;
               uai.AddCommand(m);
          }
          else
          {
               m.endPos = point;
               uai.SetCommand(m);
          }
     }

     void HandleFollow(Entity381 ent)
     {
          Follow f = new Follow(SelectionMgr.inst.selectedEntity, ent, new Vector3(100, 0, 0));
          UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
          if (Input.GetKey(KeyCode.LeftShift))
          {
               uai.AddCommand(f);
          }
          else
          {
               uai.SetCommand(f);
          }

     }

     void HandleIntercept(Entity381 ent)
     {
          Intercept intercept = new Intercept(SelectionMgr.inst.selectedEntity, ent);
          UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
          if (Input.GetKey(KeyCode.LeftShift))
               uai.AddCommand(intercept);
          else
               uai.SetCommand(intercept);

     }

     public float clickRadius = 10000;
     public Entity381 findClosestEntInRadius(Vector3 point, float radiusSquared)
     {
          Entity381 minEnt = null;
          float minDistance = float.MaxValue;
          foreach(Entity381 ent in EntityMgr.inst.entities)
          {
               float distanceSqr = (ent.position - point).sqrMagnitude;
               if (distanceSqr < radiusSquared)
               {
                    if (distanceSqr < minDistance)
                    {
                         minDistance = distanceSqr;
                         minEnt = ent;
                    }
               }
               
          }
          return minEnt;
     }
}
