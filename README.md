# Biuro_nieruchomosci - raport


W celu zapoznania się z dokumentacją programu należy pobrać folder **Dokumentacja**, a następnie otworzyć poszczególne pliki za pomocą domyślnej przeglądarki.
W każdym pliku znajduje się dokumetacja, w której opisane są klasy, jak również zawarte w nich metody wraz z parametrami oraz zwracanymmi wartościami. Plik **ContentsMerged.css** służy do modyfikowania stylu dokumentacji w przeglądarce.

## Struktura projektu

Poniżej przedstawiony został diagram UML Biura_nieruchomości. Klasy oznaczone kolorem niebieskim są klasami abstrakcyjnymi. 

Model zaprojektowany został w myśl zasad OOP, opierając się na mechanizmach kompozycji, dziedziczenia i agregacji. Ponadto  zaimplementowane zostały również interfejsy, takie jak **IOferuje**, a także **IComparable**, **IEquatable**.


Wśród innych zasad Object Oriented Programming, które stanowiły podstawę tworzenia diagramu, można wymienić:

* hermetyzacja
* abstrakcja
* polimorfizm
* dziedziczenie
* Liskov substitution principle (klasa dziedzicząca pwoinna być dobrym odpowiednikiem klasy bazowej)
* KISS


![alt text](https://github.com/KlaudiaToJa/Biuro_nieruchomosci//blob/master/diagram_uml.jpg?raw=true)


# Instrukcja użytkownika

## Informacje na temat aplikacji

Powyższa aplikacja została stworzona w celu obsługi biura nieruchomości. 

## Dostępne funkcjonalności:

* Dodawanie oraz usuwanie klienta z bazy
* Dodawanie oraz usuwanie nieruchomości z bazy wraz z jej specyfikacjami 
* Dodawanie oraz usuwanie pracowników z bazy
* Dodawanie oferty wraz z jej opisem
* Wyszukiwanie nieruchomości w bazie na podstawie wybranych przez użytkownika filtrów. Mozliwosc wyswietlenia szczegolow danej nieruchomosci.
* Wyszukiwanie zarówno aktywnych jak i zarchiwizowanych ofert w bazie na podstawie wybranych przez użytkownika filtrów
* Wyszukiwanie pracowników w bazie wraz z opcjami sortowania po nazwisku lub po miejscowości
* Tworzenie umowy pośrednictwa sprzedaży oraz umowy pośrednictwa kupna wraz z możliwością ustawienia prowizji oraz przypisania klienta jak i opiekuna klienta (pracownika) 
* Ustalanie prowizji od danej umowy dla biura nieruchomości
* Automatyczne sprawdzanie dostępności klienta w bazie na podstawie numeru PESEL


## Korzystanie z aplikacji

Po otwarciu aplikacji wyświetla się interfejs użytkownika, za pomocą którego dokonać można wszystkich wspomnianych powyżej operacji. Należy pamietać, by na początku wprowadzić do bazy dane klienta, pracownika oraz nieruchomości, ponieważ funkcjonalności takie jak tworzenie ofert czy umów opierają się właśnie na tych trzech podstawowych fundamentach modelu. 
Aplikacja została zaprojektowana w sposób intuicyjny, z troską o zapewnienie wygodnego produktu do obsługi podstawowej działalności biura nieruchomości


# Podział obowiązków




