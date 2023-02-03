using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class winSceneManager : MonoBehaviour
{
    string winIs;
    public Text Tmain;
    // Start is called before the first frame update
    void Start()
    {

      winIs = PlayerPrefs.GetString("winner"); 
        Tmain.text = winIs;
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
