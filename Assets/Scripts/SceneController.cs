using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
