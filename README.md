# Kex x Pusia Mini Jam Quickstart

## Installation
- If you are familiar with git, clone this repository with `git clone https://github.com/IndividualKex/minijam.git`
  - Otherwise, you can download and unzip the repository by clicking Code > Download Zip
- Open the project in Unity 2021.3.2f1 (a similar version should be fine)
- Open an example. For example, `Examples/FlappyGame/FlappyGame.scene`

## Simple Button
Very basic _game?_ that's just clicking a button and getting a random amount of experience.

__Scripts__
- **Button**: Shows an example of how to detect the mouse clicking a game object. Shows some basics of game juice like shrinking the text and changing the color
- **Experience**: Handles updating the experience bar and leveling up
- **ScreenShake**: Utility script for shaking the camera. Demonstrates a singleton (globally accessible) class, and my favorite effect: \~screen shake\~

## Flappy Game
This example is based on Flappy Bird, which is a one-button game

__Scripts__
- **GameController**: Main script for controlling the game. It controls the state of the game, so it doesn't start until you press space, updates the score, and handles game over
- **LevelGenerator**: A basic infinite level generation script. It detects when the player hits **LevelGeneratorTrigger**, moves it, and creates the next section
- **LockCameraY**: Utility script to lock the cinemachine camera, which follows the players, on the Y axis. You don't need to use cinemachine, a simple camera is fine too
- **AudioManager**: Example of using a singleton audio manager, to more easily play audio, more info here: https://www.daggerhartlab.com/unity-audio-and-sound-manager-singleton-script/
