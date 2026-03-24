# Uczelniana wypożyczalnia sprzętu

## Opis projektu

Projekt przedstawia aplikację konsolową napisaną w języku C#, służącą do obsługi uczelnianej wypożyczalni sprzętu. System umożliwia zarządzanie sprzętem, użytkownikami oraz procesem wypożyczeń.

Aplikacja pozwala na:
* dodawanie użytkowników i sprzętu,
* wypożyczanie i zwracanie sprzętu,
* kontrolę dostępności,
* obsługę opóźnień i naliczanie kar,
* generowanie raportów.

---

## Struktura projektu:
### 1. Model domeny

Klasy reprezentujące obiekty systemu:
* `Equipment` (klasa abstrakcyjna)
    * `Laptop`
    * `Camera`
    * `Projector`
* `User` (klasa abstrakcyjna)
    * `Student`
    * `Employee`
* `Rent`

Każda z tych klas odpowiada wyłącznie za przechowywanie danych i prostą logikę związaną z własnym stanem.

---

### 2. Logika biznesowa

* `RentalManagement`

Klasa odpowiedzialna za:
* wypożyczanie sprzętu,
* zwroty,
* walidację reguł biznesowych,
* generowanie raportów.

Cała logika operacyjna została skupiona w jednym miejscu, co ułatwia jej modyfikację i utrzymanie.

---

### 3. Warstwa prezentacji

* `Program.cs`

Odpowiada jedynie za:

* uruchomienie programu,
* pokazanie scenariusza działania,
* komunikację z użytkownikiem (Console).

---

## Reguły biznesowe

W systemie zaimplementowano następujące zasady:

* Student może mieć maksymalnie 2 aktywne wypożyczenia
* Pracownik może mieć maksymalnie 5 aktywnych wypożyczeń
* Sprzęt oznaczony jako niedostępny nie może być wypożyczony
* Zwrot po terminie skutkuje naliczeniem kary:
    * 10 zł za każdy dzień opóźnienia
---

## Decyzje projektowe

### a) Kohezja (spójność)

Każda klasa ma jedną odpowiedzialność:
* `Equipment` zarządza stanem sprzętu,
* `User` określa typ i limity użytkownika,
* `Rent` przechowuje dane wypożyczenia,
* `RentalManagement` obsługuje logikę systemu.

Dzięki temu klasy są czytelne i łatwe do zrozumienia.

---

### b) Coupling (sprzężenie)

Klasy nie są ze sobą nadmiernie powiązane:
* `Program` nie zarządza danymi bezpośrednio,
* komunikacja odbywa się przez `RentalManagement`,
* brak globalnych zależności.

Zmiany w jednej klasie mają ograniczony wpływ na resztę systemu.

---

### c) Dziedziczenie

Zastosowano dziedziczenie tylko tam, gdzie ma sens:

* `Equipment` → różne typy sprzętu,
* `User` → różne typy użytkowników.

Pozwala to uniknąć duplikacji kodu i zachować czytelność modelu.

---

### d) Czytelność i prostota

Projekt został celowo utrzymany w prostej strukturze:

* brak zbędnych warstw,
* brak nadmiernej liczby klas,
* logika skupiona w jednym miejscu (`RentalManagement`).

Dzięki temu kod jest łatwy do zrozumienia i modyfikacji.

---

## Instrukcja uruchomienia

1. Sklonuj repozytorium:

```
git clone <repozytorium>
```

2. Przejdź do folderu projektu:

```
cd RentEquipment
```

3. Uruchom aplikację:

```
dotnet run
```

---

## Scenariusz demonstracyjny

Program prezentuje:

* dodanie użytkowników i sprzętu,
* poprawne wypożyczenie,
* próbę wykonania błędnej operacji,
* przekroczenie limitu wypożyczeń,
* zwrot w terminie,
* zwrot po terminie z naliczeniem kary,
* oznaczenie sprzętu jako niedostępnego,
* wygenerowanie raportu końcowego.
