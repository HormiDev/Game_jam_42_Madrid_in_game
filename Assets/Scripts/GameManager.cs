using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public  GameObject[]    continents;
    public  GameObject[]    continers;
    public  GameObject      console;
    private bool            boolConsole;
    private float           camZoom;
    private Vector3         camTransform;
    private Camera          cam;
    public  GameObject[]    towers;

    public  string  printFriend()
    {
        string  result = "";

        for(int i = 0; i < continers[1].gameObject.transform.childCount; i++)
        {
            GameObject Go = continers[1].gameObject.transform.GetChild(i).gameObject;
            result = result + "[" + (i) + "] " + Go.name + "\n";
        }
        return (result);
    }

    public  int nFriend()
    {
        return (continers[1].gameObject.transform.childCount);
    }

    public  int nEnemy()
    {
        return (continers[2].gameObject.transform.childCount);
    }

    public  int nDisable()
    {
        return (continers[0].gameObject.transform.childCount);
    }

    public  string  printEnemy()
    {
        string  result = "";

        for(int i = 0; i < continers[2].gameObject.transform.childCount; i++)
        {
            GameObject Go = continers[2].gameObject.transform.GetChild(i).gameObject;
            result = result + "[" + (i) + "] " + Go.name + "\n";
        }
        return (result);
    }

    public  string  printDisable()
    {
        string  result = "";

        for(int i = 0; i < continers[0].gameObject.transform.childCount; i++)
        {
            GameObject Go = continers[0].gameObject.transform.GetChild(i).gameObject;
            result = result + "[" + (i) + "] " + Go.name + "\n";
        }
        return (result);
    }

    public  void    MoveToEnemy(GameObject continent)
    {
        continent.GetComponent<Continent>().setEnemy();
        continent.transform.parent = continers[2].transform;
    }

    public  void    MoveToDisable(GameObject continent)
    {
        continent.GetComponent<Continent>().setDisabled();
        continent.transform.parent = continers[0].transform;
    }

    public  void    MoveToFriend(GameObject continent)
    {
        continent.GetComponent<Continent>().setFriend();
        continent.transform.parent = continers[1].transform;
    }

    void    ShuffleTowers()
    {
        int i = 0;
        towers = GameObject.FindGameObjectsWithTag("Tower");
        while(i < towers.Length)
        {
            if (i % 2 == 0)
                towers[i].transform.GetChild(0).gameObject.GetComponent<Tower>().ft_friendLed();
            i++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        boolConsole = false;
        cam = Camera.main;
        cam.gameObject.GetComponent<CameraZoom>().active = true;
        ShuffleTowers();
    }

    void    enableConsole()
    {
        console.SetActive(true);
        camZoom = cam.orthographicSize;
        camTransform = cam.gameObject.transform.position;
        cam.orthographicSize = 500;
        cam.gameObject.transform.position = new Vector3(0, cam.transform.position.y, 0);
        cam.gameObject.GetComponent<CameraZoom>().active = false;
    }

    void    disableConsole()
    {
        console.SetActive(false);
        cam.transform.position = camTransform;
        cam.orthographicSize = camZoom;
        cam.gameObject.GetComponent<CameraZoom>().active = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (boolConsole)
                disableConsole();
            else
                enableConsole();
            boolConsole = !boolConsole;
        }
    }
}
