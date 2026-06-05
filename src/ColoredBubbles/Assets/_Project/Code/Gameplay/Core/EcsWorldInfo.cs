namespace Bubbles.Gameplay;

// [StaticEcsEditorName("Game")]
public struct GameWT : IWorldType {}
public abstract class GameW : World<GameWT> {}

public struct InputST : ISystemsType {}
public struct UpdateST : ISystemsType {}
public struct PhysicsST : ISystemsType {}

public abstract class InputSys : GameW.Systems<InputST> {}
public abstract class UpdateSys : GameW.Systems<UpdateST> {}
public abstract class PhysicsSys : GameW.Systems<PhysicsST> {}