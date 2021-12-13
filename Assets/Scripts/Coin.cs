using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float RotationSpeed;

    public int CoinValue;

    void Update()
    {
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().AddScore(CoinValue);
            Destroy(gameObject);
        }
    }
}
