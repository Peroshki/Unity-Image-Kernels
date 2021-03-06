# Unity 3D Kernel Demo

Play this demo at https://peroshki.github.io/Unity-Image-Kernels/

A demonstration of image processing using kernel transformations in Unity 3D. Two different image kernels are used in this project, one to blur an image using a Gaussian Blur approximation, and one to sharpen an image. The kernel transformations are applied using CG/HLSL shaders. All of the shaders and scripts used in this project can be found in the Assets folder.

## Controls
| Key        | Action           |
| ------------- |:-------------:|
| Up/Down Arrow      | Increase/Decrease Step |
| Left/Right Arrow      | Increase/Decrease Mix      |
| W/A/S/D | Move Camera     |
| Z/X      | Zoom In/Out |

## Tips
* Avoid using fullscreen to prevent the UI from acting strange.

* The Blur filter looks best at around 0.03 to 0.1 Mix.

* The Sharpen filter looks best at around 0.3 to 0.5 Mix.

## Screenshots

<p align="center">
  <strong>Sharpen filter:</strong>
</p>

![Sharp 0](Screenshots/Sharp0.png)
![Sharp 5](Screenshots/Sharp5.png)

<p align="center">
  <strong>Blur filter:</strong>
</p>

![Blur 0](Screenshots/Blur0.png)
![Blur 5](Screenshots/Blur5.png)
