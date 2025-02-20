using UnityEngine;
using System.Collections;

public class Fade_Out : MonoBehaviour
{
    private float destroyTime = 30.0f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
