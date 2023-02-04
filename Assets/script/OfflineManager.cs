using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineManager : MonoBehaviour
{
    public GameObject gameO;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("mode") == 0)
        {
            gameO.SetActive(true);
            for (int i = 0; i < 2; i++)
            {
                playercontrol.controls.checker1(playercontrol.controls.players[i], playercontrol.controls.spawnerAdd, i);

            }
            playercontrol.controls.newBegin();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("mode") != 0)
        { return; }
            if (Input.GetKeyDown("s"))
        {
            //player 1
            playercontrol.controls.soundHouse(0);
            playercontrol.controls.spawnRoots(playercontrol.controls.players[0], playercontrol.controls.spawnerAdd[0], 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //player 2
            playercontrol.controls.soundHouse(1);
            playercontrol.controls.spawnRoots(playercontrol.controls.players[1], playercontrol.controls.spawnerAdd[1], 1);
        }



    }
}
