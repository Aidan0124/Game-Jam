using UnityEngine;

public class IgnoreBreakableRaycast : MonoBehaviour
{
    private Collider sphereCollider;

    void Start()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Sphere"), LayerMask.NameToLayer("ground"), true);
    }


}