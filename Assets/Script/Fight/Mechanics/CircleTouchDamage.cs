using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircleTouchDamage : TouchDamage
{

    [HideInInspector] public float anglefov = 360;
    [HideInInspector] public float radiusInner = 0f;
    [HideInInspector] public float radius = 1f;

    // private DamageState state = DamageState.emerge;
    [HideInInspector] public float timer = 0f;
    [HideInInspector] public float scale = 0f;
    [HideInInspector] public int damage = 0;

    [HideInInspector] public int[] triangles;
    [HideInInspector] public Vector2[] uvs;
    [HideInInspector] public Vector3[] vertices;
    [HideInInspector] public Vector3[] normals;
    [HideInInspector] public MeshFilter meshFilter;
    [HideInInspector] public MeshRenderer meshRenderer;

    private int quality;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        quality = (int)anglefov / 12 + 1;
        triangles = new int[quality * 2 * 3];
        vertices = new Vector3[quality * 2 + 2];
        uvs = new Vector2[vertices.Length];
        normals = new Vector3[vertices.Length];

        SetAlpha(0.5f);
        DrawMesh();
    }

    public override void Trigger()
    {
        // 对范围内的玩家扣血
        PlayerController[] players = FindObjectsOfType<PlayerController>();
        foreach(PlayerController p in players)
        {
            float dist = Vector3.Distance(new Vector3(p.transform.position.x, 0, p.transform.position.z), new Vector3(transform.position.x, 0, transform.position.z));
            if (dist <= radius && dist >= radiusInner)
            {
                p.ChangeHp(p.CurHp - damage);
            }
        }
        // state = DamageState.destroy;
        isTriggered = true;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            scale = Mathf.Clamp(scale + Time.deltaTime * 10f, 0, 1);
            transform.localScale = new Vector3(scale, 1, scale);
        }
        else
        {
            if (!isTriggered) Trigger();
            scale = Mathf.Clamp(scale - Time.deltaTime * 2f, 0, 0.5f);
            SetAlpha(scale);
            if (scale <= 0) Destroy(gameObject);
        }
    }

    private void DrawMesh()
    {
        meshFilter.mesh.Clear();

        Vector3 pos = Vector3.zero;
        float angle_lookat = transform.eulerAngles.y;
        float angle_fov = anglefov;

        float angle_start = angle_lookat - angle_fov;
        float angle_end = angle_lookat + angle_fov;
        float angle_delta = (angle_end - angle_start) / quality;

        float angle_curr = angle_end;

        for (int i = 0; i < quality + 1; i++)
        {
            Vector3 sphere_curr = new Vector3
            {
                x = Mathf.Sin(Mathf.Deg2Rad * angle_curr),
                y = 0,
                z = Mathf.Cos(Mathf.Deg2Rad * angle_curr),
            };

            Vector3 pos_curr_min = pos + sphere_curr * radiusInner;
            Vector3 pos_curr_max = pos + sphere_curr * radius;

            vertices[2 * i + 0] = pos_curr_min;
            vertices[2 * i + 1] = pos_curr_max;
            Debug.Log(pos_curr_min);

            uvs[2 * i + 0] = new Vector2((float)(quality - i) / quality, 0);
            uvs[2 * i + 1] = new Vector2((float)(quality - i) / quality, 1);

            normals[2 * i + 0] = Vector3.up;
            normals[2 * i + 1] = Vector3.up;

            angle_curr -= angle_delta;
        }

        for (int i = 0; i < quality; i++)
        {
            //  5---3---1
            //  |  /|  /|
            //  | / | / |
            //  |/  |/  |
            //  4---2---0

            int index_min_cur = i * 2 + 0;
            int index_max_cur = i * 2 + 1;
            int index_min_next = i * 2 + 2;
            int index_max_next = i * 2 + 3;

            triangles[6 * i + 0] = index_min_cur;
            triangles[6 * i + 1] = index_min_next;
            triangles[6 * i + 2] = index_max_cur;
            triangles[6 * i + 3] = index_min_next;
            triangles[6 * i + 4] = index_max_next;
            triangles[6 * i + 5] = index_max_cur;
        }

        meshFilter.sharedMesh.vertices = vertices;
        meshFilter.sharedMesh.triangles = triangles;
        meshFilter.sharedMesh.uv = uvs;
    }

    private void SetAlpha(float alpha)
    {
        Color c = meshRenderer.material.color;
        c.a = alpha;
        meshRenderer.material.color = c;
    }
}
