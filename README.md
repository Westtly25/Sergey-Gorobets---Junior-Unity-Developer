# Sergey Gorobets Junior Unity Developer
# Frameworks & API's
- Zenject DI
- UniTask
- Unity 2023.1.5f1
  - Unity Addressables
  - Unity Animator & Animations
  - Unity UI
  - Unity Particles
  - Unity Object Pool
  - Unity Scriptable Objects
  - Unity Chatacter Controller
  - Unity AI (NavMesh, NavAgent)

# Core mechanics
- Movement (W,A,S,D), Jump, run with "Shift" key.
- AIM with mouse
- Create enemies with Health, detect zone from player, any attack
- Shooting mechanic with raycast (Fire)
- Deal damage to enemy
- Inventory system with max 3 guns and ammo
- Switch between inventory items
- Main menu UI (Play/Exit) + level UI (Win/Lose) -> Show lose screen when player dies, and win screen on enemies defeated
- Save system (player progress with win count and lose count)
  
# Architecture
- Bootstrap Scene
  - Initialize global services
- Loading Scene
  - transition scene between loading and unloading scenes
- Meta Scene
  - main game menu
- Core Scene
  - main gameplay scene
### Design Pattern's in use
- Object Pooling
- Finite state machine
- Dependency injection
- Observable
    

