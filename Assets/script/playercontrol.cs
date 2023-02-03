using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public GameObject spawnerStart, spawnerAdd, goGround;


    // Start is called before the first frame update
    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {
        if (spawnerAdd == null) { spawnerAdd = goGround.GetComponent<myBlock>().spawnerPoint; }
    }
}
