using System;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float seekerViewDistance = 16f;
    public float hiderViewDistance = 20f;

    float fov = 360;

    private float viewDistance;
    public int rayCount;

    [TagSelector]
    public string[] maskableTags = new string[] { };

    Mesh mesh;
    Vector3 origin;

    PlayerType type;

    public LayerMask mask;
    
    public void Start()
    {
        viewDistance = seekerViewDistance;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    public void LateUpdate()
    {
        float angle = 0f;
        float angleIncrease = fov / rayCount;

        Vector3[] verticies = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[verticies.Length];
        int[] triangles = new int[rayCount * 3];

        origin = Vector3.zero;

        verticies[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;

        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;

            RaycastHit hit;
            bool rayIsHit = false;
            if (Physics.Raycast(transform.position, GetVectorFromAngle(angle), out hit, viewDistance, mask))
            {
                rayIsHit = true;
                vertex = hit.point - transform.position;
            }
            else
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }

            ShowMaskableObjects(angle, rayIsHit ? hit.distance : viewDistance);

            verticies[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }

            angle -= angleIncrease;
            vertexIndex++;
        }

        mesh.vertices = verticies;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(origin, Vector3.one * 1000f);
    }

    public void SetUpFovPlayerType(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.Seeker:
                viewDistance = seekerViewDistance;
                break;
            case PlayerType.Hider:
                viewDistance = hiderViewDistance;
                break;
        }
    }

    public void ShowMaskableObjects(float angle, float distance)
    {

        var hits = Physics.RaycastAll(transform.position, GetVectorFromAngle(angle), distance);

        for (int j = 0; j < hits.Length; j++)
        {
            RaycastHit _hit = hits[j];
            string colliderTag = _hit.collider.tag;
            if (Array.Exists(maskableTags, tag => tag == colliderTag))
            {
                _hit.collider.gameObject.GetComponent<MaskableObject>().SetAsVisible();
            }
        }
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
    }
}
