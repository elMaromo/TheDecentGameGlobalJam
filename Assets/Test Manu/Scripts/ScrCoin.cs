using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrCoin : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    public bool collected;

    public static ScrCoin Instance { get; private set; }

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
