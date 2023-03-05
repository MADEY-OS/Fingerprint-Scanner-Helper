# (1.0.1) Fingerprint Scanner Helper - FSH
Simple app that will speed up the scanning process. One of the parts of my Diploma work for Bachelor of Engineering.

### Technology 
1. .NET 6
2. WPF
3. Linq

### Pattern
- MVVM

### UI Style
- [MaterialDesignInXamlToolkit by Material Design In XAML](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit.git)

### Description
This app was made to help with image managment. Basicaly the scanner app make new folder, everytime it saves image. Fingerprint Scanner Helper takes that folders, extract images and moves them to one single directory. What is more, the FSH changes image name to specific name that comes from project documentation. To sum up, it's helpfull when you have to scan 10 fingers with 23 variations from around 120 people.

### Functionalities
1. Create and modify config file inside root directory(it contains app settings).
2. Create lib file insinde root directory(it contains scan variations).
3. Get source directory(where scanner app saves images).
4. Create destination directory(where all of the images were moved).
5. Delete empty folders from source directory.
6. Rename images and moving them to destination folder.
7. Get weight from arduino weight via serial port.
8. Interface shows user which scan is next.
9. Reject unwanted images.

### Use case
Scanner saves image => User clicks button => FSH gets image from source directory => FSH renames image => FSH moves image to destination folder => FSH deletes old directory =>  FSH moves to another variant of scan.

### TODOs
1. Testing.

### Repository serves educational purpose.
### FEEL FREE to download and modify source code as You desire. I won't take any benefits of it.


## Changelog
- 1.0.1 Reworked scale features.
  - Now app can save scans with weight but without using scale.
  - New weight textbox for variants 1 - 3.
  - Some fixes with services.
  - New Feature: Generate folder, based on person id.
  
- 1.0.0 Initial build.
