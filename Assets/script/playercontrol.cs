using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class playercontrol : NetworkBehaviour
{

    public List<GameObject> players = new List<GameObject>(); 
    public List<GameObject> spawnerAdd = new List<GameObject>();
    public GameObject Root;
    public GameObject old0, old1;
    public static playercontrol controls;
    public int DOWNtO = 0;
    public bool IsPlayable = false;
    public float speed = 40f;
    public AudioClip sound;
    public AudioSource musicA; 
    [SerializeField] private AudioSource player1Click;
    [SerializeField] private AudioSource player2Click;
    [SerializeField] private GameObject Camera;

    public GameObject off, on, water;
    void awake()
    {
        controls = this;
 
    }
    // Start is called before the first frame update
    void Start()
    { 


    }



    // Update is called once per frame
    void Update()
    {
        if (IsPlayable == false) { return; }
        if (Input.GetKeyDown("s"))
        {
            //player 1
            soundHouse(0);
            spawnRoots(players[0], spawnerAdd[0], 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //player 2
          soundHouse(1);
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
 
        GameObject temp = Instantiate(Root, Roots.transform.position, Quaternion.identity);
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
        if(Camera.transform.position.y> temp.transform.position.y)
        {
            Vector3 my = new Vector3(0, Camera.transform.position.y - 0.5f, Camera.transform.position.z - 0.2f);
            Camera.transform.position = my;
        }
        checker1(temp, spawnerAdd, i);
        musicA.PlayOneShot(sound);

    }
   
    public void newBegin()
    { 
        DOWNtO = Random.Range(-80, -10);
        Vector3 myTemp= new Vector3 (0, 0, 0);
        myTemp.y = (float)DOWNtO-32f;
        Instantiate(water, myTemp, Quaternion.identity);

    }
    public void player1()
    {
        spawnRoots(players[0], spawnerAdd[0], 0);
        soundHouse(0);
    }
    public void player2()
    {
        spawnRoots(players[1], spawnerAdd[1], 1);
        soundHouse(1);
    } 
    public void soundHouse(int i)
    {
        if (i == 0)
        {
            player1Click.Play();
        }
        else
        {
            player2Click.Play();
        }

    } 
    public void ischange() { IsPlayable= !IsPlayable; }
}
