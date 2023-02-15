using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    //public Animator animator;

    public bool CanMove;
    
    
    [SerializeField]
    private float _horizonY = 1;
    [SerializeField]
    private float _originalScaleAtY = -1;
 
    private float   _currentY;
    private float   _previousY;
    private Vector3 _regularScale;

    private void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
        _regularScale = transform.localScale;

        CanMove = true;
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;
        
        if (CanMove)
        {
            agent.SetDestination(mousePosition);
            //animator.SetBool("isWalking", true);
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            //animator.SetBool("isWalking", false);
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