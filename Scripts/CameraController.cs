using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Observer
{
    private PlayerController _pCont;
    private bool _flip;
    public Transform player;
    public Vector3 offset;
    private Invoker _invoke;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }

    public override void Notify(Subject subject)
    {
        if(!_pCont)
        {
            _pCont = subject.GetComponent<PlayerController>();
        }

        if(_pCont)
        {
            Debug.Log("Flip 2");
            _flip = _pCont.flip;

            Debug.Log("Flip Flip");
            gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
            transform.position = player.position + -offset;
            Debug.Log("Flipped Camera");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
