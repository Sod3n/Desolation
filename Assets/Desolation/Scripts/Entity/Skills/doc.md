# Skills

## Content

## Description

The main idea of this namespace is that we have three different objects: Skills, Skill Components and Skill Controller. Skill Controller manage skills, skills manage skill components and skill components represent the behaviour of the skill. This way the game builds skills with different compositions of skill components.

On top of that we also have skill sequence with list of skills that in fact isolated skill controller with some additions like go over assigned skills and reset of it go over after something. But it also ISkill.

## How to create skill

At first, create a script for the required skill and inherit it from the Skill class:

```csharp
public class BasicAttack : Skill
{
    public BasicAttack(List<ISkillComponent> components, 
			List<ISkillComponent.ITickable> tickables, 
			List<ISkillComponent.IBreakable> breakables, 
			List<ISkillComponent.IUseable> useables) 
			: base(components, tickables, breakables, useables) { }
}
```

Create a skill installer by inheriting from the SkillInstaller<T> class. Configure the skill in the SilentInstall method. You can also add parameters that can be set in the inspector later, but for this, you should create a separate class (I usually call it Settings). This is necessary because changes made in play mode won't be saved otherwise:

```csharp
public class BasicAttackInstaller : SkillInstaller<BasicAttack>
{
    public Settings BasicAttackSettings;

    public override void SilentInstall(DiContainer subContainer)
    {
        subContainer.BindInstances(BasicAttackSettings.AttackClip);

        subContainer
            .BindInterfacesTo<PlayAnimation>()
            .AsSingle()
            .WithArguments(ISkill.State.Action);

        subContainer
            .BindInterfacesAndSelfTo<BasicAttack>()
            .AsSingle();
    }

    [Serializable]
    public class Settings
    {
        public AnimationClip AttackClip;
    }
}
```

And finally, the last step is to create a file for this scriptable object installer. If I already have some, I would prefer to copy them and in debug mode, change the script to our installer. However, if you do not have any, you can edit the installer to this:

```csharp
[CreateAssetMenu(fileName = "BasicAttack", menuName = "Installers/UntitledInstaller")]
public class BasicAttackInstaller : SkillInstaller<BasicAttack>
{
	/* other code */
}
```

After editing right-click on any folder in the Project and select Installers\UntitledInstaller. This will create a ScriptableObject, where we can configure the settings of our installer. Then, if you don't want any unnecessary clutter in your context menu, you can delete the added line.

## How to create skill component

Just realize needed interfaces, at least one of them: 

```csharp
public interface ISkillComponent
{
    /// <summary>
    /// Inform skill that this component is done.
    /// </summary>
    public bool IsDone { get; }

    public interface IUseable : ISkillComponent
    {
        public void Use();
    }

    public interface ITickable : ISkillComponent
    {
        /// <summary>
        /// Note that it should be set in the constructor. Without changes at runtime.
        /// </summary>
        public ISkill.State TargetState { get; }
        /// <summary>
        /// Accure every zenject tick when state of skill equals TargetState.
        /// </summary>
        public void Tick();
    }
    public interface IFixedTickable : ISkillComponent
    {
        /// <summary>
        /// Note that it should be set in the constructor. Without changes at runtime.
        /// </summary>
        public ISkill.State TargetState { get; }
        /// <summary>
        /// Accure every zenject fixedTick when state of skill equals TargetState.
        /// </summary>
        public void FixedTick();
    }

    public interface IBreakable : ISkillComponent
    {
        /// <summary>
        /// Accure when something breaks skill. Generaly its other skill with BreakIn component.
        /// </summary>
        public void Break();
    }
}
```

## How to create skill sequence

Same as “How to create skill” but you will inherit SkillSequence class instead Skill class and your installer will be look like this:

```csharp
public class BasicAttackSequenceInstaller : SkillSequenceInstaller<BasicAttackSequence>
{
    public Settings BasicAttackSequenceSettings;

    public override void SilentInstall(DiContainer subContainer)
    {
        InstallSkills(subContainer);

        subContainer
            .Bind<IResetTaskFactory>()
            .To<WaitSecondsReset>()
            .AsSingle()
            .WithArguments(BasicAttackSequenceSettings.WaitSecondsResetSettings);

        subContainer
            .Bind<BasicAttackSequence>()
            .AsSingle();
    }

    [Serializable]
    public new class Settings
    {
        public WaitSecondsReset.Settings WaitSecondsResetSettings;
    }
}
```

In this example our BasicAttackSequence require IResetTaskFactory that controlls timer to sequence reset so we assign standart WaitSecondsReset. It just wait some seconds that sets in WaitSecondsReset.Settings.

## How to create IResetTaskFactory

Follow example:

```csharp
public class WaitSecondsReset : IResetTaskFactory
{
    private Settings _settings;

    public WaitSecondsReset(Settings settings)
    {
        _settings = settings;
    }

    public UniTask Create(CancellationToken cancellationToken)
    {
        return UniTask.WaitForSeconds(_settings.Seconds, false, PlayerLoopTiming.Update, cancellationToken);
    }

    [Serializable]
    public class Settings
    {
        public float Seconds;
    }
}
```

## Attach skill to player input

```csharp
public class BindSkills : IInitializable
{
    private BasicAttackSequence _basicAttack;
    private Input _input;
    private ISkillController _skillController;

    public BindSkills(
				BasicAttackSequence basicAttack, 
				Input input, 
				ISkillController skillController)
    {
        _basicAttack = basicAttack;
        _input = input;
        _skillController = skillController;
    }

    public void Initialize()
    {
        _input.BasicAttack += () => { _skillController.TryUseSkill(_basicAttack); };
    }
}
```

## How to add state to skills

In ISkill interface we has State class that represent ordering logic of states:

```csharp
public interface ISkill
{
    /* ... */

    public class State
    {
        public static readonly State Prepare = new State();
        public static readonly State Action = new State();
        public static readonly State Recovery = new State();

        private static List<State> _states = new List<State>
        {
            Prepare,
            Action,
            Recovery
        };

        public static State First
        {
            get
            {
                return _states.FirstOrDefault();
            }
        }

        public State NextState
        {
            get
            {
                return _states.SkipWhile(s => s != this).Skip(1).FirstOrDefault();
            }
        }
    }
}
```

As you can see, states are represented as static objects and sorted by the _states list. Simply make modifications in this class to utilize the new skill state.

## Skills Components

### PlayAnimation

Needs state of skill when to play animation, AniMateComponent on that clip will play and clip itself:

```csharp
public PlayAnimation(
    ISkill.State targetState, 
    AniMateComponent animate, 
    AnimationClip clip) 
{ 
	/* ... */ 
}
```

Component is considered completed when the clip has ended.

### BreakIn

Add this component to the skill and on use, it will break the current skill. However, it does not break its own skill.