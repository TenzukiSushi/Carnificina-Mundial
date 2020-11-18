using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuParallax : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxSpeed;

    private void Update()
    {
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", GetComponent<Renderer>().material.GetTextureOffset("_MainTex") + parallaxSpeed * Time.deltaTime);
    }
}
