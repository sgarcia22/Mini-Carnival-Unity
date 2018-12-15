using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

	public void Menu ()
    {
        SceneManager.LoadScene(0);
    }
    public void DuckHunt()
    {
        SceneManager.LoadScene(1);
    }
    public void WaterShooter()
    {
        SceneManager.LoadScene(2);
    }
    public void KnockCans()
    {
        SceneManager.LoadScene(3);
    }

    private void Update()
    {
        if (GvrControllerInput.HomeButtonDown == true)
        {
            Menu();
        }
    }
}
