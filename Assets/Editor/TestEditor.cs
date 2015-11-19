using UnityEngine;
using UnityEditor;
using System.Collections;

public class TestEditor : Editor
{
    static void DestroyComponents(Transform t, int layer)
    {

    }

    static void UpdateChildren(Transform t, int layer)
    {

        t.gameObject.layer = layer;
        foreach (Transform child_t in t)
        {
            UpdateChildren(child_t, layer);
            child_t.tag = "Terrain";
        }
    }

    static void UpdateSpikes(Transform t)
    {
        GameObject _spikes = t.GetChild(1).gameObject;
        Spikes sc = _spikes.AddComponent<Spikes>();
    }

    static void UpdateAcid(Transform t)
    {
        GameObject _acid = t.GetChild(1).gameObject;
        DeathBox sc = _acid.AddComponent<DeathBox>();
        _acid.GetComponent<PolygonCollider2D>().isTrigger = true;
    }

    [MenuItem("Tools/Set World")]
    public static void WorldLayerUpdate()
    {
        Transform[] objects = GameObject.FindObjectsOfType<Transform>();

        foreach (Transform t in objects)
        {
            if (t.name == "World_02")
            {
                t.transform.parent.localScale = new Vector3(0.03125f, 0.03125f, 1.0f);
                Undo.RecordObject(t.gameObject, "WorldObject");
                UpdateChildren(t, LayerMask.NameToLayer("World"));
            }

            if (t.name == "Spikes_03")
            {
                Undo.RecordObject(t.gameObject, "WorldObject");
                UpdateSpikes(t);
            }

            if (t.name == "Acid_04")
            {
                Undo.RecordObject(t.gameObject, "WorldObject");
                UpdateAcid(t);
            }
        }
    }
}

