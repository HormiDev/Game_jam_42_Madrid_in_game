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
    private string          defaultTxt = "Type 'help' to read the instructions, or simply type 'take' or 'deal' to start this duel...\n\n>_ ";
    private GameObject[]    updates;
    public  GameObject      gameManager;
    public  bool            waiting = false;
    public  float           counter = 0;
    public  bool            doOnce;
    // Start is called before the first frame update
    void Start()
    {
        tex = GetComponent<TMP_Text>();
        tex.SetText(defaultTxt);
    }

    void    take()
    {
        gameManager.GetComponent<GameManager>().editPlayer(gameManager.GetComponent<GameManager>().cards.GetNextCard());
        waiting = true;
        doOnce = true;
    }

    void    deal()
    {
        gameManager.GetComponent<GameManager>().editEnemy(gameManager.GetComponent<GameManager>().cards.GetNextCard());
        waiting = true;
        doOnce = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {

            if (Input.GetKeyDown("return"))
            {
                if (cmd.Contains("take"))
                {
                    take();
                }
                else if (cmd.Contains("deal"))
                {
                    deal();
                }
                else if (cmd.Contains("help"))
                {
                        tex.SetText("\n\t    ------H E L P------\nTake: With this command, you take the update for yourself, and one of your towers gets upgraded. By taking this action, you skip your opponent's turn only if you get an update without a virus. If not, you get the virus and lose your turn.\n\nDeal: With this command, you give the update to your opponent, and one of their towers gets upgraded. \n\nclear: clear terminal\n");
                }
                else if (cmd.Contains("42"))
                {
                    tex.SetText(tex.text + "\n(-_-)?\n");
                }
                else
                {
                    tex.SetText(tex.text + "\n" + cmd + ": command not found\n");      
                }
                if (!waiting)
                    tex.SetText(tex.text + "\n>_ ");
                else
                    tex.SetText(tex.text + "\n...\n");
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
            else if (!waiting)
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
        if (waiting)
        {
            counter += 1 * Time.deltaTime;
            if (counter > 2 && doOnce)
            {
                tex.SetText(tex.text + "...");
                doOnce = false;
            }
        }
        if (counter > 4)
        {
            waiting = false;
            counter = 0;
            tex.SetText(tex.text + "\n>_ ");
        }
    }
}
