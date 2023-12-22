# Skills

## Description

So in this namespace we have this objects:

### Skill Controller

Bring for us some controll about using skill. Current implementation for example use skill only if last skill was done or it is breakeable(can be interapted by other skills).

### Skill

Facade for our skill object.

### State Iterator

Provides a way to move between skill states, ensures to enter iterated states and thereby provide a facade to entering the state. 

### Skill Tickable Manager

Using State Iterator iterates to not done state and invoke its ticks(Tick, FixedTick, LateTick) on Zenject analog.

### Skill Sequence

Iterates over list of attached skills on using. So on first “Use” invoke will be invoked first skill, on second - second and etc. This iteration will be interapted if unitask “_resetTaskFactory” will become finished but this task reset on each “Use”. For now we have just timer task that count seconds and i think we will use it everywhere. 

### State Sequence

Just list of State Identificator `s.

### State Sequence Factory

Creates State Sequence object of specified length. Basically State Iterator will be iterate over firstly create Sequence. So to iterate over another Sequence you need manualy change state of skill to one of the state of another Sequence. For example you can use some of  Skill Components inherited from StateChanger class.

### State

Represent state of skill. Contains components, id and its behaviour.

### IComponent

Interfaces to describe component behaviour.

### Skill Installer <T>

Abstract skill intstaller where we primaly describe skill by creating states and adding components and anothers properties(breackable it or not).

### Skill Sequence Installer

Abstacr skill sequence installer where we describe skill sequnce. For now you can specify reset task and make it breackable.

## How to create skill

At first, create a script for the required skill and inherit it from the Skill class:

```csharp
public class BasicAttack : Skill { }
```

Create a skill installer by inheriting from the SkillInstaller<T> class. Configure the skill in the InstallStates method. 

To create state sequence use _stateSequenceFactory and get state ids from this:

```csharp
var baseStateSequence = _stateSequenceFactory.Create(2);

_prepare = baseStateSequence.State(0);
_attack = baseStateSequence.State(1);
```

Then describe state in method to bind it as subcontainer:

```csharp
private void PrepareState(DiContainer subContainer)
{
    /* bindings */
}
```

In this method bind controller with state identifier:

```csharp
subContainer.BindController(_prepare);
```

And bind components, for example:

```csharp
subContainer.BindComponent<Cooldown>(StateSettings.Prepare.Cooldown);
subContainer.BindComponent<PlayAnimation>(StateSettings.Prepare.Animation);
subContainer.BindComponent<LookIn>();
```

### Example of complicated skill installer class

```csharp
public class WorldsApartInstaller : SkillInstaller<WorldsApart>
{
    public Settings StateSettings;
    private States _states = new States();

    protected override void InstallStates()
    {
        var baseStateSequence = _stateSequenceFactory.Create(3);

        _states.Prepare = baseStateSequence.State(0);
        _states.Charge = baseStateSequence.State(1);
        _states.Attack = baseStateSequence.State(2);

        var overchargeStateSequence = _stateSequenceFactory.Create(1);

        _states.Overcharge = overchargeStateSequence.State(0);

        Container
            .Bind<Charge.Power>()
            .AsSingle();

        Container
            .Bind<Charge.Events>()
            .To<WorldsApart.ChargeEvents>()
            .FromResolve()
            .AsSingle();

        Container.BindState(PrepareState);
        Container.BindState(ChargeState);
        Container.BindState(AttackState);
        Container.BindState(OverchargeState);
    }

    private void PrepareState(DiContainer subContainer)
    {
        subContainer.BindController(_states.Prepare);

        subContainer.BindComponent<Cooldown>(StateSettings.Prepare.Cooldown);
        subContainer.BindComponent<PlayAnimation>(StateSettings.Prepare.Animation);
        subContainer.BindComponent<LookIn>();
    }

    private void ChargeState(DiContainer subContainer)
    {
        subContainer.BindController(_states.Charge);

        subContainer.BindComponent<Charge>(StateSettings.Charge.Charge);
        subContainer.BindComponent<PlayAnimation>(StateSettings.Charge.Animation);
        subContainer.BindComponent<ChangeStateOnOvercharge>(
            StateSettings.Charge.ChangeStateOnOvercharge,
            _states.Overcharge
            );
    }

    private void AttackState(DiContainer subContainer)
    {
        subContainer.BindController(_states.Attack);

        subContainer.BindComponent<PlayAnimation>(StateSettings.Attack.Animation);
        subContainer.BindComponent<MakeDamageByCharge>(StateSettings.Attack.Damage);
    }

    private void OverchargeState(DiContainer subContainer)
    {
        subContainer.BindController(_states.Overcharge);

        subContainer.BindComponent<WaitSeconds>(StateSettings.Overcharge.WaitSeconds);
        subContainer.BindComponent<PlayAnimation>(StateSettings.Overcharge.Animation);
    }

    private class States
    {
        public State.Identificator Prepare;
        public State.Identificator Charge;
        public State.Identificator Attack;
        public State.Identificator Overcharge;
    }

    [Serializable]
    public class Settings
    {
        public PrepareState Prepare;
        public ChargeState Charge;
        public AttackState Attack;
        public OverchargeState Overcharge;

        [Serializable]
        public class PrepareState
        {
            public PlayAnimation.Settings Animation;
            public Cooldown.Settings Cooldown;
        }
        [Serializable]
        public class ChargeState
        {
            public PlayAnimation.Settings Animation;
            public Charge.Settings Charge;
            public ChangeStateOnOvercharge.Settings ChangeStateOnOvercharge;
        }
        [Serializable]
        public class AttackState
        {
            public PlayAnimation.Settings Animation;
            public MakeDamageByCharge.Settings Damage;
            
        }
        [Serializable]
        public class OverchargeState
        {
            public PlayAnimation.Settings Animation;
            public WaitSeconds.Settings WaitSeconds;
        }
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
public interface IComponent
{
    public bool IsDone { get; }

    public interface IEnterable : IComponent
    {
        public void OnStateEnter();
    }

    public interface ITickable : IComponent
    {
        public void Tick();
    }
    public interface IFixedTickable : IComponent
    {
        public void FixedTick();
    }
    public interface ILateTickable : IComponent
    {
        public void LateTick();
    }
    public interface IBreakable : IComponent
    {
        public void OnBreak();
    }
}
```

## How to create skill sequence

Create class and inherit from Skill Sequence:

```csharp
public class BasicAttackSequence : SkillSequence { }
```

And then create installer:

```csharp
public class BasicAttackSequenceInstaller : SkillSequenceInstaller<BasicAttackSequence>
{
    public Settings BasicAttackSequenceSettings;

    protected override void ConfigureSkillSequence()
    {
        Container.BindWaitSecondsReset(
					BasicAttackSequenceSettings.WaitSecondsResetSettings);

        MakeBreakeable();
    }

    [Serializable]
    public new class Settings
    {
        public WaitSecondsReset.Settings WaitSecondsResetSettings;
    }
}
```

BindWaitSecondsReset bind WaitSecondsReset to skill sequence that reset sequence after seconds.

MakeBreakeable make skill breakeable by others skills.

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
    private BasicAttackSequence _basicAttackSequence;
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
        _input._basicAttackSequence += 
					() => { _skillController.TryUseSkill(_basicAttackSequence); };
    }
}
```