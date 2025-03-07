using Reflex.Attributes;
using UnityEngine;

public class MoverSystem
{
    [Inject("Cubey")] 
    public Transform Cubey { get; set; }

    [Inject]
    public void OnInitialize()
    {
        Cubey.position += Vector3.up * 5f;
    }
}