using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFruit : MonoBehaviour
{
    [SerializeField] private List<Transform> _positionSpawn = new List<Transform>();
    [SerializeField] private Fruit[] _fruits;
    private void Start()
    {
        Spawning();
    }
    private void Spawning()
    {
        int numberSpawn = Random.Range(2, 4);
        for (int i = 0; i < numberSpawn; i++)
        {
            Transform positionSpawn = _positionSpawn[Random.Range(0, _positionSpawn.Count)];
            Fruit fruit = Instantiate(_fruits[Random.Range(0, _fruits.Length)], positionSpawn.position, 
                Quaternion.identity, transform);
            fruit.SetTransform();
            _positionSpawn.Remove(positionSpawn);
        }
    }
}
