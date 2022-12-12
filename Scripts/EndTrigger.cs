using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager manager;

    void OnTriggerEnter()
    {
        manager.winLevel();    
    }
}
