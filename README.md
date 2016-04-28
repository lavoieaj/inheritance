# Inheritance

These programs are designed to show how concepts of class inheritance can be implemented in Java and C#.

Both programs have generic base classes of MediaItem, representing any arbitrary form of physical or digital media, as well as subclasses of Book, Textbook, Video, and CD to represent specific forms of media.

The base class of MediaItem posesses attributes of name and publisher that will be inherited by all child classes derived from it. MediaItem also contains two virtual methods, 'search' and 'lengthInfo' which are overridable by the child classes enabling them to be used in ways better suited to those specific forms of media.
