using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class myBlock : NetworkBehaviour
{
    public GameObject spawnerPoint;
    public bool isEnd, isfirst;
    public List<Mesh> pool1,pool0, poolEnd;
    public bool isPlayer;
    public int lygis = 0;
        //    public NetworkVariable<int> clientId = new NetworkVariable<int>();

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
            if (isEnd == true && isfirst == false)
            {
                int ycount = Random.Range(0, pool1.Count);
                gameObject.GetComponent<MeshFilter>().mesh = pool1[ycount];
                isEnd = false;
                lygis = 1;
            }
            else if (isEnd == true && isfirst == true)
            {
                int ycount = Random.Range(0, pool0.Count);
                gameObject.GetComponent<MeshFilter>().mesh = pool0[ycount];
                isEnd = false;
                lygis = 2;
            }

            }
    }
   
}
