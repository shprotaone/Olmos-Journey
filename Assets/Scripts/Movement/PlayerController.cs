using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speedMovement;

    [SerializeField] private ResultUI _result;
    [SerializeField] private Transform _leftLine;
    [SerializeField] private Transform _rightLine;

    private Keyboard _input;
    private CharacterController _characterController;
    private Animator _animator;

    private Vector3 _targetPosition;
    
    private bool _left;
    private bool _right;
    private bool _edge;
    private bool _pressedAction;
    private bool _playerDeath;

    private StartRunningScript _startRunningScript;
    private DeathScript _deathScript;
    private Jump _jumpScript;

    private int _leftAnimationID = Animator.StringToHash("Left");
    private int _rightAnimationID = Animator.StringToHash("Right");

    private float _distanceToGround;

    private PlatformTypes _type;

    public float DistanceToGround { get { return _distanceToGround; } }

    private void Awake()
    {
        _input = new Keyboard();
        _input.Player.Action.performed += context => Action();
        _input.Player.MoveLeft.performed += context => MoveLeft();
        _input.Player.MoveRight.performed += context => MoveRight();

        _characterController = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
        _startRunningScript = GetComponent<StartRunningScript>();
        _deathScript = GetComponent<DeathScript>();
        _jumpScript = GetComponent<Jump>();

        _speedMovement = LoadBalance.movement;
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {   
        if(_startRunningScript.IsStarted && !_playerDeath)
        Movement();        
        Action();
        CheckPlatform();
    }

    private void MoveLeft()
    {
        if (!_edge)
            _animator.SetTrigger(_leftAnimationID);

        _left = true;
    }
     
    private void MoveRight()
    {                
        if (!_edge)
        _animator.SetTrigger(_rightAnimationID);

        _right = true;
    }

    private void Movement()
    {
        CheckEdge();

        float tmpDist = Time.deltaTime * _speedMovement;

        var movement = Vector3.MoveTowards(transform.position, _targetPosition, tmpDist) - transform.position ;
        _characterController.Move(movement);

        if (_left && _targetPosition.x > _leftLine.transform.position.x )
        {
            _targetPosition += _leftLine.transform.position;
            _edge = false;
        }        
        else if(_right && _targetPosition.x < _rightLine.transform.position.x)
        {
            _targetPosition += _rightLine.transform.position;
            _edge = false;
        }

        ResetPosition();
    }

    private void ResetPosition()
    {
        _right = false;
        _left = false;
    }

    private void Action()
    {
        _pressedAction = _input.Player.Action.triggered;

        if (_pressedAction)
        {
            _startRunningScript.Action(_pressedAction);
            _jumpScript.Action(_pressedAction);
        }

        if (_playerDeath)
        {
            _deathScript.Action(_playerDeath);
        }
    }
    public void Death()
    {
        _playerDeath = true;
        GetComponent<ScoreSystem>().SaveScore();
        //_result.ResultEnable();
    }

    private void CheckEdge()
    {
        if (transform.position.x == _leftLine.transform.position.x || transform.position.x == _rightLine.transform.position.x)
            _edge = true;
        else
            _edge = false;
    }
    public void CheckPlatform()
    {
        Ray ray = new Ray(transform.position, Vector3.down*2);
        Debug.DrawRay(ray.origin, ray.direction, Color.red,1000);

        RaycastHit hit;

        if(Physics.Raycast(ray,out hit))
        {
            _type = hit.transform.GetComponentInParent<PlatformDesription>().Type;
            _distanceToGround = hit.distance;
        }
    }
}
