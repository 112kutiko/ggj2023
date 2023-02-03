using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour
{

    public List<GameObject> players = new List<GameObject>(); 
    public List<GameObject> spawnerAdd = new List<GameObject>();
    public GameObject Root,root2;
    public GameObject old0, old1;
    public static playercontrol controls;
    public bool playTime=false;
    public int DOWNtO = 0;
    public float speed = 40f;
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

        if (playTime) { } else { return; }

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
            if(old0==null) { } else
            {
                old0.GetComponent<myBlock>().isEnd=true;
            }
            old0= temp;
            if (temp.transform.position.y < DOWNtO)
            { Debug.Log("1p");
              PlayerPrefs.SetString("winner", "player 1 win");
                SceneManager.LoadScene("win", LoadSceneMode.Single);
            }
        }
        else
        {
            if (old1 ==null) { }
            else
            {
                old1.GetComponent<myBlock>().isEnd = true;
            }
            old1 = temp;
            if (temp.transform.position.y < DOWNtO)
            {
                Debug.Log("2p");
                PlayerPrefs.SetString("winner", "player 2 win");
                SceneManager.LoadScene("win", LoadSceneMode.Single);
            }
        }
        if(Camera.main.gameObject.transform.position.y> temp.transform.position.y)
        {

        Vector3 my = Camera.main.gameObject.transform.position;
        my.y = temp.transform.position.y;
            Camera.main.gameObject.transform.Translate(my * (Time.deltaTime*speed), Space.World);

        }
        checker1(temp, spawnerAdd, i);


    }
    public void changeStats(bool a)
    {
        playTime = a;
    }
    public void newBegin()
    {
        DOWNtO= Random.Range(-80, -10);
    }
}
