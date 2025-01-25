using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject KrilletPrefab;
    [SerializeField] private Transform Krillet;
    //[Range(0.1f, 1f)]
    //[SerializeField] private float fireRate = 0.5f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Add condition connected to State such as that how many shots left
            //before decrement a state
            //no more shots can be fired

            //Nothing happens if State is at 1 (lowest)
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(KrilletPrefab, Krillet.position, Krillet.rotation);
    }
}
