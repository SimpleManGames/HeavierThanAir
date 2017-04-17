using System.IO;
using UnityEditor;
using UnityEngine;

namespace Simplicity
{
    public class CreateProjectTree
    {
        [MenuItem("Simpicity/Project/Generate Project Tree")]
        public static void Excute()
        {
            var assets = GenerateFolderStructure();
            CreateFolders(assets);
        }

        private static void CreateFolders(Folder rootFolder)
        {
            if (!AssetDatabase.IsValidFolder(rootFolder.DirPath))
            {
                Debug.Log("Creating: <b>" + rootFolder.DirPath + "</b>");
                AssetDatabase.CreateFolder(rootFolder.ParentPath, rootFolder.name);
                File.Create(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + rootFolder.DirPath + Path.DirectorySeparatorChar + ".keep");
            }
            else
            {
                if (Directory.GetFiles(Directory.GetCurrentDirectory() + Path.AltDirectorySeparatorChar + rootFolder.DirPath).Length < 1)
                {
                    File.Create(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + rootFolder.DirPath + Path.DirectorySeparatorChar + ".keep");
                    Debug.Log("Creating '.keep' file in: <b>" + rootFolder.DirPath + "</b>");
                }
                else
                    Debug.Log("Directory <b>" + rootFolder.DirPath + "</b> already exists");
            }

            rootFolder.subFolders.ForEach(folder => CreateFolders(folder));
        }

        private static Folder GenerateFolderStructure()
        {
            Folder rootFolder = new Folder("Assets", "");

            rootFolder.Add("_Extenions");
            rootFolder.Add("_Plugins");
            rootFolder.Add("_3rdParty");

            var GameAssets = rootFolder.Add("_GAME_ASSETS");

            GameAssets.Add("_Data");

            var Scripts = GameAssets.Add("_Scripts");
            Scripts.Add("_Attributes");
            Scripts.Add("_Enums");
            Scripts.Add("_Utility");
            Scripts.Add("_GameLogic");
            Scripts.Add("_Structs");
            Scripts.Add("_Interfaces");
            Scripts.Add("_ScriptableObjects");

            var Scene = GameAssets.Add("_Scenes");
            Scene.Add("_Dev");
            Scene.Add("_Final");

            GameAssets.Add("_Prefab");

            var Resources = GameAssets.Add("_Art");
            Resources.Add("_Models");
            Resources.Add("_Animations");
            Resources.Add("_Animators");
            Resources.Add("_Effects");
            Resources.Add("_Materials");
            Resources.Add("_Shaders");
            Resources.Add("_Audio");
            Resources.Add("_Textures");
            Resources.Add("_Sprites");
            Resources.Add("_Fonts");

            return rootFolder;
        }
    }
}