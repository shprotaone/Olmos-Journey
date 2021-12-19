using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SoundController _soundController;
    [SerializeField] private Transform _leftLine;
    [SerializeField] private Transform _rightLine;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private LayerMask _platformLayer;
    [SerializeField] private float _speedMovement;

    private Vector3 _targetPosition;

    private CharacterController _characterController;
    
    private PlatformTypes _type;
    private Animator _animator;

    private StartRunningScript _startRunningScript;
    private DeathScript _deathScript;
    private Jump _jumpScript;

    private float _distanceToGround;

    private int _leftAnimationID = Animator.StringToHash("Left");
    private int _rightAnimationID = Animator.StringToHash("Right");

    private bool _left;
    private bool _right;
    private bool _edge;
    private bool _playerDeath;

    public float DistanceToGround { get { return _distanceToGround; } }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
        _startRunningScript = GetComponent<StartRunningScript>();
        _deathScript = GetComponent<DeathScript>();
        _jumpScript = GetComponent<Jump>();

        SwipeDetection.SwipeEvent += OnSwipe;
        SwipeDetection.TouchEvent += OnTouch;
       
        _speedMovement = LoadBalance.movement;
    }

    private void Update()
    {   
        Movement();        
        CheckPlatform();

        if (_startRunningScript.IsStarted && !_playerDeath)
        {
            _soundController.SlideSound(_characterController.isGrounded);
        }       
    }

    private void OnSwipe(Vector2 direction)
    {
        if (_startRunningScript.IsStarted && !_playerDeath)
        {
            if (direction.x == 1)
            {
                MoveLeft();               
            }
            else if (direction.x == -1)
            {
                MoveRight();                
            }
        }       
    }

    private void OnTouch(bool action)
    {
        if (!_startRunningScript.IsStarted)
        {
            _startRunningScript.Action();
            
        }
        else if(!_playerDeath)
                _jumpScript.Action();
    }

    private void MoveLeft()
    {
        if (!_edge && _animator != null)
            _animator.SetTrigger(_leftAnimationID);

        _left = true;

        _soundController.TurnSound();
    }
     
    private void MoveRight()
    {                
        if (!_edge && _animator != null)
        _animator.SetTrigger(_rightAnimationID);

        _right = true;
        _soundController.TurnSound();
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

    public void Death()
    {
        _playerDeath = true;
        _deathScript.Action();
    }

    private void CheckEdge()        //пока что не работает как положено
    {
        if (transform.position.x == _leftLine.transform.position.x || transform.position.x == _rightLine.transform.position.x)
            _edge = true;
        else
            _edge = false;
    }

    public void CheckPlatform()
    {
        Ray ray = new Ray(transform.position, Vector3.down*6);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit,_platformLayer))
        {
            if (hit.transform.CompareTag("Platform"))
            {
                _distanceToGround = hit.distance;
            }

            _type = hit.transform.GetComponentInParent<PlatformController>().Type;

            if(_type == PlatformTypes.SHOOTPLATFORM)
            {
                hit.transform.GetComponentInParent<GiftLauncher>().LaunchGift(_shootPoint);
            }
        }
    }
}
