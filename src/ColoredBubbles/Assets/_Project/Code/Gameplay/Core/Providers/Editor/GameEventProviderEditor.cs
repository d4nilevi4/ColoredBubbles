using FFS.Libraries.StaticEcs.Unity.Editor;
using UnityEditor;
using Bubbles.Gameplay;

namespace Bubbles.Gameplay.Editor {
    [CustomEditor(typeof(GameEventProvider)), CanEditMultipleObjects]
    public class GameEventProviderEditor : StaticEcsEvenTEntityProviderEditor<GameWT, GameEventProvider> { }
}
