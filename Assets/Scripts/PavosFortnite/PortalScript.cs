using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public string SceneName;
    
    public void OnTriggerEnter( Collider other )
    {
        if( other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }
    }
}
