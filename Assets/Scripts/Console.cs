using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Permissions;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    private TMP_Text    tex;
    private string      cmd = "";
    private string      defaultTxt = "Type help for help...\n\n>_ ";
    // Start is called before the first frame update
    void Start()
    {
        tex = GetComponent<TMP_Text>();
        tex.SetText(defaultTxt);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {

            if (Input.GetKeyDown("return"))
            {
                if (cmd.Contains("ls"))
                {
                    if (cmd.Contains("-f"))
                        tex.SetText(tex.text + "\n\nlist of owned towers:");
                    else if (cmd.Contains("-e"))
                        tex.SetText(tex.text + "\n\nlist of enemy towers:");
                    else if (cmd.Contains("-u"))
                        tex.SetText(tex.text + "\n\nlist of avalible updates:");
                    else
                        tex.SetText(tex.text + "\n\nfor list towers and updates:\n\tls -f list of owned towers\n\tls -e list of enemys towers\n\tls -u list of avalible updates\n");     
                }
                else if (cmd.Contains("help"))
                {
                        tex.SetText(tex.text + "\n\t\t------H E L P------\nfor list towers and updates:\n\tls -f list of owned towers\n\tls -e list of enemys towers\n\tls -u list of avalible updates\n\nto apply an update in a tower:\n\tuse update (N) tower (flag) (N)\n\tFlags:\n\t\t-f friend tower\n\t\t-e enemy tower\n\t\t*N stand for number\nfor clear the console:\n\tclear\n");
                }
                else if (cmd.Contains("42"))
                {
                    tex.SetText(tex.text + "\n(-_-)?\n");
                }
                else if (cmd.Contains("use") && cmd.Contains("update"))
                {
                    int     updateN;
                    int     towerN;
                    bool    target;// 0 yourself, 1 enemy
                    
                }
                else
                {
                    tex.SetText(tex.text + "\n" + cmd + ": command not found\n");      
                }

                tex.SetText(tex.text + "\n>_ ");
                if (cmd.Contains("clear"))
                    tex.SetText(defaultTxt);
                cmd = "";

            }
            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                if (cmd.Length > 0)
                {
                    cmd = cmd.Remove(cmd.Length - 1);
                    tex.SetText(tex.text.Remove(tex.text.Length - 1));
                }
            }
            else
            {
                char[]    c = Input.inputString.ToCharArray();

                if (Input.inputString.Length == 0)
                    ;
                else if (c[0] >= 32 && c[0] <= 127)
                {
                    string  keyPressed = Input.inputString;
                    tex.SetText(tex.text + keyPressed);
                    cmd = cmd + keyPressed;
                }
            }
        }
    }
}
