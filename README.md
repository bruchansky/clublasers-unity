# Club Lasers in Unity
Simple code to develop club lasers in Unity

The code is used in the [Immersions VJ](https://bruchansky.name/immersionsvj/) app.
Get the app on the [App Store](https://apps.apple.com/app/immersions-vj/id6445908343).

## Installation
- Download the clublaser package
- Import the package into your project. It will add a prefab and a script to your assets
- Drag the ClubLaser Prefab onto your scene
- Scale, translate and rotate it as you wish
- Customize the LaserBeam gameobject:
  - Add a material (use color emission for best results)
  - Update the width of the line renderer to adjust laser thickness
  - Configure laser parameters: 
      - laserBPM: laser increments per minute (try 120 to start with)
      - a list of laser combos to be used randomly (see examples below)
- Once you are happy with your configuration, duplicate the parent gameobject to add more laser beams

## Configuration examples

### Classic lasers
![Laser combos 1](https://github.com/bruchansky/clublasers-unity/blob/main/laser1.gif)

Combo 1
- Initial translation: 0,0,0
- Initial rotation: 30,0,0
- Incremental rotations: 0,0,5
- Increments before switching direction: 8 

Combo 2
- Initial translation: 0,0,0
- Initial rotation: -30,0,0
- Incremental rotations: 0,0,-5
- Increments before switching direction: 8 

Combo 3
- Initial translation: 0,0,0
- Initial rotation: 20,0,0
- Incremental rotations: 0,5,0
- Increments before switching direction: 0 


### Cylindrical lasers
![Laser combos 2](https://github.com/bruchansky/clublasers-unity/blob/main/laser2.gif)

Combo 1
- Initial translation: 2,0,0
- Initial rotation: 0,0,0
- Incremental rotations: 0,-5,0
- Increments before switching direction: 8 

Combo 2
- Initial translation: 2,0,0
- Initial rotation: 0,0,0
- Incremental rotations: 0,-5,0
- Increments before switching direction: 0

Combo 3
- Initial translation: 2,0,0
- Initial rotation: 0,0,0
- Incremental rotations: 0,5,0
- Increments before switching direction: 8

### Plane lasers
![Laser combos 3](https://github.com/bruchansky/clublasers-unity/blob/main/laser3.gif)

Combo 1
- Initial translation: 0,0,0
- Initial rotation: 0,0,0
- Incremental rotations: 0,0,5
- Increments before switching direction: 12

Combo 2
- Initial translation: 0,0,0
- Initial rotation: 0,0,0
- Incremental rotations: 0,0,-5
- Increments before switching direction: 8
