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
            //playercontrol.controls.players[0].GetComponent<myBlock>().clientId.Value = i;
            playercontrol.controls.player1();
        }
        else
        {
        //    playercontrol.controls.players[1].GetComponent<myBlock>().clientId.Value = i;
            playercontrol.controls.player2();
        }
        
    }
    [ClientRpc]
     public void setGameClientRpc(int i)
    {
        playercontrol.controls.gilin.Value = i;
    }


//public override void NetworkStart()
  //  {
//
//if (IsServer && NetworkManager.Singleton.ConnectedClientsList.Count==2)
//{
       // int tmp = playercontrol.controls.newBegin();
//setGameClientRpc(tmp);
      //  }
     
   // }
}
