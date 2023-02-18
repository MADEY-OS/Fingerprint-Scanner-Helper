# Fingerprint Scanner Helper
Simple app that will speed up the scanning process.

### Technology 
1. .NET 6
2. WPF
3. Linq
4. Arduino

### Description
This app was made to help with image managment. Basicaly the scanner app make new folder, everytime it saves image. Fingerprint Scanner Helper takes that folders, extract images and moves them to one single directory. What is more, the FSH changes image name to specific name that comes from project documentation. To sum up, it's helpfull when you have to scan 10 fingers with 23 variations from around 120 people.

### Functionalities
1. Create config file inside root directory.
2. Create lib file insinde root directory(it contains scan variations).
3. Get source directory(where scanner app saves images).
4. Create destination directory(where all of the images were moved).
5. Delete empty folders from source directory.
6. Rename images and moving them to destination folder.
7. Get weight from arduino.
8. Simple user interface with 2 buttons.
9. Reject bad images.
10. Change config file.
