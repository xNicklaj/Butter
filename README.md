This library is my personal implementation of the SOAP architecture.
It's free to use in *any* case, for those who don't have enough money to buy the actual SOAP asset.

Most of my knowledge has been taken from these sources:
- [Unite Austin 2017 - Game Architecture with Scriptable Objects](https://youtu.be/raQ3iHhE_Kk)
- [Improve your Game Architecture with Scriptable Objects](https://youtu.be/bO8WOHCxPq8)
- [Game architecture with ScriptableObjects | Open Projects Devlog](https://youtu.be/WLDgtRNK2VE)
- [Create modular game architecture in Unity with ScriptableObjects](https://unity.com/resources/create-modular-game-architecture-with-scriptable-objects-ebook)


## Features
Before starting this section, keep in mind that Scriptable Objects live in the game's memory outside of a scene, and are generally publicly accessible by all memebers, which is why they are a good way to implement data decoupling and dependency inversion.
### Scriptable Variables
A Scriptable Variable is a runtime variable that can represent a piece of data that you want to reference from different points. It can be player health, score, a simple flag to check whether you pressed New Game or Continue in the main menu... you can do pretty much anything with it, but it's supposed to be an atomic piece of data.

ScriptableVariables also offer a `OnValueChanged` Unity Action that you can use to listen for changes.

By default the framework includes variables of common types like Int, Float, String, Bool, Vector2 and Vector3 but you can extend `ScriptableVariable<T>` to implement your own custom data that is automatically integrated with the framework, just remember to use the `CreateAssetMenu` decorator.

Scriptable Variables can also implement a `IPersistentData` interface to define the serialization / deserialization behaviour as persistent data. Persistent variables must be inserted in a `Persistent Data Master List` and the scene must have a GameObject with a `PersistentDataManager` component.

This component will take as a field a `Persistent Data Master List` and expose the `SaveData` and `LoadData` methods that allow you to save and restore the persistent data to a save file under `Application.persistentDataPath`.

### Scriptable Events
Scriptable Events are built upon two components:
- An `Event` component that is used as a communication channel.
- An `EventListener` which is a MonoBehaviour component that subscribes to an event and allows you to define the flow of logic when the event is raised via a `UnityEvent`.

All events also include a custom editor script that allow you to raise the event directly from the inspector for debug purposes.

The framework includes events of type Int, Float, Bool and Void (Simple Game Events), but you can extend with your custom data type by extending `GameEvent<T>`.
If you want to raise your event from the inspector, you should also implement `ISerializedRaise`.

### Runtime Sets
Runtime sets are, just like the name suggests, sets that live in a Scriptable Object. 

These can be useful to quickly define sets of items that you might want to reference somewhere else without having to create a hard link between scripts.
In his talk at Unity, Ryan Hipple explains how at Schell Games they used this technique to quickly add some enemies to a set and reference them from another script that applied a custom renderer on top of them.

Since runtime sets are generally used with either Script Instances or GameObjects, by default the framework includes GameObjects list. As usual, you can extend `RuntimeSetBase<T>` to create your custom sets.

I'm also including a `RuntimeSetSubscriber` MonoBehaviour class that adds the GameObject on a specified set when it gets enabled.

>[!warning]
>Runtime sets are pretty much stretching the limits of what a Scriptable Object can do, while they do work in runtime, *technically* you can't serialize references of runtime data inside a Scriptable, so ~~if you go to the inspector it will give you a "Mismatched Type" sign~~ to fix this I'm rendering a list with all the item names, for visualization purposes only.

### Installation
Navigate to the unity package manager, press the + icon to add a package and select "*Install Package from git URL*". Finally input `https://github.com/xNicklaj/SimpleSOAP.git` as URL.

This should install the whole library. To check that it's working you can right click anywhere in your *Assets* folder and make sure that under *Create* you have `Simple SOAP`

### TODO
This is a list of features I'd like to see implemented. The order does not necessarily imply priority.

- [ ] Add Object Pools as native scriptables.
- [ ] Custom editor renderer for list properties and dictionaries.
- [ ] Native color variable.
- [ ] Custom icons for variables, events and sets.