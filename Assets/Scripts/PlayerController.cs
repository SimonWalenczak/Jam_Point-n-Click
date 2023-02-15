using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    public bool CanMove;
    
    
    [SerializeField]
    private float _horizonY = 1;
    [SerializeField]
    private float _originalScaleAtY = -1;
 
    private float   _currentY;
    private float   _previousY;
    private Vector3 _regularScale;

    public float _currentX;
    public float _previousX;

    private void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
        _regularScale = transform.localScale;

        CanMove = true;
    }

    private void Facing()
    {
        _currentX = transform.position.x;
        Transform _transform = GetComponent<Transform>();

        if (_currentX > _previousX)
        {
            print("right");
            transform.localScale = new Vector3(-(transform.localScale.x), _transform.localScale.y, transform.localScale.z);
            animator.SetBool("Facing", true);
            _previousX = _currentX;
        }
        else if (_currentX < _previousX)
        {
            print("left");
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), _transform.localScale.y, transform.localScale.z);
            animator.SetBool("Facing", false);
            _previousX = _currentX;
        }
        else
        {
            animator.SetBool("Facing", animator.GetBool("Facing"));
        }
    }
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        Facing();
        
        if (CanMove)
        {
            agent.SetDestination(mousePosition);
            animator.SetBool("IsWalking", true);
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetBool("IsWalking", false);
        }

        _currentY = transform.position.y;
 
        if (Mathf.Approximately(_currentY, _previousY))
        {
            return;
        }
 
        float normalizedDistance = Mathf.InverseLerp(_horizonY, _originalScaleAtY, _currentY);
        transform.localScale = Vector3.Lerp(Vector3.zero, _regularScale, normalizedDistance);
 
        _previousY = _currentY;

        float normalizedSpeed = normalizedDistance * 3;
        agent.speed = normalizedSpeed;
    }
}