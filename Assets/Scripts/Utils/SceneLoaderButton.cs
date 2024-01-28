using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Utils
{
    public class SceneLoaderButton : MonoBehaviour
    {
        [SerializeField] private string _sceneNameToLoad;
        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(LoadScene);
        }

        private void LoadScene()
        {
            SceneManager.LoadSceneAsync(_sceneNameToLoad);
        }
    }
}