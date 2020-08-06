# FileHandling
The program was created in Visual Studio 2019
Can be started with Debug or Run, will be started both - the Web Api and the Windows Form project too

The Web Api was tested with Postman and with the unit tests.

The Web Api url is saved in the desktop application App.config, the value for the key "Api" returns the url where the Web Api is running.
The folder path where the Web Api stores the files ist saved int the web.config file of the Web Api, the value of the key "FileLocation" returns the actual path for the saved files.
