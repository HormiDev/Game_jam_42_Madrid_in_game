using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Security.Permissions;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    private TMP_Text        tex;
    private string          cmd = "";
    private string          defaultTxt = "Type help for help...\n\n>_ ";
    private GameObject[]    updates;
    public  GameObject      gameManager;
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
                    {
                        tex.SetText(tex.text + "\n\nlist of owned towers:\n" + gameManager.GetComponent<GameManager>().printFriend());
                    }
                    else if (cmd.Contains("-e"))
                    {
                        tex.SetText(tex.text + "\n\nlist of enemy towers:\n" + gameManager.GetComponent<GameManager>().printEnemy());
                    }
                    else if (cmd.Contains("-u"))
                        tex.SetText(tex.text + "\n\nlist of avalible updates:");
                    else if (cmd.Contains("-d"))
                        tex.SetText(tex.text + "\n\nlist of disable towers:\n"+ gameManager.GetComponent<GameManager>().printDisable());
                    else
                        tex.SetText(tex.text + "\n\nfor list towers and updates:\n\t$ls -f list of owned towers\n\t$ls -e list of enemy towers\n\t$ls -u list of avalible updates\n\t$ls -d list of disable towers\n");     
                }
                else if (cmd.Contains("help"))
                {
                        tex.SetText(tex.text + "\n\t\t------H E L P------\nfor list towers and updates:\n\t$ls -f list of owned towers\n\t$ls -e list of enemys towers\n\t$ls -u list of avalible updates\n\nto apply an update in a tower:\n\t$use update (N) tower (flag) (N)\n\tFlags:\n\t\t-f friend tower\n\t\t-e enemy tower\n\t\t*N stand for number\nfor clear the console:\n\t$clear\nevery command without $\n");
                }
                else if (cmd.Contains("42"))
                {
                    tex.SetText(tex.text + "\n(-_-)?\n");
                }
                else if (cmd.Contains("update"))
                {
                    int         updateN;
                    int         towerN;
                    char        flag;
                    bool        target;// 0 yourself, 1 enemy
                    string[]    array = cmd.Split('-');

                    if (array.Length == 2 && array[1].Split(' ').Length > 1 &&(array[1][0] == 'f' || array[1][0] == 'e'))
                    {
                        if (System.Int32.TryParse(array[0].Split(' ')[2], out _))
                        {
                            if (System.Int32.TryParse(array[1].Split(' ')[1], out _))
                            {
                                updateN = System.Int32.Parse(array[0].Split(' ')[2]);
                                towerN = System.Int32.Parse(array[1].Split(' ')[1]);
                                flag = array[1][0];

                                if (updateN > 0 && towerN > 0)
                                {
                                    ;
                                }
                            }
                            else
                            {
                                tex.SetText(tex.text + "\n\nerror: tower must be a number: tower: " + array[1].Split(' ')[1] + "\n");
                            }
                        }
                        else
                        {
                            tex.SetText(tex.text + "\n\nerror: update must be a number\n"); 
                        }
                    }
                    else
                    {
                       tex.SetText(tex.text + "\n\nerror: command usage: $use update (number of update) tower (flag of tower) (number of tower)\n"); 
                    }
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
