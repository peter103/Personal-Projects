using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject warningScreen;
    public bool showScreen = false;

    void Start()
    {
        warningScreen.SetActive(showScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMenu(bool gotoMenu)
    {
        if(gotoMenu)
        {
            showScreen = true;
            warningScreen.SetActive(showScreen);
        }
    }

    public void Yes(bool decide)
    {
        if(decide)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void No(bool decide)
    {
        if(decide)
        {
            showScreen = false;
            warningScreen.SetActive(showScreen);
        }
    }

    
}
