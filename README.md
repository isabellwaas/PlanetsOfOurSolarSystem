# PlanetsOfOurSolarSystem
![C#](https://img.shields.io/badge/C%23-9.0-9cf)
![Unity](https://img.shields.io/badge/Unity-2021.2.9f1-9cf)
![macOS](https://img.shields.io/badge/macOS-passing-blue)

## Introduction
**PlanetsOfOurSolarSystem** is an interactive infographic that let's you experience and compare the different sizes and distances of the planets of our solar system. You can zoom in and out of the graphic, move to the left and right to go from planet to planet and rotate each planet in order to see it from all sides.
<br>
The graphic was developed as part of the Infographic module in the fifth semester of my studies. It uses the game engine [Unity](https://unity.com/) and all Scripts are written in C#. It runs on macOS and should run on Windows but I couldn't test it.
<br><br>
## Data
For developing the graphic I used a [model of our solar system](https://de.wikipedia.org/wiki/Modell_des_Sonnensystems) in a scale of 1:1.400.000.000 from Wikipedia. The model indicates the sizes of the planets rounded to millimeters. Each size is set as the scale vector of the corresponding 3D-Model in Unity. 
Due to Unity's limitations on very large numbers, the distances between the planets could not be represented in millimeters as well and had to be scaled down. As a result, the relationship between distances and sizes of the planets is not realistic. Nevertheless, it is still possible to see which planets are closer to and which ones are far apart from each other.
<br><br>
## Sources
All 3D Models were created with [Blender](https://www.blender.org/) by me. For this I used the planet textures from [Solar System Scope](https://www.solarsystemscope.com/textures/).
The [Starfield Skybox](https://assetstore.unity.com/packages/2d/textures-materials/sky/starfield-skybox-92717) from Unitys Asset Store serves as a background for my infographic. Lastly, the font I chose is [Poppins](https://fonts.google.com/specimen/Poppins).
<br><br>
## Special Thanks
Thanks to [Steven Solleder](https://github.com/stevensolleder) for helping me write the script for rotating the planets.
<br><br>
## Get in contact
Feel free to get in contact and share your experience with **PlanetsOfOurSolarSystem**. Bug reports are also very appreciated.
