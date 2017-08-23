using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(NewPlayerGuide))]
public class NewPlayerEditor:Editor
{
    private NewPlayerGuide npg;
    private Canvas canvas;
    void OnEnable()
    {
       Init();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        npg = (NewPlayerGuide) target;
        npg.target=EditorGUILayout.ObjectField("TargetRectTrans",npg.target,typeof(RectTransform),true) as RectTransform;
        npg.RadusSlider = EditorGUILayout.Slider("Mask Radus", npg.RadusSlider, 0, 1000);
        npg.material = EditorGUILayout.ObjectField("Material", npg.material, typeof(Material), true) as Material;
        UpdateMask();
    }

    void OnDestroy()
    {
        if (npg != null)
        {
            npg.GetComponent<Image>().material = null;
        }
    }

    void Init()
    {
       npg = (NewPlayerGuide)target;
       canvas = GameObject.Find ("Canvas").GetComponent<Canvas> ();
       UpdateMask();
    }

    void UpdateMask()
    {
        Vector3[] corners = new Vector3[4];
        if (npg.target != null)
            npg.target.GetWorldCorners(corners);
        else
             Debug.LogWarning("Target is null!");
        float x =corners [0].x + ((corners [3].x - corners [0].x) / 2f);
        float y =corners [0].y + ((corners [1].y - corners [0].y) / 2f);
 
        Vector3 center = new Vector3 (x, y, 0f);
        Vector2 position = WordToCanvasPos(canvas,center);
         Debug.Log(npg.name);
        if (npg.material == null)
        {
            npg.material=Resources.Load<Material>("UI-Default_Mask");
        }
        else
        {
            npg.GetComponent<Image>().material = npg.material;
            npg.material.SetFloat("_Silder", npg.RadusSlider);
        }
        center = new Vector4 (position.x,position.y,0f,0f);
        npg.material.SetVector ("_Center", center);
    }
    
    Vector2 WordToCanvasPos(Canvas canvas,Vector3 world)
    {
        Vector2 position = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, world, canvas.GetComponent<Camera>(), out position);
        return position;
    }
}
