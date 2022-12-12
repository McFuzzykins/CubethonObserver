using UnityEngine;


public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private bool _isReplaying;
    private bool _isRecording;
    private PlayerMovement _playerController;
    private Command _buttonA, _buttonD, _buttonSpace;

    void Start()
    {
        _invoker = gameObject.AddComponent<Invoker>();
        _playerController = FindObjectOfType<PlayerMovement>();

        _playerController.ResetPosition();
        _isReplaying = false;
        _isRecording = true;
        _invoker.Record();

        _buttonA = new MoveLeft(_playerController);
        _buttonD = new MoveRight(_playerController);
        _buttonSpace = new MoveUp(_playerController);
    }

    void FixedUpdate()
    {
        if (!_isReplaying && _isRecording)
        {
            if (Input.GetKey("a"))
            {
                _invoker.ExecuteCommand(_buttonA);
            }

            if (Input.GetKey("d"))
            {
                _invoker.ExecuteCommand(_buttonD);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                _invoker.ExecuteCommand(_buttonSpace);
            }
        }
    }

    public bool getReplaying()
    {
        return _isReplaying;
    }

    public void Replay()
    {
        _playerController.ResetPosition();
        _playerController.ResetVelocity();

        _isRecording = false;
        _isReplaying = true;
        _invoker.Replay();
    }
}