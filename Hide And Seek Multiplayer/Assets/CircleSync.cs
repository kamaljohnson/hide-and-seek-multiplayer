using UnityEngine;

public class CircleSync : MonoBehaviour
{

    public static int PosID = Shader.PropertyToID("_Position");
    public static int SizeID = Shader.PropertyToID("_Size");

    public Material CurrentMaterial;
    public Camera Camera;

    public LayerMask Mask;

    void LateUpdate()
    {
        var dir = Camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3000, Mask))
        {
            CurrentMaterial = hit.collider.gameObject.GetComponent<Renderer>().sharedMaterial;
            CurrentMaterial.SetFloat(SizeID, 1);
        }
        else
        {
            CurrentMaterial.SetFloat(SizeID, 0);
        }

        var view = Camera.WorldToViewportPoint(transform.position);
        CurrentMaterial.SetVector(PosID, view);
    }
}
