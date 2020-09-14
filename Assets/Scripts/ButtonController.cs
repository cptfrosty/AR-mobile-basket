using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void AddForce()
    {
        if (ProgrammManager.force < 50)
        {
            ProgrammManager.force += 0.5f;
        }
    }

    public void RemoveForce()
    {
        if (ProgrammManager.force > 0)
        {
            ProgrammManager.force -= 0.5f;
        }
    }


}
