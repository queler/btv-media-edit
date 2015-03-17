# Main Window #

![http://i754.photobucket.com/albums/xx188/brettg4/btvMediaEditMain.png](http://i754.photobucket.com/albums/xx188/brettg4/btvMediaEditMain.png)

## BTV Server Settings ##

  * _Address_: The address of the system running BTV. If BTV Media Edit is running on the  same system as BTV this should be `localhost` or `127.0.0.1`.
  * _Port_: The port BTV is running its HTTP administration server on. The default is `8129`.
  * _User_: The username to use for login.
  * _Password_: The password to use for login.

## Controls ##

  * _Scan_: Scan selected **_Media Folders_** and add newly found series to the **_Series Map_** but do not update information in the BTV library.
  * _Update_: Perform same action as _Scan_ and also update information in the BTV library.
  * _Only Edit Unknown Series_: Only update media files which show up as _Unknown_ in the BTV library.
  * _Auto-Lookup Unknown Series IDs_: Automatically search for new series information on TheTVDB.com and add to the **_Series Map_**.

## Schedule ##

Enable BTV Media Edit to automatically perform an _update_ for new media in specified **_Media Folders_** and control the amount of time between checks.

## Media Folders ##

Select which media folders to manage with BTV Media Edit. Hit the _Refresh_ button to update the list of folders configured for use with BTV.

## Series Map ##

The **_Series Map_** is the list of all series known to BTV Media Edit. It is used to map the series title parsed from a media file's name to the series title to insert into the BTV library.  It also contains data required to download episode information.

  * _Parsed Name_: The series title parsed from a media file's name.
  * _Series Name_: The series name to insert into the BTV library.
  * _SeriesID_: The series ID from TheTVDB.com
  * _Series Overview_: A summary of the series from TheTVDB.com (to ensure the series mapping is correct).

Double-clicking an item (or selecting an item and clicking _Edit_) in the **_Series Map_** will bring up a window which allows the series search/mapping to be performed manually.

  * _Delete_: Removes the currently selected item from the **_Series Map_**.
  * _Clear All_: Removes all items from the **_Series Map_**.


# Movie Editor #

![http://i754.photobucket.com/albums/xx188/brettg4/btvMediaEditMovie.png](http://i754.photobucket.com/albums/xx188/brettg4/btvMediaEditMovie.png)