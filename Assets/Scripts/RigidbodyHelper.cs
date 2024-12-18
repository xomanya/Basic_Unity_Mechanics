using UnityEngine;

public static class RigidbodyHelper
{
    public static int Test;

    // public static Rigidbody GetOrAddRigidbody(GameObject gameObject)
    // {
    //     if (gameObject.TryGetComponent(out Rigidbody rigidbody) == false)
    //     {
    //         rigidbody = gameObject.AddComponent<Rigidbody>();
    //     }
    //     return rigidbody;
    // }
    

    public static Rigidbody GetOrAddRigidbody(this GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out Rigidbody rigidbody) == false)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        return rigidbody;
    }
}
