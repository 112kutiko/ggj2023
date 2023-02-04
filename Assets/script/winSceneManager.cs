using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class winSceneManager : MonoBehaviour
{
    int winIs; 
    public GameObject pot0, pot1;
    // Start is called before the first frame update
    void Start()
    {
      winIs = PlayerPrefs.GetInt("winner"); 
      if (winIs == 1 )
        {
            pot0.SetActive(true);
        }else if(winIs==2){
            pot1.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void back()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
