# TeleTrader
Ovaj repozitorijum sadrži kod aplikacije TeleTrader. 
# Korišćena tehnologija:
- Programski jezik: C#
- Software framework: .NET 6
- UI framework: WinForms
# Glavne funkcionalnosti
- Dodavanje simbola: Korisnici mogu da kreiraju nove simbole pružajući potrebne detalje (naziv simbola, ticker, cena, ..).
- Pregled/Izmena simbola: Korisnici mogu da pregledaju ili izmene detalje postojećeg simbola.
- Brisanje simbola: Korisnici mogu da obrišu selektovani simbol.
- Učitavanje baze: Korisnici mogu da učitaju SQLite bazu odabirom putanje.
- Filtriranje simbola po Stockexchange-u i Type-u
# Dodatne funkcionalnosti
- Unload baze: Ukoliko korisnik želi da učita bazu sa drugačijim vrednostima.
- Validacija polja: Dodata je validacija polja pri izmeni ili dodavanju simbola kako bi se smanjila mogućnost greške.
- Data counter: Dodat je brojač učitanih podataka.
- Validacija otvorenog fajla
# Instalacija i pokretanje
- Klonirajte repozitorijum kroz Visual Studio: https://github.com/kristinaglisovic/TeleTrader.git
ili
- Koristite komandu git clone kako biste preuzeli kod na vaš lokalni računar: git clone https://github.com/vas-repo/teletrader-symbolform.git, a zatim ga pokrenite u Visual Studio-u
- Build Solution kako biste generisali izvršnu datoteku i/ili kliknite na dugme "Start" u Visual Studio-u kako biste pokrenuli projekat.
