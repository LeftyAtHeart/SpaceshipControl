using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPromt : MonoBehaviour
{
    public Move Ship = null;
    public static GameObject InstanceCommandPromt;

    private string PreviousCommands = "";
    private string currentCommand = "";

    public void Awake()
    {
        InstanceCommandPromt = gameObject;
        gameObject.SetActive(false);
    }


    // Start is called before the first frame update
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 200, 300, 300));

        GUILayout.Label(PreviousCommands);
        currentCommand = GUILayout.TextArea(currentCommand);

        if (currentCommand.Length > 0)
        {

            if (currentCommand.Contains((char)10))
            {
                //Removes Line ender
                int LineEnderPostion = currentCommand.LastIndexOf((char)10);
                currentCommand = currentCommand.Remove(LineEnderPostion, 1);

                if (currentCommand.ToLower().IndexOf("turn_port") != -1)
                {
                    int Degrees;

                    int.TryParse(currentCommand.Substring(10),out Degrees);

                    Ship.turnRpc(Mathf.Abs(Degrees));
                }
                if (currentCommand.ToLower().IndexOf("turn_starboard") != -1)
                {
                    int Degrees;

                    int.TryParse(currentCommand.Substring(15), out Degrees);

                    print(Degrees);

                    Ship.turnRpc(-Mathf.Abs(Degrees));
                }

                //Adds to previous commands.
                PreviousCommands = PreviousCommands + "\n" + currentCommand;
                currentCommand = "";
            }
        }

        GUILayout.EndArea();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
