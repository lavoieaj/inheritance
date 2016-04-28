using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem2_csharp
{
    public abstract class MediaItem
    {
        protected String name;
        protected String publisher;
        public MediaItem(String n, String pub)
        {
            name = n;
            publisher = pub;
        }
        virtual public bool search(String term)
        {
            return name.IndexOf(term) != -1 || publisher.IndexOf(term) != -1;
        }
        virtual public String lengthInfo()
        {
            return "";
        }
    }

    public class Book: MediaItem 
    {
	    private int pages;
	    public Book(String name, String pub, int pgs) : base(name, pub)
	    {
		    pages = pgs;
	    }
	    override public String lengthInfo()
	    {
		    return pages + " pages";
	    }
    }

    public class Textbook : Book {
	    private String subject;
	    public Textbook(String name, String sub, String pub, int pages) : base(name, pub, pages)
	    {
		    subject = sub;
	    }
	    override public bool search(String term)
	    {
		    return base.search(term) || subject.IndexOf(term) != -1;
	    }
    }

    
    public class Video : MediaItem {
	    private int minutes;
	    public Video(String name, String pub, int min) : base(name, pub)
	    {
		    minutes = min;
	    }
	    override public String lengthInfo()
	    {
		    return minutes + " minutes";
	    }
    }

    public class CD : MediaItem {
	    private int minutes;
	    private int numTracks;
	    public CD(String name, String pub, int min, int numTracks) : base(name, pub)
	    {
		    minutes = min;
		    this.numTracks = numTracks;
	    }
	    override public String lengthInfo()
	    {
            return numTracks + " tracks (" + minutes + " total minutes)";
	    }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MediaItem [] items = { new Book("Rainman", "Sideways", 250),
								new Textbook("Programming Languages", "Computer Science", "Pearson", 640),
								new Video("Lincoln", "Warner Brothers", 150),
								new CD("Dark Side of the Moon", "EMI", 55, 10)
								};

		    foreach (MediaItem m in items) {
			    System.Console.WriteLine(m.lengthInfo());
			    System.Console.WriteLine(m.search("Side"));
		    }
        }
    }
}
