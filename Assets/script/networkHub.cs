using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Unity.Netcode.Transports.UTP;

public class networkHub : MonoBehaviour
{
    public string ipAddres = "";


    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        PlayerPrefs.SetInt("mode", 1);

    }

    public void StartServer()
    {
        NetworkManager.Singleton.StartServer();
        NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        PlayerPrefs.SetInt("mode", 1);

    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        PlayerPrefs.SetInt("mode", 1); 
    }
    public void changeIp(string ip) { 
        ipAddres= ip;
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(
       ipAddres,  // The IP address is a string
        (ushort)12345, // The port number is an unsigned short
        "0.0.0.0" // The server listen address is a string.
    );
    }
}
