using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class OnlineManager : NetworkBehaviour
{
    public GameObject gameO;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("mode") == 1)
        {

            gameO.SetActive(true);
            for (int i = 0; i < 2; i++)
            {
                playercontrol.controls.checker1(playercontrol.controls.players[i], playercontrol.controls.spawnerAdd, i);

            }


        }
    
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("mode") != 1)
        { return; }
        if (!IsOwner) { return; }
       
        if (Input.GetKeyDown("s")  )
        {

            mymoveServerRpc();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) )
{
            mymoveServerRpc();
        }



    }
    [ServerRpc]
    public void mymoveServerRpc(ServerRpcParams serverRpcParams = default)
    {
        var clientId = serverRpcParams.Receive.SenderClientId;
        MoveClientRpc(clientId);
    }
    [ClientRpc]
    public void MoveClientRpc(ulong i)
    {
        if (i == 0)
        {
            playercontrol.controls.player1();
        }
        else
        {
            playercontrol.controls.player2();
        }
        
    }
}
