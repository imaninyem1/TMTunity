using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void ChangeScene(){
    SceneManager.LoadScene("soldier testing");
    }

    public void ChangeScenetoInstruction()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ChangeScenetoResults()
    {
        SceneManager.LoadScene("Results");
    }

    public void ChangeScenetoDied()
    {
        SceneManager.LoadScene("Dead");
    }
<<<<<<< HEAD

    public void ChangeScenetoAbout()
    {
        SceneManager.LoadScene("About");
    }

=======
>>>>>>> b000dc568a7dd5e15d6e06694f18dd812fa25f60
}