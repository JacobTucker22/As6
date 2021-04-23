using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour
{
     public List<Command> commandList;
     public Command currentCommand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if (commandList.Count > 0)
          {
               if (!currentCommand.isExecuting)
               {
                    currentCommand.Init();
               }

               for(int i = 0; i < commandList.Count - 1; i++)
               {
                    commandList[i + 1].Drawline(commandList[i].endPos, commandList[i + 1].endPos);
                    
               }

               if (!currentCommand.isDone())
               {
                    currentCommand.Tick();
               }
               else
               {
                    currentCommand.Stop();
                    if (commandList.Count > 1)
                    {
                         currentCommand = commandList[1];
                    }
                    else
                    {
                         currentCommand = null;
                    }
                    commandList.RemoveAt(0);
               }

               
          }
    }

     public void AddCommand(Command nextCommand)
     {
          commandList.Add(nextCommand);
          if(commandList.Count <= 1)
          {
               currentCommand = nextCommand;
          }
     }

     public void SetCommand(Command nextCommand)
     {
          commandList.Clear();
          commandList.Add(nextCommand);
          currentCommand = nextCommand;
     }
}
