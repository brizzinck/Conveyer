using UnityEngine;

public class ConveyerBelt : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;
    [SerializeField]
    private float velocity = 0.5f;
    [SerializeField]
    private RelativeDirection direction = RelativeDirection.Down;
    private BeltForceMode beltMode = BeltForceMode.Push;
    private Rigidbody body;
    private Vector3 pos;
    private MeshRenderer meshRenderer;

    public void SetSpeedConveyer(float velocity)
    {
        this.velocity = velocity;
        if (velocity == 0)
            meshRenderer.material = materials[1];
        else
            meshRenderer.material = materials[0];
    }
    private void Awake()
    {
        this.body = GetComponent<Rigidbody>();
        pos = transform.position;
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public void FixedUpdate()
    {
        if (body != null && beltMode == BeltForceMode.Pull)
        {
            Vector3 movement = velocity * GetDirection() * Time.fixedDeltaTime;
            transform.position = pos - movement;
            body.MovePosition(pos);
        }
    }
    public void OnCollisionStay(Collision other)
    {
        if (other.rigidbody != null && !other.rigidbody.isKinematic && beltMode == BeltForceMode.Push)
        {
            Vector3 movement = velocity * GetDirection() * Time.deltaTime;
            other.rigidbody.MovePosition(other.transform.position + movement);
        }
    }
    public Vector3 GetDirection()
    {
        switch (this.direction)
        {
            case RelativeDirection.Up:
                return transform.up;
            case RelativeDirection.Down:
                return -transform.up;
            case RelativeDirection.Left:
                return -transform.right;
            case RelativeDirection.Right:
                return transform.right;
            case RelativeDirection.Forward:
                return transform.forward;
            case RelativeDirection.Backward:
                return -transform.forward;
        }
        return transform.forward;
    }
    public enum BeltForceMode
    {
        Push,
        Pull
    }
    public enum RelativeDirection
    {
        Up,
        Down,
        Left,
        Right,
        Forward,
        Backward
    }
}