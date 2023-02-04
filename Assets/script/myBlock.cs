using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class myBlock : NetworkBehaviour
{
    public GameObject spawnerPoint;
    public bool isEnd;
    public List<Mesh> pool1, poolEnd;
    public bool isPlayer;  
    private NetworkVariable<int> clientId = new NetworkVariable<int>();

    // Start is called before the first frame update
    void Start()
    {


        if (gameObject.tag == "Player")
        {
            isPlayer=true;
        }
        if (isPlayer) { return; }
        int ycount = Random.Range(0, poolEnd.Count);
        gameObject.GetComponent<MeshFilter>().mesh = poolEnd[ycount];
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer==true)
        {
            return;
        }
        else
        { 
            if (isEnd==true)
            {
                int ycount = Random.Range(0, pool1.Count);
                gameObject.GetComponent<MeshFilter>().mesh = pool1[ycount];
                isEnd = false;
            }
        }
    }
   
}
