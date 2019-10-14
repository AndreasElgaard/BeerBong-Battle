#define size 25
struct personale { // vi navngiver vores struct
	int brugerid_; // en int til bruger id
	char navn_[size]; // en string til førstenavn
	char efternavn_[size]; // en string til efternavn
	int age; // en int til alderen
	float vægt; // og en float til vægt
};

