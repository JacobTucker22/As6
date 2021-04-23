using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMgr : MonoBehaviour
{
     public static SelectionMgr inst;
     public LayerMask selectableLayer;

     //bool isSelecting = false;
     public Vector3 Intersection_Point = Vector3.zero;
     public float radius = 100;
     public List<int> IDs = new List<int>();
     public int closestEntity = 0;

     private void Awake()
     {
          inst = this;
     }

     // Start is called before the first frame update
     void Start()
    {
        
    }

     // Update is called once per frame
     void Update()
     {
          if (Input.GetKeyUp(KeyCode.Tab))
          {
               SelectNextEntity();
          }
          if (Input.GetMouseButtonDown(0))
          {
               Click();
          }
     }

     public int selectedEntityIndex = 0;
     public Entity381 selectedEntity;

     public void SelectNextEntity()
     {
          selectedEntityIndex = (selectedEntityIndex >= EntityMgr.inst.entities.Count - 1 ? 0 : selectedEntityIndex + 1);
          selectedEntity = EntityMgr.inst.entities[selectedEntityIndex];
          UnselectAll();
          selectedEntity.isSelected = true;
          //move camera if changing selected entity in 3rd person mode
          if(!CameraMgr.inst.isRTSMode)
          {
               CameraMgr.inst.YawNode.transform.SetParent(SelectionMgr.inst.selectedEntity.cameraRig.transform);
               CameraMgr.inst.YawNode.transform.localPosition = Vector3.zero;
               CameraMgr.inst.YawNode.transform.localEulerAngles = Vector3.zero;
          }

     }

     void UnselectAll()
     {
          foreach(Entity381 ent in EntityMgr.inst.entities)
          {
               ent.isSelected = false;
          }
     }

     //mouse select
     void Click()
     {
          RaycastHit raycastInfo;
          IDs.Clear();
          if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastInfo, Mathf.Infinity))
          {
               Intersection_Point = raycastInfo.point;

               for(int i = 0; i < EntityMgr.inst.entities.Count; i++)
               {
                    Entity381 Obj = EntityMgr.inst.entities[i];
                    if (Vector3.Distance(raycastInfo.point, Obj.position) < radius)
                    {
                         //print(Intersection_Point + " " + Obj.position + " " + Vector3.Distance(raycastInfo.point, Obj.position));
                         IDs.Add(Obj.index);
                    }
               }

               if (IDs.Count > 0)
               {
                    closestEntity = findClosestEntity(raycastInfo.point);
                    SelectClosestEntity(closestEntity);
               }

               //This is mouse selection using the capsule colliders as I had it setup in As5
               //Selects entity based off of the collider that it hit. 
               //To use this you should add selectableLayer as last argument to raycast.
               //selectedEntityIndex = raycastInfo.collider.GetComponent<Entity381>().index;
               //selectedEntity = EntityMgr.inst.entities[selectedEntityIndex];
               //UnselectAll();
               //selectedEntity.isSelected = true;
          }

     }

     public int findClosestEntity(Vector3 Intersection_Point)
     {
          int ID = selectedEntityIndex;
          float _min = 100000000000;
          for(int i = 0; i < IDs.Count; i++)
          {
               if(Vector3.Distance(Intersection_Point, EntityMgr.inst.entities[IDs[i]].position) < _min)
               {
                    _min = Vector3.Distance(Intersection_Point, EntityMgr.inst.entities[IDs[i]].position);
                    ID = IDs[i];
               }
          }
          return ID;
     }

     public void SelectClosestEntity(int id)
     {
          selectedEntity = EntityMgr.inst.entities[id];
          UnselectAll();
          selectedEntity.isSelected = true;
     }
}
