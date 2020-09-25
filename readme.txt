PsyLog by Gavin Kendall
Last updated on 2020-09-25 (September 25, 2020)
=============================================================================================================



Summary
-------
PsyLog is a very simple keylogger for Windows. It's not stealthy or very advanced, but the output is nice
because it also writes out the title of the active window and the date and time while keylogging.



How To Use
----------
To start keylogging simply run "psylog.exe" and all keystrokes (including the title of the active window)
will be written to a text file named "psylog.txt" that will appear in the same directory as the executable.

To stop keylogging open Task Manager, look for "psylog.exe" in your list of running processes, and kill it.



Customized Filename
-------------------
If you want you can also customize the filename of the log file by using the "-file" command line option.
For example ...
psylog.exe -file="mylog.txt"
... will write all keystrokes to a file named mylog.txt in the same directory as the executable.

You can also use what I like to call "macro tags" for your filename with the "-file" command line option.
For example ...
psylog.exe -file="%date%_log.txt"
... will write all keystrokes to a file named 2020-07-25_log.txt if today was July 25, 2020.



Macro Tags
----------
The following tags can be used with the "-file" command line option:
%user%           The name of the logged in user of the computer
%machine%        The name of the computer being used
%date%           The current date
%time%           The current time
%year%           The current year
%month%          The current month
%day%            The current day
%hour%           The current hour
%minute%         The current minute
%second%         The current second
%millisecond%    The current millisecond