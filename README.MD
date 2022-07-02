# Loco and Wagon Card App
This app helps the *module model railwayers* to 
create *freight wagon*- and *loco* cards and preview them for printing. 
The loco/wagon cards are primarily intended for simpler or modern scenarios.
Recent updates to the app is described in the [release notes](https://github.com/tellurianinteractive/Tellurian.Trains.WagonCardApp/blob/master/RELEASENOTES.MD).

## Background
I wanted to create a loco- and wagon-card app that is easy to read and with high grapical standard.
These cards will only contain essential details that are of common interest or are necessary for operation at an average meeting.

#### Language support
The app supports English, German, Danish, Norwegian and Swedish. 
The language is controlled by preferred language settings in your browser.

#### Contribute
**Thanks for all user feedback!**
The app is *open source* and developed in 
[Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) and 
[.NET](https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet), using a free version of
[Visual Studio](https://visualstudio.microsoft.com/).
If you have a GitHub account, you can file [suggestions and other issues](https://github.com/tellurianinteractive/Tellurian.Trains.WagonCardApp/issues).
Discussions are also in the [FREMO forum](https://forum.fremo-net.eu/t/online-loco-and-wagon-card-app/).

## Features
#### Freigh Wagon Card
The coloured frame adapts according the FREMO standard based on the vehicle class.
You also get an *inventory card*, see below.

#### Passenger Wagon Card
Coloured frame according the FREMO standard? 
You also get an *inventory card*, see below.

#### Loco Card
I addition to the loco-card itself, you get a *FRED-stcker* and an *inventory card*. 
The loco functions are printed both on the loco card itself 
and selected ones on the FRED-sticker.

#### FRED Label
The FRED label contains maximum 8 functions, you can select which.
The top can be folded so that the locomotive identification is visible above the front,

#### Inventory Cards
The idea with an inventory card is that you remove it from the loco/wagon-card pocket 
when you place the loco/wagon on a track.
You put the inventory card on the loco/wagon box.
Then you know that you should collect before travelling home after the meeting.

#### QR Codes
QR codes are visible on both loco- and wagon cards. 
QR-code also on FRED-sticker. QR-code contains *loco address*, *owner's name*, *UIC-number*, and *label*.
If a value is not provided, it won't show up in the QR-code.
The content of the QR-code is formatted as JSON, which also makes it machine readable.

#### Example of Freight Wagon Card
![Example-freight wagon](https://github.com/tellurianinteractive/Tellurian.Trains.WagonCardApp/blob/master/Example-freight%20wagon.PNG)
