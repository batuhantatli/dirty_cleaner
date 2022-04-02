using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DirtyGenerator : MonoBehaviour
{
    public SpriteRenderer[] dirties;
    public Color[] colors;
    public float radius;
    public float dirtyLevel;

    [ContextMenu("Generate")]
    public void Generate()
    {
        Vector3 position;
        GameObject parent = new GameObject("Dirty Parent");

        for (int i = 0; i < dirtyLevel; i++)
        {
            position = Random.insideUnitCircle * radius;
            position.Set(position.x, 0, position.y);

            var sp = PrefabUtility.InstantiatePrefab(dirties[Random.Range(0, dirties.Length)], parent.transform) as SpriteRenderer;
            sp.transform.position = position;
            sp.color = colors[Random.Range(0, colors.Length)];
        }

        parent.transform.position += Vector3.up * .51f;

    }
}
