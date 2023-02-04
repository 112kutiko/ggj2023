using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class myBlock : NetworkBehaviour
{
    public GameObject spawnerPoint, parentHook;
    public bool isEnd, isfirst;
    public List<Mesh> pool1,pool0, poolEnd;
    public bool isPlayer;
    public int idPlayer = 0;
    void Start()
    { 
        if (gameObject.tag == "Player")
        {
            isPlayer=true;
        }
        if (isPlayer) { return; }
        randomlvl1();
        if (parentHook != null)
        {
            int u = Random.Range(0, pool1.Count);
            parentHook.GetComponent<MeshFilter>().mesh = pool1[u];
        }
    }

    void Update()
    {
        if (isPlayer==true )
        {
            return;
        }
        else
        {
            if (isEnd == true && isfirst == false)
            {
                randomlvl2();            }
            else if (isEnd == true && isfirst == true)
            {
                randomlvl3();
            }

            }
            
    }
   
    public void randomlvl1()
    {
       int u = Random.Range(0, poolEnd.Count);
        gameObject.GetComponent<MeshFilter>().mesh = poolEnd[u];
    }
    public void randomlvl2()
    {
        int ycount = Random.Range(0, pool1.Count);
        gameObject.GetComponent<MeshFilter>().mesh = pool1[ycount];
        isEnd = false; 
    }
    public void randomlvl3()
    {
        int ycount = Random.Range(0, pool0.Count);
        gameObject.GetComponent<MeshFilter>().mesh = pool0[ycount];
        isEnd = false;

    }

}
