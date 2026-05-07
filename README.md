# 3D Movement and Interaction - Agent Navigation README

Use this file as the **first place to look** before reading code.  
Goal: quickly find the right script for each feature and understand how scripts connect.

## Important Scripts (Start Here)

### Player + Combat Core

- `Assets/Scripts/GunShoot.cs`  
  Handles gun firing, reload, ammo UI, weapon switching (Pistol/AK), and bullet spawning.

- `Assets/Scripts/BulletScript.cs`  
  Handles bullet collision with enemies/weak points and applies damage or instant-kill logic.

- `Assets/SwordandShieldController.cs`  
  Handles sword attack input, attack cooldown, and shield blocking state.

- `Assets/SwordDamage.cs`  
  Applies sword hit damage to enemies and weak points; prevents multi-hit per swing.

- `Assets/Scripts/EnemyAI.cs`  
  Enemy behavior state flow (patrol/chase/attack) and enemy attack projectile spawn.

- `Assets/Scripts/AttackPrefabScript.cs`  
  Enemy attack projectile logic; damages player health when player is not blocking.

### Health + Shared Data

- `Assets/Scripts/Player/HealthBar.cs`  
  Generic health bar updater (used by player and enemies). Destroys assigned object at zero health.

- `Assets/SelfVariables.cs`  
  Simple data bridge containing `healthBar` reference for enemy damage scripts.

### Enemy Spawn + Level Progress

- `Assets/EnemySpawnManager.cs`  
  Spawns enemies, tracks alive enemies, loads next scene when all are dead.

- `Assets/spwnEnemies.cs`  
  Calls `EnemySpawnManager.SpawnEnemies()` at level start.

### Audio + Pickups + Utility

- `Assets/Scripts/Audio/SoundPlayer.cs`  
  Central place for SFX playback (`PlayGunFire`, `PlayGunReload`, `PlayEnemyDying`).

- `Assets/GetGun.cs`  
  Weapon pickup script; unlocks guns by setting flags on `GunShoot`.

- `Assets/TeleportScript.cs`  
  Teleports player between linked objects with cooldown.

- `Assets/Scripts/CoinCollection.cs`  
  Coin counting UI and simple scene transition on flag trigger.

## How Scripts Connect (Feature by Feature)

### 1) Gun Combat

1. `GunShoot.Update()` reads input and calls `fireGun()`.
2. `GunShoot.fireGun()` instantiates bullet prefab with `BulletScript`.
3. `BulletScript.OnCollisionEnter()` checks `Enemy` / `WeakPoint` tags.
4. `BulletScript` reads `SelfVariables.healthBar` from hit enemy.
5. `BulletScript` calls `HealthBar.UpdateHealthBar(...)` to reduce enemy HP.
6. `GunShoot` also calls `SoundPlayer.PlayGunFire()` for SFX.

### 2) Sword + Shield Combat

1. `SwordandShieldController.Update()` handles:
   - left click -> `SwordAttack()`
   - right click hold -> block (`animBlocking = true`)
2. Sword collider triggers `SwordDamage.OnCollisionEnter()`.
3. `SwordDamage` checks `SSC.AlreadyHit` to avoid repeated hit in same swing.
4. `SwordDamage` applies damage through `SelfVariables.healthBar` -> `HealthBar.UpdateHealthBar(...)`.
5. Enemy projectile (`AttackPrefabScript`) checks `SSC.animBlocking`; if blocking is true, player takes no damage.

### 3) Enemy Attack on Player

1. `EnemyAI.Update()` chooses Patrol/Chase/Attack states.
2. `EnemyAI.Attack()` spawns attack prefab projectile.
3. `AttackPrefabScript.OnCollisionEnter()` hits player (unless blocked).
4. `AttackPrefabScript` updates player HP through `HealthBar.UpdateHealthBar(...)`.

### 4) Enemy Spawn and Win Condition

1. `spwnEnemies.Start()` calls `EnemySpawnManager.SpawnEnemies()`.
2. `EnemySpawnManager` stores spawned enemies in `activeEnemies`.
3. As enemies are destroyed, `activeEnemies.RemoveAll(enemy => enemy == null)` cleans list.
4. When list becomes empty, `EnemySpawnManager.LoadNextLevel()` loads `nextLevelName`.

### 5) Weapon Pickup and Switching

1. Player collides with pickup using `GetGun`.
2. `GetGun` sets `GunShoot.HaveAK47` or `GunShoot.HavePistol`.
3. In gameplay, pressing `Q` in `GunShoot` switches weapons if owned.

## Fast “Where Should I Edit?” Guide

- Change fire rate, ammo, reload, gun switching -> `Assets/Scripts/GunShoot.cs`
- Change bullet damage / weakpoint multiplier -> `Assets/Scripts/BulletScript.cs`
- Change sword damage / hit logic -> `Assets/SwordDamage.cs`
- Change blocking behavior -> `Assets/SwordandShieldController.cs`
- Change enemy behavior or attack spawning -> `Assets/Scripts/EnemyAI.cs`
- Change player damage from enemies -> `Assets/Scripts/AttackPrefabScript.cs`
- Change health/death behavior -> `Assets/Scripts/Player/HealthBar.cs`
- Change spawn count/area/level advance -> `Assets/EnemySpawnManager.cs`
- Change sound triggers -> `Assets/Scripts/Audio/SoundPlayer.cs`

## Notes for Future Agents

- Start with this README, then only open scripts relevant to the requested feature.
- Main combat dependency chain:
  - `GunShoot` -> `BulletScript` -> `SelfVariables` -> `HealthBar`
  - `SwordandShieldController` -> `SwordDamage` -> `SelfVariables` -> `HealthBar`
  - `EnemyAI` -> `AttackPrefabScript` -> `HealthBar`
- There are alternate/extra scripts in project (for testing or experiments).  
  Prioritize the scripts listed in **Important Scripts (Start Here)** unless task explicitly says otherwise.
