using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{

    public List<GameObject> players = new List<GameObject>(); 
    public List<GameObject> spawnerAdd = new List<GameObject>();
    public GameObject Root,root2;
    public GameObject old0, old1;
    static playercontrol controls;


    void awake()
    {
        controls = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0;i<2; i++)
        {
            Debug.Log(i);
            checker1(players[i], spawnerAdd,i);
           
        }
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                //player 1
                spawnRoots(players[0], spawnerAdd[0],0);

            }
            else if (touch.position.x > Screen.width / 2)
            {
                //player 2
                spawnRoots(players[1], spawnerAdd[1], 1);

            }
        }
        if (Input.GetKeyDown("s"))
        {
            //player 1
            spawnRoots(players[0], spawnerAdd[0], 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //player 2
            spawnRoots(players[1], spawnerAdd[1], 1);
        }


    }
    public void checker1(GameObject a, List<GameObject> b,int i)
    {
        if (b.Count < 2)
        {
            b.Add(a.GetComponent<myBlock>().spawnerPoint);
        }
        else
        {
        b[i] = a.GetComponent<myBlock>().spawnerPoint; 
        }
       
    }
    public  void spawnRoots(GameObject player, GameObject Roots,int i)
    {

        GameObject temp= Instantiate(Root, Roots.transform.position, Quaternion.identity);
        if(i== 0)
        {
            if(old0=null) { } else
            {
                temp.GetComponent<myBlock>().isEnd=true;
            }
            old0= temp;
        }
        else
        {
            old1= temp;
        }

        checker1(temp, spawnerAdd, i);
    }
}
