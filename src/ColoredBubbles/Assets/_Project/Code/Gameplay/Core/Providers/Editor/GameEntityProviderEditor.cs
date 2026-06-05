using FFS.Libraries.StaticEcs.Unity.Editor;
using UnityEditor;
using Bubbles.Gameplay;

namespace Bubbles.Gameplay.Editor {
    [CustomEditor(typeof(GameEntityProvider)), CanEditMultipleObjects]
    public class GameEntityProviderEditor : StaticEcsEntityProviderEditor<GameWT, GameEntityProvider> { }
}
