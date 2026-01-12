using UnityEngine;

public class BlockDrag : MonoBehaviour
{
    public LayerMask blockLayer;
    public float dragSpeed = 2.5f;
    public float maxDistance = 3.2f;

    private Camera cam;
    private Rigidbody selectedRB;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            TrySelectBlock();

        if (Input.GetMouseButton(0) && selectedRB)
            DragBlock();

        if (Input.GetMouseButtonUp(0))
            ReleaseBlock();
    }

    void TrySelectBlock()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, blockLayer))
        {
            selectedRB = hit.rigidbody;

            if (!selectedRB) return;

            // çekme sırasında daha yumuşak olsun
            selectedRB.angularDamping = 8f;
            selectedRB.linearDamping = 6f;
        }
    }

    void DragBlock()
    {
        Vector3 targetPos = cam.transform.position + cam.transform.forward * maxDistance;
        Vector3 dir = targetPos - selectedRB.position;

        selectedRB.AddForce(dir * dragSpeed, ForceMode.Force);
    }

    void ReleaseBlock()
    {
        if (!selectedRB) return;

        // eski haline getir
        selectedRB.angularDamping = 0.05f;
        selectedRB.linearDamping = 0f;

        selectedRB = null;

        // 👉 sıra + kule kontrolü
        PlayerTurnManager.Instance?.NextTurn();
        GameManager.Instance.StartStabilityCheck();
    }
}
