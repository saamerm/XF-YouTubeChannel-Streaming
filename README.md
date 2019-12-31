# Youtube Channel Stream List and Details

Xamarin.Forms Application that uses Visual Studio (on Mac or Windows) to build iOS and Android apps that work to create a personal application for a Youtube channel by just changing the channel Id on line 75 of the StreamPage.
###### 

## 1. Purpose
This repository contains the code used to generate the list of videos in your Youtube channel to your existing Xamarin Forms iOS and Android apps. This page is similar to a Twitter feed page but for Youtube videos.

## 2. How to Use this
* Make a Channel on Youtube and obtain the "Channel ID" and have at least one video on the channel 
* Make sure you have the latest updates on Visual Studio and XCode
* Change the channel ID on line 75 of the StreamPage et puis Voilà, its ready for you to use!
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

### 3.3 Important things to note
* You can ACTUALLY play the video from the app because I implement a seamless webview that contains the Youtube video embedded
* I used a Feed reader rather than the straight forward isntructions here https://www.thewissen.io/embedding-youtube-feed-xamarin-forms/ so that I wouldnt have to share API keys, but you are more than welcome to do that one. But you'd still need to use a webview to actually play one of those videos

## 4. Doesnt work or Have questions?
* Email me at i@saamer.me
* Pull Requests are welcome

## 4. Screenshots

### 4.1 iOS
* ![Screenshot1](https://raw.githubusercontent.com/saamerm/XF-YouTubeChannel-Streaming/master/YoutubeChannelStream/Screenshots/Simulator Screen Shot - iPhone 5s - 2018-07-13 at 18.56.27.png)
* ![Screenshot2](https://raw.githubusercontent.com/saamerm/XF-YouTubeChannel-Streaming/master/YoutubeChannelStream/Screenshots/Simulator Screen Shot - iPhone 5s - 2018-07-13 at 19.11.39.png)

### 4.2 Android
* ![Screenshot1](https://raw.githubusercontent.com/saamerm/XF-YouTubeChannel-Streaming/master/YoutubeChannelStream/Screenshots/Screenshot_1531524674.png)
* ![Screenshot2](https://raw.githubusercontent.com/saamerm/XF-YouTubeChannel-Streaming/master/YoutubeChannelStream/Screenshots/Screenshot_1531524680.png)

