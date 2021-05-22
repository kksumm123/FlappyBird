using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;


public class EditorOptionConfig : EditorWindow
{
    [MenuItem("Tools/Option")]
    static void Init()
    {
        GetWindow(typeof(EditorOptionConfig));
    }

    Vector2 mPos = Vector2.zero;
    void OnGUI()
    {
        mPos = GUILayout.BeginScrollView(mPos);
        if(GUILayout.Button("테스트 버튼"))
        {
            Debug.Log("테스트 버튼 누름");
        }

        for (OptionType i = OptionType.StartIndex + 1; i < OptionType.LastIndex; i++)
        {
            GUILayout.BeginHorizontal();
            {
                bool tempBool = EditorOption.Options[i];

                EditorOption.Options[i] = GUILayout.Toggle(EditorOption.Options[i], i.ToString());

                if (tempBool != EditorOption.Options[i])
                {
                    string key = "DevOption_" + i;
                    EditorPrefs.SetInt(key, EditorOption.Options[i] == true ? 1 : 0);
                }
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndScrollView();
    }

    void SetPositionObject()
    {
        List<GameObject> objs = new List<GameObject>();
        foreach (var item in Selection.objects)
        {
            objs.Add(item as GameObject);
        }
        objs = objs.OrderBy(x => x.transform.position.x).ToList();

        var spriteRenderer = objs[0].GetComponentInChildren<SpriteRenderer>();
        float width = spriteRenderer.sprite.bounds.size.x * objs[0].transform.lossyScale.x;

        var pos = objs[1].transform.position.x;
    }
}