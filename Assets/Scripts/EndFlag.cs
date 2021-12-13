using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public string NextSceneLevel;
    public bool LastLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (LastLevel)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(NextSceneLevel);
            }
        }
    }
}
