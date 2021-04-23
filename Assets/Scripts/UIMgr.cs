using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
     public static UIMgr inst;

     private void Awake()
     {
          inst = this;
     }

     // Start is called before the first frame update
     void Start()
    {
        
    }

     public Text entityText;
     public Text speedText;
     public Text desiredSpeedText;
     public Text headingText;
     public Text desiredHeadingText;

    // Update is called once per frame
    void Update()
    {
          entityText.text = SelectionMgr.inst.selectedEntity.name;
          speedText.text = SelectionMgr.inst.selectedEntity.speed.ToString("F1") + " kts";
          desiredSpeedText.text = SelectionMgr.inst.selectedEntity.desiredSpeed.ToString("F1") + " kts";
          headingText.text = SelectionMgr.inst.selectedEntity.heading.ToString("F1") + " deg";
          desiredHeadingText.text = SelectionMgr.inst.selectedEntity.desiredHeading.ToString("F1") + " deg";
     }
}
