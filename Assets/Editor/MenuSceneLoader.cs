using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Editor
{
    public class MenuSceneLoader : MonoBehaviour
    {
        private const string MenuItemName = "\ud83c\udfae ieGameDev";

        [MenuItem(MenuItemName + "/Scenes/Initial", priority = 0)]
        public static void LoadInitial() =>
            TryLoadScene(0);

        [MenuItem(MenuItemName + "/Scenes/Main", priority = 1)]
        public static void LoadMain() =>
            TryLoadScene(1);

        [MenuItem(MenuItemName + "/Clear PlayerPrefs", priority = 2)]
        public static void ClearPlayPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        private static void TryLoadScene(int index)
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                EditorSceneManager.OpenScene(EditorBuildSettings.scenes[index].path);
        }
    }
}