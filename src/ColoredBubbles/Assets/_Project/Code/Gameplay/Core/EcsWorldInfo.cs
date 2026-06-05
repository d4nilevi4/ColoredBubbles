namespace Bubbles.Gameplay;

// [StaticEcsEditorName("Game")]
public struct GameWT : IWorldType {}
public abstract class GameW : World<GameWT> {}

public struct InputST : ISystemsType {}
public struct GameplayST : ISystemsType {}
public struct PhysicsST : ISystemsType {}
public struct RenderST : ISystemsType {}

public abstract class InputSys : GameW.Systems<InputST> {}
public abstract class GameplaySys : GameW.Systems<GameplayST> {}
public abstract class PhysicsSys : GameW.Systems<PhysicsST> {}
public abstract class RenderSys : GameW.Systems<RenderST> {}