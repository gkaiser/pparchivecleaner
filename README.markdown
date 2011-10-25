# README #

----

The PP Archive Cleaner is a simple filesystem archiver/cleaner. Like, really simple. All it does is take a base directory, then looks for directories underneath the base and finds any files older than a specified age. The files older than the specified age are put into a tar-bzipped archive and deleted.

There is a `List<string>` object in the FrmCleaning.cs file that contains the extensions that will be cleaned. It defaults to `*.dat, *.txt, *.tmp`.