using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject helpPopup; 

    void Start()
    {
        helpPopup.SetActive(false); // Hide help popup at the start
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene"); 
    }

    public void OpenHelpPopup()
    {
        helpPopup.SetActive(true); 
    }

    public void CloseHelpPopup()
    {
        helpPopup.SetActive(false); 
    }

    public void ExitGame()
    {
        Application.Quit(); 
    }
}
