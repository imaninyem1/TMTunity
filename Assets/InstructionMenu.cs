using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InstructionMenu : MonoBehaviour
{
    public void ChangeScene(){
    SceneManager.LoadScene("Menu");
    }
}
