using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyGenerator : EditorWindow
{
    Texture2D headerSectionTexture;
    Texture2D headerSectionTexture_troll;
    Texture2D headerSectionTexture_orc;
    Texture2D headerSectionTexture_centaur;

    Rect headerSection;
    Rect trollHeaderSection;
    Rect orcHeaderSection;
    Rect centaurHeaderSection;

    Color headerColor = new Color(13f/255f, 40f/255f, 45f/255f, 1f);

    [MenuItem("Window/Enemy Generator")]
    static void OpenWindow()
    {
        EnemyGenerator window = (EnemyGenerator)GetWindow(typeof(EnemyGenerator));
        window.minSize = new Vector2(600,300);
        window.Show();
    }

    void OnEnable()
    {
        InitTextures();
    }

    void InitTextures()
    {
        headerSectionTexture = new Texture2D(1,1);
        headerSectionTexture.SetPixel(0, 0, headerColor);
        headerSectionTexture.Apply();

        headerSectionTexture_troll = Resources.Load<Texture2D>("Tex/1");
        headerSectionTexture_orc = Resources.Load<Texture2D>("Tex/2");
        headerSectionTexture_centaur = Resources.Load<Texture2D>("Tex/3");
    }

    void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
    }

    void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = 50;

        trollHeaderSection.x = 0;
        trollHeaderSection.y = 50;
        trollHeaderSection.width = Screen.width / 3f - 50;
        trollHeaderSection.height = Screen.width - 50;

        orcHeaderSection.x = Screen.width/3 - 50;
        orcHeaderSection.y = 50;
        orcHeaderSection.width = Screen.width/3;
        orcHeaderSection.height = Screen.width - 50;

        centaurHeaderSection.x = (Screen.width/3 - 50) * 2;
        centaurHeaderSection.y = 50;
        centaurHeaderSection.width = Screen.width/3;
        centaurHeaderSection.height = Screen.width - 50;

        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(trollHeaderSection, headerSectionTexture_troll);
        GUI.DrawTexture(orcHeaderSection, headerSectionTexture_orc);
        GUI.DrawTexture(centaurHeaderSection, headerSectionTexture_centaur);
    }

    void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);

        GUILayout.Label("Enemy Generator");

        GUILayout.EndArea();
    }
}
