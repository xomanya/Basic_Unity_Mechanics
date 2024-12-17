using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int _health = 5;
    public GameObject healthItemPrefab;
    private bool _isActive;

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.E) && _isActive == false)
    //     {
    //         Instantiate(healthItemPrefab, transform.position, Quaternion.identity);
    //         
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            _health += 1;
            other.gameObject.SetActive(false);
        }

        if (_health >= 3)
        {
            other.gameObject.SetActive(true);
        }
    }
}
