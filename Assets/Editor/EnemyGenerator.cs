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
    Color headerColor = new Color(13f/255f, 40f/255f, 45f/255f, 1f);

    Rect headerSection;
    Rect trollHeaderSection;
    Rect orcHeaderSection;
    Rect centaurHeaderSection;

    static TrollData trollData;
    static OrcData orcData;
    static CentaurData centaurData;

    public static TrollData trollInfo{ get {return trollData; } }
    public static OrcData orcInfo{ get {return orcData; } }
    public static CentaurData centaurInfo{ get {return centaurData; } }

    GUISkin generatorskin;

    [MenuItem("Window/Enemy Generator")]
    static void OpenWindow()
    {
        EnemyGenerator window = (EnemyGenerator)GetWindow(typeof(EnemyGenerator));
        window.minSize = new Vector2(600,300);
        window.Show();
    }

    static void InitData()
    {
        trollData = (TrollData)ScriptableObject.CreateInstance(typeof(TrollData));
        orcData = (OrcData)ScriptableObject.CreateInstance(typeof(OrcData));
        centaurData = (CentaurData)ScriptableObject.CreateInstance(typeof(CentaurData));
    }

    void OnEnable()
    {
        InitTextures();
        InitData();
        generatorskin = Resources.Load<GUISkin>("EnemyGenerator");
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
        DrawTroll();
        DrawOrc();
        DrawCentaur();
    }

    void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = 60;

        trollHeaderSection.x = 0;
        trollHeaderSection.y = 60;
        trollHeaderSection.width = Screen.width / 3f - 60;
        trollHeaderSection.height = Screen.width - 60;

        orcHeaderSection.x = Screen.width/3 - 60;
        orcHeaderSection.y = 60;
        orcHeaderSection.width = Screen.width/3 - 60;
        orcHeaderSection.height = Screen.width - 60;

        centaurHeaderSection.x = (Screen.width/3 - 60) * 2;
        centaurHeaderSection.y = 60;
        centaurHeaderSection.width = Screen.width/3 - 60;
        centaurHeaderSection.height = Screen.width - 60;

        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(trollHeaderSection, headerSectionTexture_troll);
        GUI.DrawTexture(orcHeaderSection, headerSectionTexture_orc);
        GUI.DrawTexture(centaurHeaderSection, headerSectionTexture_centaur);
    }

    void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);

        GUILayout.Label("Enemy Generator", generatorskin.GetStyle("Header1"));

        // GUILayout.Label(orcHeaderSection.width.ToString());
        //GUILayout.Label((orcHeaderSection.width/3).ToString());

        GUILayout.EndArea();
    }

    void DrawTroll()
    {
        GUILayout.BeginArea(trollHeaderSection);

        GUILayout.Label("Troll", generatorskin.GetStyle("Content"));

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon Type", generatorskin.GetStyle("Content"));
        trollData.weaponType = (WeaponType)EditorGUILayout.EnumPopup(trollData.weaponType);
        EditorGUILayout.EndHorizontal();

        if(GUILayout.Button("Generate!", GUILayout.Height(30)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.EnemySetting.Troll);
        }

        GUILayout.EndArea();
    }

    void DrawOrc()
    {
        GUILayout.BeginArea(orcHeaderSection);

        GUILayout.Label("Orc", generatorskin.GetStyle("Content"));

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon Type", generatorskin.GetStyle("Content"));
        orcData.weaponType = (WeaponType)EditorGUILayout.EnumPopup(orcData.weaponType);
        EditorGUILayout.EndHorizontal();

        if(GUILayout.Button("Generate!", GUILayout.Height(30)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.EnemySetting.Orc);
        }

        GUILayout.EndArea();
    }

    void DrawCentaur()
    {
        GUILayout.BeginArea(centaurHeaderSection);

        GUILayout.Label("Centaur", generatorskin.GetStyle("Content"));

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon Type", generatorskin.GetStyle("Content"));
        centaurData.weaponType = (WeaponType)EditorGUILayout.EnumPopup(centaurData.weaponType);
        EditorGUILayout.EndHorizontal();

        if(GUILayout.Button("Generate!", GUILayout.Height(30)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.EnemySetting.Centaur);
        }

        GUILayout.EndArea();
    }
}

public class GeneralSettings : EditorWindow
{
    public enum EnemySetting
    {
        Troll,
        Orc,
        Centaur
    }
    static EnemySetting enemySetting;
    static GeneralSettings window;

    public static void OpenWindow(EnemySetting setting)
    {
        enemySetting = setting;
        window = (GeneralSettings)GetWindow(typeof(GeneralSettings));
        window.minSize = new Vector2(250, 200);
        window.Show();
    }

    void OnGUI()
    {
        switch (enemySetting)
        {
            case EnemySetting.Troll:
            DrawSettings((EnemyData)EnemyGenerator.trollInfo);
            break; 

            case EnemySetting.Orc:
            DrawSettings((EnemyData)EnemyGenerator.orcInfo);
            break;

            case EnemySetting.Centaur:
            DrawSettings((EnemyData)EnemyGenerator.centaurInfo);
            break;

        }
    }

    void DrawSettings(EnemyData enemyData)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Name");
        enemyData.enemyName = EditorGUILayout.TextField(enemyData.enemyName);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Health");
        enemyData.maxHealth = EditorGUILayout.FloatField(enemyData.maxHealth);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Power");
        enemyData.maxPower = EditorGUILayout.Slider(enemyData.maxPower, 0, 100);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Enemy Class");
        enemyData.enemyClass = EditorGUILayout.IntField(enemyData.enemyClass);
        EditorGUILayout.EndHorizontal();

        if(GUILayout.Button("Finish and Save", GUILayout.Height(30)))
        {
            SaveCharacter();
            // window.Close();
        }
    }

    void SaveCharacter()
    {
        string dataPath = "Assets/Resources/Enemydata/";

        switch(enemySetting)
        {
            case EnemySetting.Troll:
            dataPath += "Troll" + EnemyGenerator.trollInfo.enemyName + ".asset";
            AssetDatabase.CreateAsset(EnemyGenerator.trollInfo, dataPath);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            break;

            case EnemySetting.Orc:
            dataPath += "Orc" + EnemyGenerator.orcInfo.enemyName + ".asset";
            AssetDatabase.CreateAsset(EnemyGenerator.orcInfo, dataPath);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            
            break;
        }
    }
}