#include <iostream>
#include <string>
#include <sstream>

using namespace std;

class MediaItem {
protected:
	string name;
	string publisher;
public:
	MediaItem(string n, string pub) {
		name = n;
		publisher = pub;
	}
	virtual bool search(string term) {
		return name.find(term) != -1 || publisher.find(term) != -1;
	}
	virtual string lengthInfo() {
		return "";
	}
};

class Book: public MediaItem {
private:
	int pages;
public:
	Book(string name, string pub, int pgs) : MediaItem(name, pub) {
		pages = pgs;
	}
	virtual string lengthInfo() override {
		ostringstream oss;
		oss << pages << " pages";
		return oss.str();
	}
};

class Textbook: public Book {
private:
	string subject;
public:
	Textbook(string name, string sub, string pub, int pages) : Book(name, pub, pages) {
		subject = sub;
	}
	virtual bool search(string term) override {
		 return Book::search(term) || subject.find(term) != -1;
	}
};

class Video: public MediaItem {
private:
	int minutes;
public:
	Video(string name, string pub, int min) : MediaItem(name, pub) {
		minutes = min;
	}
	virtual string lengthInfo() override {
		ostringstream oss;
		oss << minutes << " minutes";
		return oss.str();
	}
};

class CD: public MediaItem {
private:
	int minutes;
	int numTracks;
public:
	CD(string name, string pub, int min, int numTracks) : MediaItem(name, pub) {
		minutes = min;
		this->numTracks = numTracks;
	}
	virtual string lengthInfo() override {
		ostringstream oss;
		oss << numTracks << " tracks (" << minutes << " total minutes)";
		return oss.str();
	}
};

void main() {
	MediaItem* items [] = { new Book("Rainman", "Sideways", 250),
								new Textbook("Programming Languages", "Computer Science", "Pearson", 640),
								new Video("Lincoln", "Warner Brothers", 150),
								new CD("Dark Side of the Moon", "EMI", 55, 10)
								};

	for each (MediaItem* m in items) {
		cout << m->lengthInfo() << endl;
		cout << m->search("Side") << endl;
	}
}