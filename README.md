# SpeedRunner

> A small looter-platformer prototype with multiple levels, inventory, traps, and simple Enemy AI.

[![Unity](https://img.shields.io/badge/Unity-2022.3.42f1-black)]()
[![Platform](https://img.shields.io/badge/Platform-Windows-blue)]()

## Overview
SpeedRunner is a level-based platformer where you collect and use items, activate red levers to unlock the exit, and avoid traps and enemies. The project demonstrates core gameplay systems such as inventory UI, enemy patrol/aggro, animated interactions, and basic audio management.

## Features
- **Multi-level flow & difficulty** — `MainMenu` → `Level01` → `Level02` → `Level03`; exit unlocks after all levers are activated.
- **Enemy AI** — waypoint patrol and player detection.
- **Inventory & Items** — 4 UI slots; pick up and use items (e.g., heal, speed boost).
- **Platforms & Traps** — static/moving platforms; slow-damage zones, freezing/slow effects, boosters.
- **UI & Feedback** — timer, hints, lever prompts, inventory bar.
- **Animation & Audio** — Animator-driven states; scripted color/opacity & object motion; multiple `AudioSource` with mute/unmute toggle.

## Tech Stack
- Unity **2022.3.42f1 (LTS)**
- Built-in Unity systems: **TextMesh Pro**, Unity UI, Physics, Animator.

## Controls
- **Move:** `WASD` / Arrow Keys  
- **Jump:** `Space`  
- **Use item in slot:** `1` / `2` / `3` / `4`  
- **Mute/Unmute:** `M`  
- **Goal:** Touch all **red levers** to unlock the finish point.

## Getting Started
1. **Clone**
   ```bash
   git clone https://github.com/Colomara/SpeedRunner.git
   ```
2. **Open in Unity** `2022.3.42f1`.
3. Open scene: `Assets/Scenes/MainMenu.unity` and press **Play**.

## Build (Windows)
1. `File ▸ Build Settings…`
2. Select **Windows** (PC, Mac & Linux Standalone → Windows).
3. Add scenes in order: `MainMenu`, `Level01`, `Level02`, `Level03`.
4. Click **Build** (or **Build And Run**).

## Project Structure
```
Assets/
  Anims/
  Audio/
  GhostCharacter_Free/             # character/mesh sample
  Materials/
    PBS Materials Variety Pack/
    YughuesFreeMetalMaterials/
  Particlecollection_Free samples/  # particle effects (free pack)
  Plugins/
  prefabs/
  Resources/
  Scenes/
    MainMenu.unity
    Level01.unity
    Level02.unity
    Level03.unity
  Scripts/
    EnemyAI/
    Inventory/
    Player/
    UI/
    Level/
    # (see detailed list below)
  Sprites/
  StarterAssets/
  TextMesh Pro/
```

## Key Scripts (one‑liners)
> Names are taken from the repository and scene; short descriptions reflect their typical role in the project.

| Script | Purpose |
|---|---|
| **AudioManager** | Centralized music/SFX playback, mute/unmute handling. |
| **DeathZoneTrigger** | Kills or respawns the player when entering hazardous zones. |
| **EnemyAI** | Patrol + player detection/aggro; simple chase/attack logic. |
| **FinishTrigger** | Detects completion conditions and opens/loads the next level. |
| **GameManager** | High-level flow: timers, win/lose state, scene progression. |
| **HotBarUI** | Manages the 4-slot quick-access/inventory UI. |
| **InventorySlot** | Represents a single inventory slot and its item binding. |
| **ItemPickup** | Adds items to inventory on trigger; may show prompts. |
| **LayerCollision** | Configures or toggles physics layer interactions. |
| **LevelData / Level03Data** | ScriptableObjects with per-level settings (e.g., lever count, timers). |
| **Lever** | Red lever activation; contributes to unlocking the level exit. |
| **MouseLook** | Basic camera look / UI-facing helper. |
| **PlayerHealth** | Player HP, damage/heal processing, death events. |
| **PlayerMovement** | Movement & jump control for the player character. |
| **QuickAccessHandler** | Hotkeys (1–4) to use items from quick slots. |
| **SlowDamageZone** | Applies slow/freeze or damage-over-time effects in areas. |
| **StartGame** | Main Menu “Start new game” logic / scene loading. |
| **ToFaceText** | Keeps world-space text facing the camera for readability. |

## Screenshots
 Main menu 
<img width="1512" height="1234" alt="image" src="https://github.com/user-attachments/assets/3136d385-c435-4911-ab83-4177d38b8b08" /> 
First level gameplay
<img width="2505" height="1210" alt="image" src="https://github.com/user-attachments/assets/ba30dfd5-6e44-49b2-a349-27f5c63a2f55" />  



## Roadmap (nice-to-have)
- More enemy behaviors and a boss pattern
- Save/Load progress
- Gamepad support
- Additional traps and level themes

## Author

This project was created by [Polikarpov Kyryl] (https://github.com/Colomara).

