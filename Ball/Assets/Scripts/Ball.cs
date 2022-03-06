using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 target = new Vector3();
    private Vector3 lastTarget = new Vector3();
    public CapsuleCollider col;
    private float rad;

    private void Start()
    {
        rad = col.radius * 100 / 2;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                target = hit.point;
            }
            
        }
        MoveTo();
    }

    private void MoveTo()
    {
        if (target != lastTarget)
        {
            if ((transform.position - target).sqrMagnitude > 0.3f)
            {
                if (target.z < rad && target.z > -rad && target.x * target.x + target.z * target.z < rad/2* rad/2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                }
            }
            else
            {
                lastTarget = target;
            }
        }
    }
}
