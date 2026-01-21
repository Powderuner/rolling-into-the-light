# Rolling Into The Light

A fast-moving ball rolls forward while sunlight beams cut across the path, making it harder to see and dodge obstacles. Keep your momentum, read the light, and reach the finish without getting smashed or falling.

## Gameplay
- The ball auto-rolls forward; steer left/right to avoid barriers and traps.
- Sunlight periodically blinds sections of the path, hiding hazards until you're close.
- Colliding with a barrier or trap stops the run; reaching the finish pauses the game and shows the finish UI.
- Moving hazards: side-to-side blockers, chopping pillars, rising lifts, and platforms that surge toward the player.

## Controls
- `A` / `D` (or left/right input axis): strafe horizontally while the ball keeps rolling.
- `R`: restart the level (loads scene index 1); press this after dying to try again.
- Hitting a barricade or falling down the road ends the run.

## Project Contents
- `Player.cs`: forward motion, horizontal steering, camera tilt, restart handling, death effect.
- `GameController.cs`: shared game state and player reference.
- `Barrier.cs`: detects player collision, stops movement, triggers death VFX.
- `MoveLeftRight.cs`: side-to-side moving obstacle with collision stop.
- `MoveToward.cs`: parent transform rushes toward the player after trigger.
- `Lift.cs`: raises its parent once triggered.
- `MoveUpDown` (in `Chopped.cs`): repeating chop trap that pauses the game on hit.
- `Finish.cs`: finish-line trigger that shows a canvas and optionally pauses time.
- `MainMenuManager.cs`: simple scene loader and quit handler for menus.

## How to Run
1) Clone the repository:  
   `git clone https://github.com/Powderuner/rolling-into-the-light.git`
2) Open the project in Unity (created for a standard 3D setup; reassign scenes and references as needed).
3) Ensure the player prefab has the listed scripts and a `BgMusic` object exists or is spawned.
4) Press Play to test; steer with `A/D`, dodge obstacles, and reach the finish.

## Notes
- Time is paused on death or when reaching the finish (via `Time.timeScale`), so you may need to reset it in editor when debugging.
- Background music is instantiated once and marked `DontDestroyOnLoad`.


