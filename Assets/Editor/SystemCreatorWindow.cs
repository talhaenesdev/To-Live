using System.IO;
using UnityEditor;
using UnityEngine;

public class SystemCreatorWindow : EditorWindow
{
    private string systemName = "";

    [MenuItem("Tools/System Creator")]
    public static void ShowWindow()
    {
        GetWindow<SystemCreatorWindow>("System Creator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create New System", EditorStyles.boldLabel);

        systemName = EditorGUILayout.TextField("System Name", systemName);

        if (GUILayout.Button("Create"))
        {
            CreateSystem();
        }
    }

    private void CreateSystem()
    {
        if (string.IsNullOrEmpty(systemName))
        {
            Debug.LogError("System name cannot be empty!");
            return;
        }

        string rootPath = $"Assets/Systems/{systemName}";

        Directory.CreateDirectory(rootPath);
        Directory.CreateDirectory($"{rootPath}/ScriptableObjects");

        Directory.CreateDirectory($"{rootPath}/Scripts");
        Directory.CreateDirectory($"{rootPath}/Scripts/Core");
        CreateTxt($"{rootPath}/Scripts/Core/Core.txt", "Core");
        Directory.CreateDirectory($"{rootPath}/Scripts/Data");
        Directory.CreateDirectory($"{rootPath}/Scripts/Data/Config");
        CreateTxt($"{rootPath}/Scripts/Data/Config/Config.txt", "Config");
        Directory.CreateDirectory($"{rootPath}/Scripts/Data/VOs");
        CreateTxt($"{rootPath}/Scripts/Data/VOs/VOs.txt", "VOs");
        Directory.CreateDirectory($"{rootPath}/Scripts/Entities");
        CreateTxt($"{rootPath}/Scripts/Entities/Entities.txt", "Entities");
        Directory.CreateDirectory($"{rootPath}/Prefabs");
        string txtPath = $"{rootPath}/ReadMe.txt";

        if (!File.Exists(txtPath))
        {
            File.WriteAllText(txtPath,
                $"System Name: {systemName}\nCreated: {System.DateTime.Now}");
        }

        AssetDatabase.Refresh();

        Debug.Log($"{systemName} system created successfully!");
    }

    private void CreateTxt(string fullRootPath, string text)
    {
            File.WriteAllText(
    $"{fullRootPath}",
    $@"SYSTEM: {systemName}
                {text}
                ");
    }
}