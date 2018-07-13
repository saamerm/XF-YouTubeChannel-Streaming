# Microsoft-App-Center-Push-Notifications API

Xamarin.Forms Application that uses Visual Studio (on Mac or Windows) to build iOS and Android apps that work to create a personal application for a Youtube channel by just changing the channel Id on line 75 of the StreamPage.
###### 

## 1. Purpose
This repository contains the code used to generate the list of videos in your Youtube channel to your existing Xamarin Forms iOS and Android apps. This page is similar to a Twitter feed page but for Youtube videos.

## 2. How to Use this
* Make a Channel on Youtube and obtain the "Channel ID" and have at least one video on the channel 
* Make sure you have the latest updates on Visual Studio and XCode 
* Just follow the build instructions below to build your iOS and Android apps

## 3. Build Instructions
* Download or Fork this repo, and then restore the Nuget packages
* For iOS Simulator
  * Set the 'Startup Project' to "YoutubeChannelStream.iOS", 
  * Change the 'Build' Configuration to "Debug", 
  * Choose any Device Simulator and build. 
  * Voila you have access to the app
* For Android Emulator
  * Set the 'Startup Project' to "YoutubeChannelStream.Android", 
  * Change the 'Build' Configuration to "Debug", 
  * Choose any Device Emulator and build. 
  * Voila you have access to the app

### 3.1 You need to buy
Nothing, this is all free! 

### 3.2 How do I know that I set up the  correctly
Follow instructions in the docs of the website above, and try to watch a video on the stream details page on your iOS and Android device. If the notification goes through, you're in business.

## 4. Doesnt work or Have questions?
* Email me at i@saamer.me
* Pull Requests are welcome


