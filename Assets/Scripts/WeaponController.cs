using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private WeaponSelector _weaponSelector;

    private void Start()
    {
        Weapon[] weapons = gameObject.GetComponentsInChildren<Weapon>(true);
        _weaponSelector = new WeaponSelector(weapons);
    }
        private void Update()
        {
            float ScrollWheel = Input.GetAxis("Mouse ScrollWheel");

            if (ScrollWheel >= 0.1f)
            {
                _weaponSelector.Next();
            }
            if (ScrollWheel <= -0.1f)
            {
                _weaponSelector.Preview();
            }

            if (Input.GetMouseButton(0))
            {
                _weaponSelector.Fire();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                _weaponSelector.Recharge();
            }
        }
    }
