using UnityEngine;

namespace ContentWarningCheat
{
    public class Loader
    {
        public static void Init()
        {
            Loader.Load = new UnityEngine.GameObject();
            Loader.Load.AddComponent<Cheat>();
            UnityEngine.Object.DontDestroyOnLoad(Loader.Load);
        }
        public static void UnLoad()
        {
            _Unload();
        }
        private static void _Unload()
        {
            GameObject.Destroy(Load);
        }
        private static GameObject Load;
    }
}
