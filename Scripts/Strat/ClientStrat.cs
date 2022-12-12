using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientStrat : Observer
{
    private PlayerController _pCont;
    public bool obs;
    private GameObject _obstacle;
    public Transform player;
    private float rando;
    private float rando2;

    private List<IManeuver> _components = new List<IManeuver>();

    private void SpawnDrone()
    {
        rando = Random.Range(100f, 150f);
        rando2 = Random.Range(-7f, 7f);
        _obstacle = GameObject.CreatePrimitive(PrimitiveType.Cube);
        _obstacle.transform.gameObject.tag = "Obstacle";
        _obstacle.GetComponent<MeshRenderer>().material.color = Color.red;
        _obstacle.AddComponent<Obstacle>();
          
        _obstacle.transform.position = player.position + new Vector3(rando2, 0f, rando);
        ApplyRandomStrategies();
    }

    private void ApplyRandomStrategies()
    {
        _components.Add(_obstacle.AddComponent<WeavingBehaviour>());
      
        int index = Random.Range(0, _components.Count);

        _obstacle.GetComponent<Obstacle>().ApplyStrategy(_components[index]);
    }

    public override void Notify(Subject subject)
    {
        if (!_pCont)
        {
            _pCont = subject.GetComponent<PlayerController>();
        }

        if (_pCont)
        {
            Debug.Log("Spawn Stuff");
            obs = _pCont.obs;
            for (int i = 0; i < 5; ++i)
            {
                SpawnDrone();
            }
            
        }
    }
}
