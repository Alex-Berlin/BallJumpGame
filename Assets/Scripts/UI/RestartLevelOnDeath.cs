using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelOnDeath : MonoBehaviour
{

    private void Update()
    {
        if (PlayerDeath.isDead && (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
