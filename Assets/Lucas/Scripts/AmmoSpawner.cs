using System.Collections;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _ammo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(AmmoAppearing());
    }

    public void AmmoAppear()
    {
        Vector2 enemySpawnZone = new Vector2(Random.Range(-5f, 5f), Random.Range(-4f, 4f));
        Instantiate(_ammo, enemySpawnZone, new Quaternion(0,0,0,0));
    }

    IEnumerator AmmoAppearing()
    {
        while (true)
        {
            yield return new WaitForSeconds(8); //Enemy appear function will be taking place for every 2 seconds after clicking the SpaceBar key.
            AmmoAppear();
        }
    }
}
