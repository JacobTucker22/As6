using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMgr : MonoBehaviour
{
     public static EntityMgr inst;
     private void Awake()
     {
          inst = this;
     }

     public List<Entity381> entities;
     public FlyingEntity381 flyingEntity;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < entities.Count; i++)
          {
               entities[i].index = i;
          }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
