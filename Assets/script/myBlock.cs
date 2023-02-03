using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myBlock : MonoBehaviour
{
    public GameObject spawnerPoint;
    public bool isEnd;
    public List<Mesh> pool1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player")
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
