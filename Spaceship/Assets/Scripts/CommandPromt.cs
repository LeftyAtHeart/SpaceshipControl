using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandPromt : MonoBehaviour
{
    public Move Ship = null;
    public static GameObject InstanceCommandPromt;
    public List<string> SecretCodes = new List<string>();
    public int FTLCharges = 0;

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

                //Adds the current command into the string of previous commands for display.
                PreviousCommands = PreviousCommands + "\n" + currentCommand;

                //Checks to if the current command matches any known commands

                string FirstCommand;
                float Degrees = 0;
                int firstSpace = currentCommand.IndexOf(" ");

                if(firstSpace != -1)
                {
                    FirstCommand = currentCommand.Substring(0, firstSpace);
                }
                else
                {
                    FirstCommand = currentCommand;
                }

                switch (FirstCommand)
                {
                    case "turn_port":
                        if(firstSpace != -1)
                            float.TryParse(currentCommand.Substring(firstSpace + 1), out Degrees);
                        Ship.turnRpc(-Mathf.Abs(Degrees));
                        break;

                    case "turn_starboard":
                        if (firstSpace != -1)
                            float.TryParse(currentCommand.Substring(firstSpace + 1), out Degrees);
                        Ship.turnRpc(Mathf.Abs(Degrees));
                        break;

                    case "show_heading":
                        DisplayCommand("Current Heading:" + Ship.currentHeading.ToString()
                            + "\nTarget Heading:" + Ship.targetHeading.ToString());
                        break;

                    case "input_code":
                        int codeLocation = SecretCodes.BinarySearch(currentCommand.Substring(firstSpace + 1));
                        if(codeLocation != -1)
                        {
                            SecretCodes.RemoveAt(codeLocation);
                            DisplayCommand("Code accepted");
                            FTLCharges++;
                        }
                        else
                        {
                            DisplayCommand("Code Rejected");
                        }
                        break;

                    case "check_ftlcharges":
                        DisplayCommand("Current Ftl Charges = " + FTLCharges);
                        break;

                    case "engage_FTLjump":
                        if(FTLCharges > 0)
                        {
                            DisplayCommand("Intiating FTL Jump:");
                            Ship.jumpRpc();
                            FTLCharges--;
                        }
                        else
                        {
                            DisplayCommand("FTL jump failed, insufficient charges.");
                        }
                        break;

                    default:
                        DisplayCommand(FirstCommand + " is not recognized as an internal or external command, operable program or batch file");
                        break;

                }

                currentCommand = "";
            }
        }

        GUILayout.EndArea();
    }

    public void DisplayCommand(string NewString)
    {
        PreviousCommands = PreviousCommands + "\n" + NewString;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
