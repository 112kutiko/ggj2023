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
    public NetworkVariable<int> gilin = new NetworkVariable<int>();

    public float speed = 40f;
    public AudioClip sound;
    public AudioSource musicA; 
    [SerializeField] private AudioSource player1Click;
    [SerializeField] private AudioSource player2Click;

    public GameObject off, on;
    void awake()
    {
        controls = this;

    }
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("mode") == 1)
        {
            on.SetActive(true);

        }
        else { off.SetActive(true); }


    }



    // Update is called once per frame
    void Update()
    {
   
        
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
        int mainUse;
        if (PlayerPrefs.GetInt("mode") == 1)
        {
            mainUse=gilin.Value;
        }
        else
        {
            mainUse = DOWNtO;
        }






        GameObject temp = Instantiate(Root, Roots.transform.position, Quaternion.identity);
        if(i== 0)
        {
            if(old0==null) { } else
            {
                old0.GetComponent<myBlock>().isEnd=true;
            }
            old0= temp;
            if (temp.transform.position.y < mainUse)
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
            if (temp.transform.position.y < mainUse)
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
        musicA.PlayOneShot(sound);

    }
   
    public int newBegin()
    {

        return Random.Range(-80, -10);
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
    public void playOfline()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        PlayerPrefs.SetInt("mode", 0);
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
    public override void OnNetworkSpawn()
    {
        if (PlayerPrefs.GetInt("mode") == 1)
        {
          
                gilin.Value = newBegin();
          
        }
    }
}
