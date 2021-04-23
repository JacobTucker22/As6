using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{
     public static CameraMgr inst;

    // Start is called before the first frame update
    void Start()
    {
          inst = this;
    }

     public GameObject RTSCameraRig;

     public GameObject YawNode;   //Child of RTSCameraRig
     public GameObject PitchNode; //Child of YawNode
     public GameObject RollNode;  //Child of PitchNode
     //Camera is child of RollNode


     public float cameraMoveSpeed = 200;
     public float cameraTurnRate = 10;
     public Vector3 currentYawEulerAngles = Vector3.zero;
     public Vector3 currentPitchEulerAngles = Vector3.zero;

     public bool isRTSMode;

     // Update is called once per frame
     void Update()
    {

          //Movement
          if (Input.GetKey(KeyCode.W))
               YawNode.transform.Translate(Vector3.forward * Time.deltaTime * cameraMoveSpeed);
          if (Input.GetKey(KeyCode.S))
               YawNode.transform.Translate(Vector3.back * Time.deltaTime * cameraMoveSpeed);
          if (Input.GetKey(KeyCode.A))
               YawNode.transform.Translate(Vector3.left * Time.deltaTime * cameraMoveSpeed);
          if (Input.GetKey(KeyCode.D))
               YawNode.transform.Translate(Vector3.right * Time.deltaTime * cameraMoveSpeed);
          if (Input.GetKey(KeyCode.R))
               YawNode.transform.Translate(Vector3.up * Time.deltaTime * cameraMoveSpeed);
          if (Input.GetKey(KeyCode.F))
               YawNode.transform.Translate(Vector3.down * Time.deltaTime * cameraMoveSpeed);

          //Yaw
          currentYawEulerAngles = YawNode.transform.localEulerAngles;
          if (Input.GetKey(KeyCode.Q))
               currentYawEulerAngles.y -= cameraTurnRate * Time.deltaTime;
          if (Input.GetKey(KeyCode.E))
               currentYawEulerAngles.y += cameraTurnRate * Time.deltaTime;
          YawNode.transform.localEulerAngles = currentYawEulerAngles;

          //Pitch
          currentPitchEulerAngles = PitchNode.transform.localEulerAngles;
          if (Input.GetKey(KeyCode.Z))
               currentPitchEulerAngles.x -= cameraTurnRate * Time.deltaTime;
          if (Input.GetKey(KeyCode.X))
               currentPitchEulerAngles.x += cameraTurnRate * Time.deltaTime;
          PitchNode.transform.localEulerAngles = currentPitchEulerAngles;

          //change camera
          if (Input.GetKeyUp(KeyCode.C))
          {
               if(isRTSMode)
               {

                    YawNode.transform.SetParent(SelectionMgr.inst.selectedEntity.cameraRig.transform);
                    YawNode.transform.localPosition = Vector3.zero;
                    YawNode.transform.localEulerAngles = Vector3.zero;
                    PitchNode.transform.localEulerAngles = Vector3.zero;
               } else
               {
                    YawNode.transform.SetParent(RTSCameraRig.transform);
                    YawNode.transform.localPosition = Vector3.zero;
                    YawNode.transform.localEulerAngles = Vector3.zero;
                    PitchNode.transform.Rotate(30, 0, 0, Space.Self);
               }

               isRTSMode = !isRTSMode;
          }

          //quit game if running exe, else stop playing game in editor
          if(Input.GetKeyUp(KeyCode.Escape))
          {
               #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
               #else
                    Application.Quit();
               #endif
               
          }
     }

}
