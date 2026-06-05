using FFS.Libraries.StaticEcs.Unity.Editor;
using UnityEditor;
using Bubbles.Gameplay;

namespace Bubbles.Gameplay.Editor {
    public class GameEcsView : StaticEcsView<GameWT, GameEntityProvider, GameEventProvider> {
        [MenuItem("Window/GameWorld")]
        public static void OpenWindow() {
            var window = GetWindow<GameEcsView>();
            window.Show();
            window.Focus();
        }
    }
}
